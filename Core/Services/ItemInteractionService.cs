#region

using System.Collections.Generic;
using System.Linq;
using Inventory.Interfaces;
using Inventory.Validators;

#endregion

namespace Inventory.Interactions
{
    public class ItemInteractionService : IItemInteractionService
    {
        public InteractionContext? CurrentContext = null;

        public ContainerDestination? FindFreeSpace(IItem item, IContainer destination)
        {
            // 1. Attempt to find space in the destination container
            ContainerDestination? spaceInDestination = FindSpaceInContainer(item, destination);
            if (spaceInDestination != null) 
                return spaceInDestination;

            // 2. Get direct subcontainers and attempt to find space recursively
            foreach (IContainer subContainer in destination.GetSubContainers())
            {
                ContainerDestination? spaceInSubContainer = FindFreeSpace(item, subContainer);
                if (spaceInSubContainer != null) return spaceInSubContainer;
            }

            // 3. No suitable space found
            return null;
        }

        public ContainerDestination? FindSpaceInContainer(IItem item, IContainer container)
        {
            switch (container)
            {
                // TODO case ICharacterInventory characterInventory:
                //    if (characterInventory.EquipmentSlots.)
                
                case ISingleItemContainer singleItemContainer:
                    if (FilterValidator.Validate(new InteractionContext(item, container)) && 
                        !singleItemContainer.Occupied)
                        return new SingleItemContainerDestination(singleItemContainer);
                    break;

                case ISlotContainer slotContainer:
                    IEnumerable<Slot>? freeSlots = FindFreeSlotsForItem(item, slotContainer);
                    if (freeSlots != null) 
                        return new SlotContainerDestination(slotContainer, freeSlots);
                    break;

                // Handle other container types as needed
            }

            return null;
        }

        public static Slot[]? FindFreeSlotsForItem(IItem item, ISlotContainer slotContainer)
        {
            Dimensions itemDimensions = item.ItemDimensions;
            int itemWidth = itemDimensions.Columns;
            int itemHeight = itemDimensions.Rows;

            // Get all slots that are either empty or contain the item being moved
            Slot[] availableSlots = slotContainer.SlotsToItems
                .Where(kvp => kvp.Value == null || kvp.Value == item)
                .Select(kvp => kvp.Key)
                .ToArray();

            // Quick fit check
            if (availableSlots.Length < itemWidth * itemHeight)
                return null;

            // Order available slots by row and column
            Slot[] orderedAvailableSlots = availableSlots
                .OrderBy(s => s.Position.Row)
                .ThenBy(s => s.Position.Column)
                .ToArray();

            // Create a HashSet for faster lookup
            HashSet<SlotPosition> availableSlotPositions = new(availableSlots.Select(s => s.Position));

            // Iterate over possible starting positions in available slots
            foreach (Slot startingSlot in orderedAvailableSlots)
            {
                int startRow = startingSlot.Position.Row;
                int startColumn = startingSlot.Position.Column;

                // Check if the item would fit within the container bounds
                if (startRow + itemHeight > slotContainer.ContainerDimensions.Rows ||
                    startColumn + itemWidth > slotContainer.ContainerDimensions.Columns)
                    continue;

                // Check if the item fits starting from this position
                if (ItemFitsAtPosition(
                        item, 
                        slotContainer, 
                        startRow, 
                        startColumn, 
                        availableSlotPositions, 
                        out Slot[] slotsNeeded))
                {
                    return slotsNeeded;
                }
            }

            return null;
        }

        private static bool ItemFitsAtPosition(
            IItem item,
            ISlotContainer slotContainer,
            int startRow,
            int startColumn,
            HashSet<SlotPosition> availableSlotPositions,
            out Slot[] slotsNeeded)
        {
            
            Dimensions itemDimensions = item.ItemDimensions;
            int itemWidth = itemDimensions.Columns;
            int itemHeight = itemDimensions.Rows;
            slotsNeeded = new Slot[itemWidth * itemHeight];
            int slotsFound = 0;
            
            for (int dy = 0; dy < itemHeight; dy++)
            {
                for (int dx = 0; dx < itemWidth; dx++)
                {
                    int checkRow = startRow + dy;
                    int checkCol = startColumn + dx;

                    SlotPosition slotPosition = new (checkCol, checkRow);

                    // Check if the required slot is in the set of available positions
                    if (!availableSlotPositions.Contains(slotPosition))
                    {
                        return false; // Slot is not available
                    }

                    // Retrieve the Slot object
                    // Change to .Contains?
                    Slot slot = slotContainer.SlotsToItems.Keys.FirstOrDefault(s => s.Position == slotPosition);
                    if (slot == null)
                        return false; // Slot does not exist (shouldn't happen if positions are correct)

                    slotsNeeded[slotsFound] = slot;
                    slotsFound++;
                }
            }
            
            return true;
        }
    }
}