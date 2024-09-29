using System;
using System.Collections.Generic;
using Inventory.Interfaces;

namespace Inventory.Tests
{
    public class MediumPouchAttachmentSlot : IAttachmentSlot
    {
        public string Name { get; } = "Medium Pouch Slot";
        public IItem? ContainedItem { get; set; } = null;
        public IEnumerable<Type> AllowedItems { get; } = new[] { typeof(IMediumPouch) };
    }
}