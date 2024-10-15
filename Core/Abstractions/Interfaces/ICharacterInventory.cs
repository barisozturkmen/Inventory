namespace Inventory.Abstractions
{
    public interface ICharacterInventory : IContainer
    {
        List<EquipmentSlot> EquipmentSlots { get; }
    }
}