using Inventory.Abstractions;
using Inventory.ItemCategories;

namespace Inventory.Tests
{
    public class ImprovisedBandage : IItem, IBandage
    {
        public string Name { get; } = "Bandage";
        public Dimensions ItemDimensions { get; } = new(1, 1);
    }
}