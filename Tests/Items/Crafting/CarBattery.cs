using Inventory.Abstractions;
using Inventory.ItemCategories;

namespace Inventory.Tests
{
    public class CarBattery : ICrafting
    {
        public string Name { get; } = "Car Battery";
        public Dimensions ItemDimensions { get; } = new(3, 2);
    }
}