namespace Inventory.Tests
{
    public class PistolCompensatorAttachment : IPistolMuzzleAttachment
    {
        public string Name { get; } = "Compensator";
        public Dimensions ItemDimensions { get; } = new(1, 1);
    }
}