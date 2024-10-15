using Inventory.Abstractions;
using Inventory.ItemCategories;

namespace Inventory.Tests.Items.Crafting
{
    public class Nails : IItem, ICrafting
    {
        public string Name { get; } = "Nails";
        public Dimensions ItemDimensions { get; } = new(1, 1);
    }
}