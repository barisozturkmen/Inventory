using System.Collections.Generic;
using System.Linq;
using Inventory.Interactions;
using Inventory.Interfaces;

namespace Inventory.Validators
{
    public class SpaceValidator: IInteractionValidator
    {
        public static bool Validate(InteractionContext context)
        {
            switch (context.Target)
            {
                case ISingleItemContainer singleItemContainer:
                    return !singleItemContainer.Occupied;
                case ISlotContainer slotContainer when
                    context.DestinationSlots is not null:
                {
                    if (AreSlotsOccupied(context, slotContainer)) 
                        return false;

                    if (!ItemFitsContainerAtPosition(context, slotContainer)) 
                        return false;

                    return true;
                }
            }

            return true;
        }

        private static bool AreSlotsOccupied(InteractionContext context, ISlotContainer slotContainer)
        {
            Dictionary<Slot, IItem?> subset = context.DestinationSlots!
                .Select(s =>
                    new KeyValuePair<Slot, IItem?>(s,
                        slotContainer.SlotsToItems[s]))
                .ToDictionary();
            
            bool occupied = subset.Any(kvp => 
                kvp.Value is not null || 
                kvp.Value != context.Item);

            return occupied;
        }
        
        private static bool ItemFitsContainerAtPosition(InteractionContext context, ISlotContainer slotContainer)
        {
            Dimensions itemDimensions = context.Item.ItemDimensions;

            int leftMostCol = context.DestinationSlots!.Min(s => s.Position.Column);
            int topMostRow = context.DestinationSlots!.Min(s => s.Position.Row);
            
            if (leftMostCol + itemDimensions.Columns > slotContainer.ContainerDimensions.Columns ||
                topMostRow + itemDimensions.Rows > slotContainer.ContainerDimensions.Rows)
                return false;
            
            return true;
        }
    }
}