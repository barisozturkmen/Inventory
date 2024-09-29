using System;
using System.Collections.Generic;
using Inventory.Interfaces;

namespace Inventory.Tests
{
    public class PistolMuzzleAttachmentSlot : IAttachmentSlot
    {
        public IItem? ContainedItem { get; set; }
        public string Name { get; } = "Muzzle Slot";
        public IEnumerable<Type> AllowedItems { get; } = new [] { typeof(IPistolMuzzleAttachment) };
    }
}