using Inventory.Abstractions;

namespace Inventory.Tests
{
    public class Pistol : ModableWeapon
    {
        public override string Name { get; } = "Pistol";
        public override Dimensions ItemDimensions { get; } = new(1, 2);
        public List<AttachmentSlot> AttachmentSlots { get; } =
            [
                new PistolMuzzleAttachmentSlot(), 
                new PistolGripAttachmentSlot()
            ];
    }
}