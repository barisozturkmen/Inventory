namespace Inventory.Abstractions
{
    /// <summary>
    /// Eg: Most bags, most pouches, some tactical rigs
    /// </summary>
    public abstract class SlotContainerItem : SlotContainer, IRestrictedContainer, IItem
    {
        public abstract Allowed Allowed { get; }
        public abstract Dimensions ItemDimensions { get; }
    }
}