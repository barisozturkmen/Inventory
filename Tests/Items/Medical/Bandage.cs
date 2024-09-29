namespace Inventory.Tests
{
    public class Bandage : IMedicalItem
    {
        public string Name { get; } = "Bandage";
        public Dimensions ItemDimensions { get; } = new(1, 1);
    }
}