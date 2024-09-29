namespace Inventory.Tests
{
    public class PistolSuppressorAttachment : IPistolMuzzleAttachment
    {
        public string Name { get; } = "Suppressor";
        public Dimensions ItemDimensions { get; } = new(1, 1);
    }
}