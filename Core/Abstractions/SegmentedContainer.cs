namespace Inventory.Abstractions
{
    public abstract class SegmentedContainer : ISegmentedContainer
    {
        public abstract string Name { get; }
        public abstract List<ISlotContainer> SubContainers { get; }
    }
}