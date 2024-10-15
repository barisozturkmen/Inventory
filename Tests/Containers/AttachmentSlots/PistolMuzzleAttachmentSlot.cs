using Inventory.Abstractions;
using Inventory.ItemCategories;

namespace Inventory.Tests
{
    public class PistolMuzzleAttachmentSlot : AttachmentSlot
    {
        public override string Name { get; protected init; } = "Muzzle Slot";
        public override Allowed Allowed { get; protected init; } = Allowed.PistolMuzzle;
    }
}