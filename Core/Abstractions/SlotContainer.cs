using Inventory.Interactions;

namespace Inventory.Abstractions
{
    public abstract class SlotContainer : ISlotContainer
    {
        public abstract string Name { get; }
        public abstract Dimensions ContainerDimensions { get; }
        public Dictionary<Slot, IItem?> SlotsToItems { get; }

        protected SlotContainer()
        {
            int columns = ContainerDimensions.Columns;
            int rows = ContainerDimensions.Rows;
            Dictionary<Slot, IItem?> dictionary = new(columns * rows);
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    var position = new SlotPosition(col, row);
                    var slot = new Slot(position);
                    dictionary.Add(slot, null);
                }
            }

            SlotsToItems = new Dictionary<Slot, IItem?>(dictionary);
        }
        
        public bool AddItem(IItem item, InteractionDestination destination)
        {
            if (destination is not SlotsDestination slotContainerDestination)
                throw new ArgumentException("Invalid InteractionDestination type for SlotsDestination.");
            
            foreach (Slot slot in slotContainerDestination.TargetSlots)
            {
                SlotsToItems[slot] = item;
            }
            
            return true;
        }

        public bool RemoveItem(IItem item)
        {
            foreach (KeyValuePair<Slot, IItem?> kvp in SlotsToItems
                .Where(kvp => kvp.Value == item))
            {
                SlotsToItems[kvp.Key] = null;
            }

            return true;
        }
    }
}