using System;
using Inventory.Interactions;
using Inventory.Interfaces;

namespace Inventory.Commands
{
    public class MoveItemCommand : ItemCommand
    {
        private readonly IItem _item;
        private readonly IContainer _sourceContainer;
        private readonly IContainer _destinationContainer;
        private readonly InteractionContext _context;
        private readonly IItemInteractionService _interactionService;

        public MoveItemCommand(
            IItem item, 
            IContainer sourceContainer, 
            IContainer destinationContainer, 
            InteractionContext context, 
            IItemInteractionService interactionService)
        {
            _item = item;
            _sourceContainer = sourceContainer;
            _destinationContainer = destinationContainer;
            _context = context;
            _interactionService = interactionService;
        }

        public override bool Execute()
        {
            return false;
            //return _interactionService.MoveItem(_item, _sourceContainer, _destinationContainer, _context);
        }

        public override bool CanExecute(out InteractionFeedback feedback)
        {
            //return _interactionService.CanMoveItem(_item, _destinationContainer, _context, out feedback);
            throw new NotImplementedException();
        }
    }
}