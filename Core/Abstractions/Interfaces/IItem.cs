namespace Inventory.Abstractions
{
    public interface IItem : IInteractionTarget, INamed
    {
        Dimensions ItemDimensions { get; }
    }

    public interface IStackable : IItem
    {
        int MaxStack { get; }
        int Quantity { get; set; }
    }

    public interface ITransformable : IItem
    {
        /// <summary>
        /// Collection of types which can be combined with this item
        /// </summary>
        IEnumerable<Type> CombinableWith { get; }
        void CombineWith(IItem item);
    }
    
    public interface IAttachment : IItem
    {
        
    }
}

