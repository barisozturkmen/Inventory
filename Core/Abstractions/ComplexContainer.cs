namespace Inventory.Abstractions
{
    public abstract class ComplexContainer : ISegmentedContainer, IAttachmentContainerItem
    {
        public abstract string Name { get; }
        public abstract List<ISlotContainer> SubContainers { get; }
        public abstract Dimensions ItemDimensions { get; }
        public abstract List<AttachmentSlot> AttachmentSlots { get; }
    }
}