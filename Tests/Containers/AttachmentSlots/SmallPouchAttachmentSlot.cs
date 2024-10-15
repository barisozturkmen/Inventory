using Inventory.Abstractions;

namespace Inventory.Tests
{
    public class SmallPouchAttachmentSlot : AttachmentSlot
    {
        public override string Name { get; protected init; } = "Small Pouch Slot";
        public override Allowed Allowed { get; protected init; } = Allowed.SmallPouches;
    }
}