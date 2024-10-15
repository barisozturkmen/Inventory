using Inventory.Interactions;

namespace Inventory.Abstractions
{
    public interface IContainer : IInteractionTarget, INamed
    {

    }

    public interface IManagedContainer : IContainer
    {
        bool AddItem(IItem item, InteractionDestination destination);
        bool RemoveItem(IItem item);
    }

    public interface ISlotContainer : IManagedContainer
    {
        Dimensions ContainerDimensions { get; }
        Dictionary<Slot, IItem?> SlotsToItems { get; }
    }

    public interface IRestrictedContainer : IManagedContainer
    {
        Allowed Allowed { get; }
    }

    public interface ISingleContainer : IRestrictedContainer
    {
        IItem? ContainedItem { get; }
        bool Occupied { get; }
    }

    public interface ISegmentedContainer : IContainer
    {
        List<ISlotContainer> SubContainers { get; }
    }
}