using Inventory.Abstractions;

namespace Inventory.Interactions
{
    public abstract class FindSpaceResult
    {
        public bool Found { get; set; } = false;
        protected IItem Item { get; }
        protected IContainer Container { get; }
        
        protected FindSpaceResult(IItem? item, IContainer container)
        {
            Item = item ?? throw new ArgumentNullException(nameof(item));
            Container = container ?? throw new ArgumentNullException(nameof(container));
        }
    }

    public class ContainerFindSpaceResult : FindSpaceResult
    {
        protected ContainerFindSpaceResult(IItem? item, IContainer container) 
            : base(item, container)
        {
            Found = true;
        }
    }

    public class FailedFindSpaceResult : FindSpaceResult
    {
        public FailedFindSpaceResult(IItem? item, IContainer container) 
            : base(item, container)
        {
            
        }
    }

    public class SlotFindSpaceResult : ContainerFindSpaceResult
    {
        public IEnumerable<Slot> Slots { get; }

        public SlotFindSpaceResult(IItem? item, ISlotContainer container, IEnumerable<Slot> slots)
            : base(item, container)
        {
            Slots = slots ?? throw new ArgumentNullException(nameof(slots));
        }
    }

    public class SingleItemFindSpaceResult : ContainerFindSpaceResult
    {
        public SingleContainer SingleContainer => (SingleContainer)Container;

        public SingleItemFindSpaceResult(IItem? item, SingleContainer container)
            : base(item, container)
        {
            
        }
    }

}