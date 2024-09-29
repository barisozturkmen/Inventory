using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Inventory.Interfaces
{
    public interface IContainer : IInteractionTarget, INamed
    {

    }

    public interface ISlotContainer : IContainer
    {
        Dimensions ContainerDimensions { get; }
        ReadOnlyDictionary<Slot, IItem?> SlotsToItems { get; }
    }

    public interface IRestrictedContainer : IContainer
    {
        IEnumerable<Type> AllowedItems { get; }
        bool IsItemAllowed(IItem item)
        {
            return AllowedItems.Any(type => type.IsInstanceOfType(item));
        }
    }

    public interface ISegmentedContainer : IContainer
    {
        IEnumerable<ISlotContainer> SubContainers { get; }
    }
}