using Inventory.Abstractions;
using Inventory.ItemCategories;

namespace Inventory.Tests
{
    public class Nails : ICrafting
    {
        public string Name { get; } = "Nails";
        public Dimensions ItemDimensions { get; } = new(1, 1);
    }
}