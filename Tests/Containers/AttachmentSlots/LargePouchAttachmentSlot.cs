using System;
using System.Collections.Generic;
using Inventory.Interfaces;

namespace Inventory.Tests
{
    public class LargePouchAttachmentSlot : IAttachmentSlot
    {
        public string Name { get; } = "Large Pouch Slot";
        public IEnumerable<Type> AllowedItems { get; } = new[] { typeof(ILargePouch) };
        public IItem? ContainedItem { get; set; }
    }
}