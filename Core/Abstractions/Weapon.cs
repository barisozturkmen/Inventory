namespace Inventory.Abstractions
{
    public abstract class Weapon : IContainerItem
    {
        public abstract string Name { get; }
        public abstract Dimensions ItemDimensions { get; }
    }
}