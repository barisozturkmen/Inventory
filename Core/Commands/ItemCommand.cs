using Inventory.Interactions;

namespace Inventory.Commands
{
    public abstract class ItemCommand
    {
        public abstract bool Execute();
        public abstract bool CanExecute(out InteractionFeedback feedback);
    }
}