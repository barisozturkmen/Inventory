using Inventory.Abstractions;
using Inventory.ItemCategories;

namespace Inventory.Tests
{
    public class MediumMedicalPouch : SlotContainerItem, IMediumPouch
    {
        public override string Name { get; } = "Medium Storage Pouch";
        public override Allowed Allowed { get; } = Allowed.All;
        public override Dimensions ItemDimensions { get; } = new(2, 2);
        public override Dimensions ContainerDimensions { get; } = new(2, 2);
    }
}