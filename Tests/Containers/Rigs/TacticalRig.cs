using System;
using System.Collections.Generic;
using Inventory;
using Inventory.Interfaces;

namespace Inventory.Tests
{
    public class TacticalRig : ISegmentedContainer, IAttachmentContainerItem
    {
        public string Name { get; } = "Tactical Rig";
        public IEnumerable<ISlotContainer> SubContainers { get; } = new[] 
        { 
            new SlotContainer(
                "Integrated Pouch", 
                new Dimensions(3,2)) 
        };

        public Dimensions ItemDimensions { get; } = new(3, 3);
        public IEnumerable<Type> AllowedItems { get; } = new[] { typeof(IItem) };

        public IEnumerable<IAttachmentSlot> AttachmentSlots { get; } = new IAttachmentSlot[]
        {
            new SmallPouchAttachmentSlot(),
            new MediumPouchAttachmentSlot(),
            new LargePouchAttachmentSlot()
        };
    }
}