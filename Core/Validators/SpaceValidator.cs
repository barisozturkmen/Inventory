using Inventory.Abstractions;
using Inventory.Interactions;

namespace Inventory.Validators
{
    public static class SpaceValidator
    {
        public static bool ValidateSpace(this InteractionDestination destination, IItem item)
        {
            switch (destination)
            {
                case SingleContainerDestination toSingleItemContainer:
                    return toSingleItemContainer.ValidateSpace(item);
                case SlotsDestination toSlotContainer:
                    return toSlotContainer.ValidateSpace(item);
                default:
                    return false;
            }
        }
        
        public static bool ValidateSpace(this SingleContainerDestination singleDestination, IItem item)
        {
            if (singleDestination.Target is ISingleContainer singleItemContainer)
                return !singleItemContainer.Occupied;

            return false;
        }
        
        public static bool ValidateSpace(this SlotsDestination slotsDestination, IItem item)
        {
            if (slotsDestination.Target is not ISlotContainer slotContainer) 
                return false;
            
            Slot[] targetSlots = slotsDestination.TargetSlots;
            if (SlotsNotInContainer(slotContainer, targetSlots))
                return false;
            
            if (AreSlotsOccupied(item, slotContainer, targetSlots))
                return false;

            if (IsInvalidPosition(item.ItemDimensions, slotContainer, targetSlots))
                return false;

            return true;
        }

        private static bool SlotsNotInContainer(ISlotContainer slotContainer, Slot[] targetSlots)
        {
            foreach (Slot slot in targetSlots)
            {
                if (!slotContainer.SlotsToItems.ContainsKey(slot))
                    return true;
            }
            
            return false;
        }

        // Reuse this for find slots
        private static bool AreSlotsOccupied(IItem item, ISlotContainer slotContainer, Slot[] targetSlots)
        {
            Dictionary<Slot, IItem?> targetSlotsToItems = targetSlots
                .Select(s => new KeyValuePair<Slot, IItem?>(s, slotContainer.SlotsToItems[s]))
                .ToDictionary();
            
            bool occupied = targetSlotsToItems.Any(kvp => 
                kvp.Value is not null && 
                kvp.Value != item);

            return occupied;
        }
        
        // Reuse this for find slots
        private static bool IsInvalidPosition(
            Dimensions itemDimensions, 
            ISlotContainer slotContainer, 
            Slot[] targetSlots)
        {
            int leftMostCol = targetSlots.Min(s => s.Position.Column);
            int topMostRow = targetSlots.Min(s => s.Position.Row);
            
            if (leftMostCol + itemDimensions.Columns - 1 > slotContainer.ContainerDimensions.Columns ||
                topMostRow + itemDimensions.Rows - 1 > slotContainer.ContainerDimensions.Rows)
                return true;
            
            return false;
        }
    }
}