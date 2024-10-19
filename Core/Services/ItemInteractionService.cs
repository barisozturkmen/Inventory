using Inventory.Abstractions;
using Inventory.Interactions;

namespace Inventory.Services
{
    public class ItemInteractionService : IItemInteractionService
    {
        public void GetOptions(IItem item)
        {
            // TODO 1. Add an ActionOptions collection to items
            //      2. For specific items, add ActionOptions to collection
            //          such as Move, Stack, Transform, Equip
            //      3. Return options 
        }
        
        public void HandleSelect(InteractionSelection selection)
        {
            InteractionContext.Select(selection);
        }

        public bool HandleTargetOption(InteractionSelection selection, InteractionDestination destination)
        {
            bool result = false;
            if (selection.Option == ActionOption.None)
            {
                selection.Option = ActionOption.Move; //default
            }
            
            if (selection.Option == ActionOption.Move)
            {
                result = MoveItemService.ValidateMoveOption(selection.Item, destination);
            }

            //else interaction other than move

            return result;

        }

        public void HandleExecute(InteractionSelection selection, CompleteDestination destination)
        {
            if (selection.Option == ActionOption.Move)
            {
                MoveItemService.MoveItem(selection, destination);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private ActionOption GetDefaultOption(IEnumerable<ActionOption> actionOptions)
        {
            // TODO 1. 
            throw new NotImplementedException();
        }
        
        
        
        
        
        
        
        


    }
}