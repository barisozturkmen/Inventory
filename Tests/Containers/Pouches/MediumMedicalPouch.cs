using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Inventory.Interfaces;

namespace Inventory.Tests
{
    public class MediumMedicalPouch : IMediumPouch
    {
        public string Name { get; } = "MedicalPouch";
        public Dimensions ItemDimensions { get; } = new(2, 2);
        public IEnumerable<Type> AllowedItems { get; } = new [] { typeof(IMedicalItem) };
        public Dimensions ContainerDimensions { get; } = new(2, 2);
        public ReadOnlyDictionary<Slot, IItem?> SlotsToItems { get; }

        public MediumMedicalPouch()
        {
            Dictionary<Slot, IItem?> dictionary = new(ItemDimensions.Columns * ItemDimensions.Rows);
            for (int row = 0; row < ItemDimensions.Rows; row++)
            {
                for (int col = 0; col < ItemDimensions.Columns; col++)
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