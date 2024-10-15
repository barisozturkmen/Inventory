using Inventory.ItemCategories;

namespace Inventory.Tests
{
    public class PistolSuppressorAttachment : IPistolMuzzleAttachment
    {
        public string Name { get; } = "Pistol Suppressor";
        public Dimensions ItemDimensions { get; } = new(1, 1);
    }
}