

using Inventory.Interactions;
using Inventory.Services;
using Inventory.Tests.Items.Crafting;

namespace Inventory.Tests
{
    [TestFixture]
    public class MoveItemTests
    {
        private ItemInteractionService _itemService;
        private Backpack _backpack5x5;
        private Nails _nails1x1;
        //private IItem _1x1item;

        [SetUp]
        public void Setup()
        {
            _itemService = new ItemInteractionService();
                
            _backpack5x5 = new Backpack();
            
            //_2x2item = new Item("2x2Item", new Dimensions(2, 2));
            
            _nails1x1 = new Nails();
            
            
        }

        [Test]
        public void MoveItemInSlotContainer_WithinContainer_ItemMovedSuccessfully()
        {
            // Arrange
            _backpack5x5.SlotsToItems[new Slot(0, 0)] = _nails1x1;
            InteractionSelection selection = new (_nails1x1, ActionOption.Move, _backpack5x5);
            KnownDestination knownDestination = new SlotsDestination(_backpack5x5, [new Slot(2, 2)]);
            
            // Act
            _itemService.HandleSelect(selection);
            _itemService.HandleTargetOption(selection, knownDestination);
            _itemService.HandleExecute(selection, knownDestination);

            // Assert
            Assert.That(_backpack5x5.SlotsToItems[new Slot(2,2)], Is.EqualTo(_nails1x1));
            Assert.That(_backpack5x5.SlotsToItems[new Slot(0,0)], Is.Null);
        }

        
        
    }

}