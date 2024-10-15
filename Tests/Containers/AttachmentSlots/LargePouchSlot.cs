using Inventory.Abstractions;

namespace Inventory.Tests
{
    public class LargePouchSlot : AttachmentSlot
    {
        public override string Name { get; protected init; } = "Large Pouch Slot";
        public override Allowed Allowed { get; protected init; } = Allowed.AllPouches;
    }
}