using System.Collections.Generic;
using System.Collections.ObjectModel;
using Inventory.Interfaces;

namespace Inventory
{
    public class SlotContainer : ISlotContainer
    {
        public string Name { get; }
        public Dimensions ContainerDimensions { get; }
        public ReadOnlyDictionary<Slot, IItem?> SlotsToItems { get; }

        public SlotContainer(string name, Dimensions dimensions)
        {
            Name = name;
            ContainerDimensions = dimensions;

            Dictionary<Slot, IItem?> dictionary = new(dimensions.Columns * dimensions.Rows);
            for (int row = 0; row < dimensions.Rows; row++)
            {
                for (int col = 0; col < dimensions.Columns; col++)
                {
                    var position = new SlotPosition(col, row);
                    var slot = new Slot(position);
                    dictionary.Add(slot, null);
                }
            }

            SlotsToItems = new ReadOnlyDictionary<Slot, IItem?>(dictionary);
        }
    }
}