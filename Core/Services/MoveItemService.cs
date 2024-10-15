using Inventory.Abstractions;
using Inventory.Interactions;
using Inventory.Validators;

namespace Inventory.Services
{
    public static class MoveItemService
    {
       
        public static void MoveItem(InteractionSelection selection, KnownDestination destination)
        {
            if (selection is null || destination is null)
                throw new NullReferenceException();

            selection.Origin?.RemoveItem(selection.Item);
            switch (destination)
            {
                case SingleContainerDestination singleTarget:
                    var singleContainer = singleTarget.Target as SingleContainer;
                    singleContainer!.AddItem(selection.Item, singleTarget);
                    break;
                case SlotsDestination slotsTarget:
                    var slotContainer = slotsTarget.Target as SlotContainer;
                    slotContainer!.AddItem(selection.Item, slotsTarget);
                    break;
            }
            // what if item is removed but can't be re-added?
        }
        
        public static bool ValidateMoveOption(IItem item, InteractionDestination destination)
        {
            bool resolved = false;
            resolved = destination.ValidateRestriction(item) &&
                       destination.ValidateSpace(item);

            return resolved;
        }
    }
}