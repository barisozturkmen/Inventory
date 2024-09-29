using System.Collections.Generic;

namespace Inventory.Interfaces
{
    public interface IContainerItem  : IItem
    {
        
    }

    /// <summary>
    /// Eg: Most bags, most pouches, some tactical rigs
    /// </summary>
    public interface ISlotContainerItem : IRestrictedContainer, ISlotContainer, IItem
    {

    }

    /// <summary>
    /// Eg: Customisable weapons, some bags, most tactical rigs
    /// </summary>
    public interface IAttachmentContainerItem : IContainerItem
    {
        IEnumerable<IAttachmentSlot> AttachmentSlots { get; }
    }
    
    public interface IWeapon : IAttachmentContainerItem
    {
        
    }
}