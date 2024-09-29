using System.Collections.Generic;

namespace Inventory.Interfaces
{
    public interface ICharacterInventory : IContainer
    {
        IEnumerable<IEquipmentSlot> EquipmentSlots { get; }
    }
}