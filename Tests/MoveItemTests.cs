using Inventory.Abstractions;
using Inventory.Interactions;
using Inventory.Services;

namespace Inventory.Tests
{
    [TestFixture]
    public class MoveItemTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void MoveItem_ToSingleContainer_Successful()
        {
            // Arrange
            var pistolCompensator = new PistolCompensatorAttachment();
            var pistol = new Pistol();
            InteractionSelection selection = new(pistolCompensator, ActionOption.Move);
            CompleteDestination completeDestination = new SingleContainerDestination(
                pistol.AttachmentSlots.First(s => s is PistolMuzzleAttachmentSlot));

            // Act
            MoveItemService.MoveItem(selection, completeDestination);

            IItem? result = pistol.AttachmentSlots
                                  .First(s => s is PistolMuzzleAttachmentSlot).ContainedItem;
            
            // Assert
            Assert.That(result, Is.EqualTo(pistolCompensator), "Expected item to move to valid, empty slot.");
        }

        [Test]
        public void MoveItem_WithinSlotContainer_Successful()
        {
            // Arrange
            var nails = new Nails();
            var backpack = new Backpack();
            backpack.SlotsToItems[new Slot(0, 0)] = nails;
            InteractionSelection selection = new (nails, ActionOption.Move, backpack);
            CompleteDestination completeDestination = new SlotsDestination(backpack, [new Slot(2, 2)]);
            
            // Act
            MoveItemService.MoveItem(selection, completeDestination);

            // Assert
            Assert.That(backpack.SlotsToItems[new Slot(2,2)], Is.EqualTo(nails), "Expected item to be found in destination slot.");
            Assert.That(backpack.SlotsToItems[new Slot(0,0)], Is.Null, "Expected item to be removed from original position after moving.");
        }

        [Test]
        public void MoveItem_ToRestrictedContainer_Fails()
        {
            // Arrange
            var medicalPouch = new SmallMedicalPouch();
            var nails = new Nails();
            
            InteractionSelection selection = new(nails, ActionOption.Move);
            CompleteDestination completeDestination = new SlotsDestination(medicalPouch, [new Slot(0, 0)]);

            // Act
            bool isValid = MoveItemService.ValidateMoveOption(selection.Item, completeDestination);

            // Assert
            Assert.That(isValid, Is.False, "Expected the move to fail due to restriction.");
            Assert.That(medicalPouch.SlotsToItems[new Slot(0, 0)], Is.Null, "The slot should remain empty.");
        }

        [Test]
        public void MoveItem_ToOccupiedPositionInSlotContainer_Fails()
        {
            // Arrange
            var smallPouch = new SmallStoragePouch();
            var bandage = new ImprovisedBandage();
            var nails = new Nails();
            smallPouch.SlotsToItems[new Slot(0, 0)] = bandage;

            InteractionSelection selection = new(nails, ActionOption.Move);
            CompleteDestination completeDestination = new SlotsDestination(smallPouch, [new Slot(0, 0)]);

            // Act
            bool isValid = MoveItemService.ValidateMoveOption(selection.Item, completeDestination);

            // Assert
            Assert.That(isValid, Is.False, "Expected the move to fail due destination being occupied.");
        }
        
        [Test]
        public void MoveItem_ItemExceedsContainerDimensions_Fails()
        {
            // Arrange
            var carBattery = new CarBattery();
            var smallPouch = new SmallStoragePouch();
            Slot[] destination =
            [
                new Slot(0, 0),
                new Slot(0, 1),
                new Slot(0, 2),
                new Slot(1, 0),
                new Slot(1, 1),
                new Slot(1, 2)
            ];
            CompleteDestination completeDestination = new SlotsDestination(smallPouch, destination);

            // Act
            bool isValid = MoveItemService.ValidateMoveOption(carBattery, completeDestination);

            // Assert
            Assert.That(isValid, Is.False, "Expected the move to fail because the item exceeds container dimensions.");
        }

        [Test]
        public void MoveItem_DestinationExtendsBeyondContainerBoundaries_Fails()
        {
            // Arrange
            var carBattery = new CarBattery();
            var backpack = new Backpack();
            Slot[] destination =
            [
                new Slot(3, 0),
                new Slot(3, 0),
                new Slot(4, 0),
                new Slot(4, 1),
                new Slot(5, 1),
                new Slot(5, 1)
            ];
            CompleteDestination completeDestination = new SlotsDestination(backpack, destination);

            // Act
            bool isValid = MoveItemService.ValidateMoveOption(carBattery, completeDestination);

            // Assert
            Assert.That(isValid, Is.False, "Expected the move to fail because the item extends beyond container boundaries.");
        }
        
        [Test]
        public void MoveItem_ToOccupiedAttachmentSlot_Fails()
        {
            // Arrange
            var pistol = new Pistol();
            var existingAttachment = new PistolCompensatorAttachment();
            var newAttachment = new PistolSuppressorAttachment();
            AttachmentSlot muzzleSlot = pistol.AttachmentSlots.First(s => s is PistolMuzzleAttachmentSlot);
            muzzleSlot.AddItem(existingAttachment, new SingleContainerDestination(muzzleSlot));
            CompleteDestination completeDestination = new SingleContainerDestination(muzzleSlot);

            // Act
            bool isValid = MoveItemService.ValidateMoveOption(newAttachment, completeDestination);
            
            // Assert
            Assert.That(isValid, Is.False, "Expected the move to fail because the attachment slot is occupied.");
        }

        [Test]
        public void MoveItem_ToIncompatibleAttachmentSlot_Fails()
        {
            // Arrange
            var pistol = new Pistol();
            var gripAttachment = new PistolMainGripAttachment();
            AttachmentSlot muzzleSlot = pistol.AttachmentSlots.First(s => s is PistolMuzzleAttachmentSlot);
            CompleteDestination completeDestination = new SingleContainerDestination(muzzleSlot);

            // Act
            bool isValid = MoveItemService.ValidateMoveOption(gripAttachment, completeDestination);

            // Assert
            Assert.That(isValid, Is.False, "Expected the move to fail due to incompatible attachment slot.");
        }
        
        [Test]
        public void MoveItem_OverlappingExistingItems_Fails()
        {
            // Arrange
            var backpack = new Backpack();
            var bandage = new ImprovisedBandage();
            var pistol = new Pistol();
            backpack.SlotsToItems[new Slot(1, 1)] = bandage;
            CompleteDestination completeDestination = new SlotsDestination(backpack, 
                [new Slot(1, 1), new Slot(1, 2)]);

            // Act
            bool isValid = MoveItemService.ValidateMoveOption(pistol, completeDestination);

            // Assert
            Assert.That(isValid, Is.False, "Expected the move to fail due to overlapping items.");
        }
    }
}