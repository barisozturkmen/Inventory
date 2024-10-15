using Inventory.Abstractions;
using Inventory.ItemCategories;

namespace Inventory.Tests
{
    public class SmallStoragePouch : SlotContainerItem, ISmallPouch
    {
        public override string Name { get; } = "Small Storage Pouch";
        public override Allowed Allowed { get; } = Allowed.All;
        public override Dimensions ItemDimensions { get; } = new(1, 2);
        public override Dimensions ContainerDimensions { get; } = new(1, 2);
    }
}