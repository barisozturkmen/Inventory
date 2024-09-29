using System;
using System.Collections.Generic;
using Inventory.Interfaces;

namespace Inventory.Tests
{
    public class SmallPouchAttachmentSlot : IAttachmentSlot
    {
        public string Name { get; } = "Small Pouch Slot";
        public IItem? ContainedItem { get; set; } = null;
        public IEnumerable<Type> AllowedItems { get; } = new[] { typeof(ISmallPouch) };
    }
}