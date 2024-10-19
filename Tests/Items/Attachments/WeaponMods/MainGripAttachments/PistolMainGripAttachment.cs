using Inventory.ItemCategories;

namespace Inventory.Tests
{
    public class PistolMainGripAttachment : IPistolGripAttachment
    {
        public string Name { get; } = "Custom Grip";
        public Dimensions ItemDimensions { get; } = new(1, 1);
    }
}