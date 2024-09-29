using System.Collections.Generic;
using Inventory.Interfaces;

namespace Inventory.Interactions
{
    public abstract class ContainerDestination
    {
        public IContainer Container { get; }

        protected ContainerDestination(IContainer container)
        {
            Container = container;
        }
    }

    public class SlotContainerDestination : ContainerDestination
    {
        public IEnumerable<Slot> Slots { get; }

        public SlotContainerDestination(ISlotContainer container, IEnumerable<Slot> slots)
            : base(container)
        {
            Slots = slots;
        }
    }

    public class SingleItemContainerDestination : ContainerDestination
    {
        public ISingleItemContainer SingleItemContainer => (ISingleItemContainer)Container;

        public SingleItemContainerDestination(ISingleItemContainer container)
            : base(container)
        {
        }
    }

}