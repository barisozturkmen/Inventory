using Inventory.Abstractions;

namespace Inventory.Interactions
{
    public class InteractionSelection
    {
        public IItem Item { get; set; }
        public IManagedContainer? Origin { get; set; }
        public ActionOption Option { get; set; } = ActionOption.None;

        public InteractionSelection(IItem item, IManagedContainer? origin = null)
        {
            Item = item;
            Origin = origin;
        }
        
        public InteractionSelection(IItem item, ActionOption option, IManagedContainer? origin = null)
        {
            Item = item;
            Option = option;
            Origin = origin;
        }
    }
}