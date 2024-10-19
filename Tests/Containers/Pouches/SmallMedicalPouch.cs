using Inventory.Abstractions;
using Inventory.ItemCategories;

namespace Inventory.Tests;

public class SmallMedicalPouch: SlotContainerItem, ISmallPouch
{
    public override string Name { get; } = "Small Medical Pouch";
    public override Dimensions ContainerDimensions { get; } = new(1, 2);
    public override Allowed Allowed { get; } = Allowed.Medical;
    public override Dimensions ItemDimensions { get; } = new(1, 2);
}