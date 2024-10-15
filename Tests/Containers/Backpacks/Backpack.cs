using Inventory.Abstractions;
using Inventory.ItemCategories;

namespace Inventory.Tests
{
    public class Backpack : SlotContainerItem, IBackpack
    {
        public override string Name { get; } = "Backpack";
        public override Dimensions ContainerDimensions { get; } = new(5, 5);
        public override Allowed Allowed { get; } = Allowed.All;
        public override Dimensions ItemDimensions { get; } = new(5, 5);
    }
}