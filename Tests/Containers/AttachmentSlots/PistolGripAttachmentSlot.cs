using Inventory.Abstractions;
using Inventory.ItemCategories;

namespace Inventory.Tests
{
    public class PistolGripAttachmentSlot : AttachmentSlot
    {
        public override string Name { get; protected init; } = "Pistol Grip Slot";
        public override Allowed Allowed { get; protected init; } = Allowed.PistolMainGrips;
    }
}