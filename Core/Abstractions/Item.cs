namespace Inventory.Abstractions
{
    public abstract class Item : IItem
    {
        public abstract string Name { get; }
        public abstract Dimensions ItemDimensions { get; }
    }
}