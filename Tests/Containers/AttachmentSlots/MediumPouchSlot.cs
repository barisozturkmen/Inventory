using Inventory.Abstractions;
using Inventory.ItemCategories;

namespace Inventory.Tests
{
    public class MediumPouchSlot : AttachmentSlot
    {
        public override string Name { get; protected init; } = "Medium Pouch Slot";
        public override Allowed Allowed { get; protected init; } = Allowed.MediumPouches;
    }
}