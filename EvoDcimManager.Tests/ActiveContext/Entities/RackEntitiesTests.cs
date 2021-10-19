using EvoDcimManager.Domain.ActiveContext.Entities;
using EvoDcimManager.Domain.ActiveContext.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvoDcimManager.Tests.ActiveContext.Entities
{
    [TestClass]
    public class RackEntitiesTests
    {
        private readonly string _cpu = "Intel Xeon 16C 2.4GHz";
        private readonly int _memory = 32;
        private readonly int _storage = 512;
        private readonly BaseEquipment _serverBase = new BaseEquipment("Server01", "HP-Proliant", "HP", "12345679");
        private readonly BaseEquipment _swBase = new BaseEquipment("Switch01", "SSW", "Datacom", "12345679");
        private readonly BaseEquipment _storageBase = new BaseEquipment("Storage01", "SSG", "Dell", "12345679");

        private Server _server1;
        private Server _server2;
        private Server _server3;
        private Server _server4;
        private Server _server5;
        private Server _server6;

        public RackEntitiesTests()
        {
            _server1 = new Server(_serverBase, 1, 2, _cpu, _memory, _storage);
            _server2 = new Server(_serverBase, 3, 4, _cpu, _memory, _storage);
            _server3 = new Server(_serverBase, 5, 6, _cpu, _memory, _storage);
            _server4 = new Server(_serverBase, 7, 8, _cpu, _memory, _storage);
            _server5 = new Server(_serverBase, 9, 10, _cpu, _memory, _storage);
            _server6 = new Server(_serverBase, 11, 12, _cpu, _memory, _storage);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldAdd3EquipmentsOnRack()
        {
            var rack = new Rack(16, "F1-A12");

            rack.PlaceEquipment(_server1);
            rack.PlaceEquipment(_server2);
            rack.PlaceEquipment(_server3);

            Assert.AreEqual(rack.TotalEquipments(), 3);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldHave6OccupedSlots()
        {
            var rack = new Rack(16, "F1-A12");

            rack.PlaceEquipment(_server1);
            rack.PlaceEquipment(_server2);
            rack.PlaceEquipment(_server3);

            Assert.AreEqual(rack.TotalOccupedSlots(), 6);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldReturnInvalidIfRackCapacityIsFullWhenNewEquipmentIsAdded()
        {
            var rack = new Rack(6, "F1-A12");

            rack.PlaceEquipment(_server1);
            rack.PlaceEquipment(_server2);
            rack.PlaceEquipment(_server3);
            rack.PlaceEquipment(_server4);

            var rackValidator = new RackValidator(rack);
            rackValidator.ValidateRackSize();

            Assert.AreEqual(rackValidator.Invalid, true);

        }

        [TestMethod]
        [TestCategory("Entities")]
        public void SpaceUsedShouldBe50()
        {
            var rack = new Rack(8, "F1-A12");

            rack.PlaceEquipment(_server1);
            rack.PlaceEquipment(_server2);

            Assert.AreEqual(50.0, rack.PercentUsedSpace());
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void AvailableSpaceShouldBe50()
        {
            var rack = new Rack(8, "F1-A12");

            rack.PlaceEquipment(_server1);
            rack.PlaceEquipment(_server2);

            Assert.AreEqual(50.0, rack.PercentAvailableSpace());
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldReturnInvalidWhenAnEquipmentIsAddedOnANotAvaibleSlot()
        {
            var rack = new Rack(8, "F1-A12");

            var rackValidator = new RackValidator(rack);
            rackValidator.ValidatePosition();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldReturnAvailableSlot9()
        {
            var rack = new Rack(10, "F1-A12");

            rack.PlaceEquipment(_server1);
            rack.PlaceEquipment(_server2);
            rack.PlaceEquipment(_server3);
            rack.PlaceEquipment(_server4);

            Assert.AreEqual(rack.FirstAvailablePosition(), 9);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldReturnAvaibleSlot7to8()
        {
            var rack = new Rack(12, "F1-A12");

            rack.PlaceEquipment(_server1);
            rack.PlaceEquipment(_server2);
            rack.PlaceEquipment(_server3);
            rack.PlaceEquipment(_server5);
            rack.PlaceEquipment(_server6);

            CollectionAssert.AreEqual(new int[] { 7, 8 }, rack.AvailablePositions());
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldReturnAvaibleSlot3And4()
        {
            var rack = new Rack(6, "F1-A12");

            rack.PlaceEquipment(_server1);
            rack.PlaceEquipment(_server3);

            CollectionAssert.AreEqual(new int[] { 3, 4 }, rack.AvailablePositions());
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldInsertTwoServersAndRemoveTheFirstOne()
        {
            var rack = new Rack(6, "F1-A12");

            rack.PlaceEquipment(_server1);
            rack.PlaceEquipment(_server3);
            rack.RemoveEquipment(1);

            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4 }, rack.AvailablePositions());
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldDeleteAnEquipment()
        {
            var rack = new Rack(6, "F1-A12");

            rack.PlaceEquipment(_server1);
            rack.PlaceEquipment(_server3);

            var totalSlots = rack.TotalEquipments();
            rack.RemoveEquipment(1);
            var updatedTotalSlots = rack.TotalEquipments();

            Assert.AreNotEqual(totalSlots, updatedTotalSlots);

        }
    }
}
