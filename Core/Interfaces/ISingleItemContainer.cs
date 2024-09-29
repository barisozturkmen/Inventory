namespace Inventory.Interfaces
{
    /// <summary>
    /// Single item container for holding a single item of any
    /// dimensions but can be restricted to a particular type.
    /// </summary>
    public interface ISingleItemContainer : IRestrictedContainer
    {
        IItem? ContainedItem { get; set; }
        bool Occupied => ContainedItem != null;
    }
    
    /// <summary>
    /// Single item container for holding a single item of any
    /// dimensions but can be restricted to a particular type.
    /// Eg: Character main weapon slot, character bag equipment slot
    /// </summary>
    public interface IEquipmentSlot : ISingleItemContainer
    {
        
    }
    
    /// <summary>
    /// Single item container for holding a single item of any
    /// dimensions but can be restricted to a particular type.
    /// Eg: Customisable equipment
    /// </summary>
    public interface IAttachmentSlot : ISingleItemContainer
    {
        
    }
}