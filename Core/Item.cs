using Inventory.Interfaces;

namespace Inventory
{
    public class Item : IItem
    {
        public string Name { get; }
        public Dimensions ItemDimensions { get; }

        public Item(string name, Dimensions dimensions)
        {
            Name = name;
            ItemDimensions = dimensions;
        }
    }
}