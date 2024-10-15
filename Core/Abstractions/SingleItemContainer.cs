using Inventory.Interactions;

namespace Inventory.Abstractions
{
    /// <summary>
    /// Single item container for holding a single item of any
    /// dimensions but can be restricted to a particular type.
    /// </summary>
    public abstract class SingleContainer : ISingleContainer
    {
        public abstract string Name { get; protected init; }
        public IItem? ContainedItem { get; private set; }
        public bool Occupied => ContainedItem is not null;
        public abstract Allowed Allowed { get; protected init; }

        public bool AddItem(IItem item, InteractionDestination destination)
        {
            if (destination is not SingleContainerDestination singleContainerDestination)
                throw new ArgumentException("Invalid InteractionDestination type for SingleContainerDestination.");

            ContainedItem = item;

            return true;
        }
        
        public bool RemoveItem(IItem item)
        {
            if (ContainedItem is null)
                throw new Exception();

            ContainedItem = null;

            return true;
        }
    }
}

