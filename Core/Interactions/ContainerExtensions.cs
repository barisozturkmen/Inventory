using System.Collections.Generic;
using System.Linq;
using Inventory.Interfaces;

namespace Inventory.Interactions
{
    public static class ContainerExtensions
    {
        public static IEnumerable<IContainer> GetSubContainers(this IContainer container)
        {
            List<IContainer> subContainers = new();

            if (container is ICharacterInventory characterInventory)
            {
                subContainers.AddRange(characterInventory.EquipmentSlots
                    .Where(slot => slot.ContainedItem is IContainerItem)
                    .Select(slot => (IContainer)slot.ContainedItem!));
            }

            if (container is IAttachmentContainerItem attachmentContainerItem)
            {
                subContainers.AddRange(attachmentContainerItem.AttachmentSlots
                    .Where(slot => slot.ContainedItem is IContainerItem)
                    .Select(slot => (IContainer)slot.ContainedItem!));
            }

            if (container is ISegmentedContainer segmentedContainer)
            {
                subContainers.AddRange(segmentedContainer.SubContainers);
            }

            if (container is ISlotContainer slotContainer)
            {
                subContainers.AddRange(slotContainer.SlotsToItems.Values
                    .Where(item => item is IContainerItem)
                    .Select(item => (IContainer)item!));
            }

            return subContainers;
        }
    }
}