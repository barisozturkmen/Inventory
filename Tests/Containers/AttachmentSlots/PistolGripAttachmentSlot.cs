using System;
using System.Collections.Generic;
using Inventory.Interfaces;

namespace Inventory.Tests
{
    public class PistolGripAttachmentSlot : IAttachmentSlot
    {
        public string Name { get; } = "Pistol Grip Slot";
        public IItem? ContainedItem { get; set; } = null;
        public IEnumerable<Type> AllowedItems { get; } = new [] { typeof(IPistolMuzzleAttachment) };
    }
}