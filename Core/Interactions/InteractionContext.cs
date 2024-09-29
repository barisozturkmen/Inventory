using Inventory.Commands;
using Inventory.Interfaces;

namespace Inventory.Interactions
{
    public class InteractionContext
    {
        public IItem Item { get; set; }
        public IInteractionTarget? Target { get; set; }
        public Slot[]? DestinationSlots { get; set; }
        public ItemCommand? Interaction { get; set; }

        public InteractionContext(IItem item)
        {
            Item = item;
        }
        
        public InteractionContext(IItem item, IInteractionTarget target)
        {
            Item = item;
            Target = target;
        }
    }
}