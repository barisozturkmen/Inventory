using System.Collections.Generic;
using System.Linq;
using Inventory;
using Inventory.Interactions;
using NUnit.Framework;
/*
namespace Inventory.Tests
{
    [TestFixture]
    public class SlotContainerTests
    {
        private ISlotContainer _5x5slotContainer;
        private IItem _2x2item;
        private IItem _1x1item;

        [SetUp]
        public void Setup()
        {
            _5x5slotContainer = new SlotContainer("5x5Container", new Dimensions(5, 5));
            
            _2x2item = new Item("2x2Item", new Dimensions(2, 2));
            
            _1x1item = new Item("1x1Item", new Dimensions(1, 1));
        }
        
        [Test]
        public void FindFreeSlots_EnoughSizeAndSpaceInEmptyContainer_ReturnsCorrectSlots()
        {
            // Arrange
            // Check that the slots are at position (0,0), (0,1), (1,0), (1,1)
            Slot[] expectedPositions =
            [
                new Slot(0, 0),
                new Slot(1, 0),
                new Slot(0, 1),
                new Slot(1, 1)
            ];
            
            // Act
            Slot[]? freeSlots = MoveItemService.FindFreeSlots(_2x2item, _5x5slotContainer);

            // Assert
            Assert.That(freeSlots, Is.Not.Null, "Expected not null result.");
            Assert.That(freeSlots, Has.Length.EqualTo(4), "Expected 4 slots for a 2x2 item.");
            Assert.That(freeSlots, Is.EqualTo(expectedPositions), "Slots are not in the expected positions.");
        }
        
        [Test]
        public void FindFreeSlots_EnoughSizeNotSpaceInCrowdedContainer_ReturnsNull()
        {
            // Arrange
            // Fill the container with other items, leaving only 3 free slots
            IItem blockingItem = _1x1item;

            int slotsFilled = 0;
            foreach (Slot slot in _5x5slotContainer.SlotsToItems.Keys)
            {
                if (slotsFilled >= 22) 
                    break; // Leave 3 slots free
                _5x5slotContainer.SlotsToItems[slot] = blockingItem;
                slotsFilled++;
            }

            // Act
            Slot[]? freeSlots = MoveItemService.FindFreeSlots(_2x2item, _5x5slotContainer);

            // Assert
            Assert.That(freeSlots, Is.Null, "Expected no free slots to accommodate the item.");
        }

        [Test]
        public void FindFreeSlots_EnoughSizeAndSpaceAnd_ReturnsCorrectSlots()
        {
            // Arrange
            // Place a blocking item at position (0,0)
            Item blockingItem = new ("Blocking Item", new Dimensions(1, 1));
            Slot blockingSlot = _5x5slotContainer.SlotsToItems.Keys
                .First(s => s.Position == new SlotPosition(0, 0));
            _5x5slotContainer.SlotsToItems[blockingSlot] = blockingItem;

            // Act
            Slot[]? freeSlots = MoveItemService.FindFreeSlots(_2x2item, _5x5slotContainer);

            // Assert
            Assert.That(freeSlots, Is.Not.Null, "Expected to find free slots.");
            Assert.That(freeSlots, Has.Length.EqualTo(4), "Expected 4 slots for a 2x2 item.");

            // Expected positions should now start from (1,0)
            SlotPosition[] expectedPositions =
            [
                new SlotPosition(1, 0),
                new SlotPosition(2, 0),
                new SlotPosition(1, 1),
                new SlotPosition(2, 1)
            ];

            SlotPosition[] actualPositions = freeSlots.Select(s => s.Position).ToArray();

            Assert.That(actualPositions, Is.EqualTo(expectedPositions), "Slots are not in the expected positions.");
        }

        [Test]
        public void FindFreeSlots_MovingItemToOverlapPosition_ReturnsCorrectSlots()
        {
            // Arrange
            // Place the item at position (0,0)
            Slot[]? initialSlots = MoveItemService.FindFreeSlots(_2x2item, _5x5slotContainer);
            foreach (Slot slot in initialSlots)
            {
                _5x5slotContainer.SlotsToItems[slot] = _2x2item;
            }

            // Act
            Slot[]? freeSlots = MoveItemService.FindFreeSlots(_2x2item, _5x5slotContainer);

            // Assert
            Assert.IsNotNull(freeSlots, "Expected to find free slots.");
            Assert.That(freeSlots, Has.Length.EqualTo(4), "Expected 4 slots for a 2x2 item.");

            // Since slots at (2,0) are blocked, the item should overlap its current position
            List<SlotPosition> expectedPositions =
            [
                new SlotPosition(0, 0),
                new SlotPosition(0, 1),
                new SlotPosition(1, 0),
                new SlotPosition(1, 1)
            ];

            List<SlotPosition> actualPositions = freeSlots.Select(s => s.Position).ToList();

            CollectionAssert.AreEquivalent(expectedPositions, actualPositions, "An item should not collide with itself when moving.");
        }

        
    }
}
*/