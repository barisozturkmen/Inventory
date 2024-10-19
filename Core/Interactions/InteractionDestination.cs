using Inventory.Abstractions;

namespace Inventory.Interactions
{
    public abstract class InteractionDestination
    {
        public IInteractionTarget Target { get; protected init; }

        protected InteractionDestination(IInteractionTarget target)
        {
            Target = target;
        }
    }

    public abstract class CompleteDestination : InteractionDestination
    {
        protected CompleteDestination(IInteractionTarget target) 
            : base(target)
        {
            
        }
    }
    
    public abstract class PartialDestination : InteractionDestination
    {
        protected PartialDestination(IInteractionTarget target) 
            : base(target)
        {
            
        }
    }
    
    public abstract class InvalidDestination : InteractionDestination
    {
        protected InvalidDestination(IInteractionTarget target) 
            : base(target)
        {
            
        }
    }
    
    /// <summary>
    /// When the target is a single item container such as a
    /// character equipment slot or attachment slot.
    /// </summary>
    public class SingleContainerDestination : CompleteDestination
    {
        public SingleContainerDestination(SingleContainer target) 
            : base(target)
        {
            Target = target;
        }
    }

    /// <summary>
    /// When the target are a slot group such as
    /// moving item to specific slot location in
    /// a slot container.
    /// </summary>
    public class SlotsDestination : CompleteDestination
    {
        public Slot[] TargetSlots { get; set; }

        public SlotsDestination(SlotContainer target, Slot[] targetSlots) 
            : base(target)
        {
            Target = target;
            TargetSlots = targetSlots;
        }
    }
    
    public class ContainerItemDestination : PartialDestination
    {
        public IContainerItem TargetItem { get; set; }

        public ContainerItemDestination(IContainerItem targetItem) 
            : base(targetItem)
        {
            TargetItem = targetItem;
        }
    }
    

    /*/// <summary>
    /// When the item moved is stackable and the target
    /// can be multiple positions such as a stackable item
    /// which completes a stack in one slot group, and places
    /// the excess in another slot group.
    /// </summary>
    public class StackableItemSlotsTarget : ToSlotsTarget
    {
        public Slot[][] Targets { get; set; }

        public StackableItemSlotsTarget(Slot[][] targets)
        {
            Targets = targets;
        }
    }*/

    /// <summary>
    /// When an item is moved to a container item,
    /// not a specific slot group and a slot group is
    /// found in nested containers.
    /// </summary>
    //public class AddressPath
    //{
    //    public Stack<IContainer> Path { get; set; }
    //    public Slot[] TargetSlots { get; set; }
    //}

    /// <summary>
    /// When a stackable item is moved to a container,
    /// requiring nested searching and multiple partial,
    /// stacks can be completed in different paths.
    /// </summary>
    //public class MultiAddressPath : ToContainerTarget
    //{
    //    public AddressPath[] Paths { get; set; }
    //}
}