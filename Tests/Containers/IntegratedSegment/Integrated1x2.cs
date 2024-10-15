using Inventory.Abstractions;

namespace Inventory.Tests
{
    public class Integrated1x2 : SlotContainer, IRestrictedContainer
    {
        public override string Name { get; } = "Integrated Pouch";
        public override Dimensions ContainerDimensions { get; } = new(1, 2);
        public Allowed Allowed { get; } = Allowed.All;
    }
}