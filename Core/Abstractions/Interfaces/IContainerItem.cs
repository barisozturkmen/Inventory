namespace Inventory.Abstractions
{
    public interface IContainerItem  : IContainer, IItem
    {
        
    }

    /// <summary>
    /// Eg: Customisable weapons, some bags, most tactical rigs
    /// </summary>
    public interface IAttachmentContainerItem : IContainerItem
    {
        List<AttachmentSlot> AttachmentSlots { get; }
    }
}