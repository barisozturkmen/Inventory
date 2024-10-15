using Inventory.Abstractions;

namespace Inventory.Tests
{
    public class TacticalRig : ComplexContainer
    {
        public override string Name { get; } = "Tactical Rig";

        public override List<ISlotContainer> SubContainers { get; } =
        [
            new Integrated1x2(),
            new Integrated1x2(),
            new Integrated1x2(),
            new Integrated2x2()
        ];

        public override Dimensions ItemDimensions { get; } = new(3, 3);

        public override List<AttachmentSlot> AttachmentSlots { get; } =
        [
            new SmallPouchAttachmentSlot(),
            new MediumPouchSlot(),
            new LargePouchSlot()
        ];
    }
}