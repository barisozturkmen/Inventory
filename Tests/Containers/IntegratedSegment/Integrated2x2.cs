using Inventory.Abstractions;

namespace Inventory.Tests
{
    public class Integrated2x2 : SlotContainer, IRestrictedContainer
    {
        public override string Name { get; } = "Integrated Pouch";
        public override Dimensions ContainerDimensions { get; } = new(2, 2);
        public Allowed Allowed { get; } = Allowed.All;
    }
}