using System.Collections.Generic;
using Inventory.Interfaces;

namespace Inventory.Tests
{
    public class Pistol : IWeapon
    {
        public string Name { get; } = "Pistol";
        public Dimensions ItemDimensions { get; } = new(1, 2);
        public IEnumerable<IAttachmentSlot> AttachmentSlots { get; } = new IAttachmentSlot[]
            { new PistolMuzzleAttachmentSlot(), new PistolGripAttachmentSlot() };
    }
}