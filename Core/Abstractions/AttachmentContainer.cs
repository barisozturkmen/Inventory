namespace Inventory.Abstractions
{
    public abstract class AttachmentContainer : IAttachmentContainerItem
    {
        public abstract string Name { get; }
        public abstract Dimensions ItemDimensions { get; }
        public abstract List<AttachmentSlot> AttachmentSlots { get; }
    }
}