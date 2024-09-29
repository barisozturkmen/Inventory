using System.Collections.Generic;
using System.Linq;
using Inventory;
using Inventory.Interactions;
using Inventory.Interfaces;
using NUnit.Framework;

namespace Inventory.Tests
{
    [TestFixture]
    public class SlotContainerTests
    {
        private ItemInteractionService _interactionService;
        private ISlotContainer _slotContainer;
        private IItem _item;

        [SetUp]
        public void Setup()
        {
            _interactionService = new ItemInteractionService();

            // Create a slot container of size 5x5
            _slotContainer = new SlotContainer("5x5Container", new Dimensions(5, 5));

            // Create an item of size 2x2
            _item = new Item("2x2Item", new Dimensions(2, 2));
        }
        
        [Test]
        public void FindFreeSlotsForItem_ItemFitsInEmptyContainer_ReturnsSlots()
        {
            // Arrange
            // Check that the slots are at position (0,0), (0,1), (1,0), (1,1)
            Slot[] expectedPositions = new Slot[]
            {
                new(0, 0),
                new(1, 0),
                new(0, 1),
                new(1, 1)
            };
            
            // Act
            Slot[]? freeSlots = ItemInteractionService.FindFreeSlotsForItem(_item, _slotContainer);

            // Assert
            Assert.That(freeSlots, Is.Not.Null, "freeSlots was null.");
            Assert.That(freeSlots, Has.Length.EqualTo(4), "Expected 4 slots for a 2x2 item.");
            Assert.That(freeSlots, Is.EqualTo(expectedPositions), "Slots are not in the expected positions.");
        }

        
    }
}