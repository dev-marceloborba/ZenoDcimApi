using EvoDcimManager.Domain.ActiveContext.Entities;
using EvoDcimManager.Domain.ActiveContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvoDcimManager.Tests.ActiveContext.Entities
{
    [TestClass]
    public class RackEntitiesTests
    {

        private readonly Cpu _cpu = new Cpu("Intel Xeon 16C 2.4GHz");
        private readonly Memory _memory = new Memory(32);
        private readonly Capacity _storage = new Capacity(512);
        private readonly BaseEquipment _serverBase = new BaseEquipment("Server01", "HP-Proliant", "HP", "12345679");
        private readonly BaseEquipment _swBase = new BaseEquipment("Switch01", "SSW", "Datacom", "12345679");
        private readonly BaseEquipment _storageBase = new BaseEquipment("Storage01", "SSG", "Dell", "12345679");
        private readonly RackSlot _rackSlot = new RackSlot(1, 2);

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldAdd6SlotsOnRack()
        {
            var server = new Server(_serverBase, _rackSlot, _cpu, _memory, _storage);
            var sw1 = new Switch(_swBase, _rackSlot, 64);
            var storage = new Storage(_storageBase, _rackSlot, _storage);

            var rack = new Rack(16, "F1-A12");
            rack.AddEquipment(server, 1);
            rack.AddEquipment(sw1, 3);
            rack.AddEquipment(storage, 5);

            Assert.AreEqual(rack.OccupedSlots, 6);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldReturnInvalidIfRackCapacityIsFullWhenNewEquipmentIsAdded()
        {
            var server = new Server(_serverBase, _rackSlot, _cpu, _memory, _storage);
            var sw1 = new Switch(_swBase, _rackSlot, 64);
            var storage = new Storage(_storageBase, _rackSlot, _storage);

            var rack = new Rack(2, "F1-A12");
            rack.AddEquipment(server, 1);
            rack.AddEquipment(sw1, 3);
            rack.AddEquipment(storage, 5);

            Assert.AreEqual(rack.Invalid, true);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void SpaceUsedShouldBe50()
        {
            var server1 = new Server(_serverBase, _rackSlot, _cpu, _memory, _storage);
            var sw1 = new Switch(_swBase, _rackSlot, 64);
            var storage1 = new Storage(_storageBase, _rackSlot, _storage);

            var server2 = new Server(_serverBase, _rackSlot, _cpu, _memory, _storage);
            var sw2 = new Switch(_swBase, _rackSlot, 64);
            var storage2 = new Storage(_storageBase, _rackSlot, _storage);

            var rack = new Rack(24, "F1-A12");
            rack.AddEquipment(server1, 1);
            rack.AddEquipment(sw1, 3);
            rack.AddEquipment(storage1, 5);

            rack.AddEquipment(server2, 7);
            rack.AddEquipment(sw2, 9);
            rack.AddEquipment(storage2, 11);

            Assert.AreEqual(50.0, rack.RackSpaceUsage());

        }

        [TestMethod]
        [TestCategory("Entities")]
        public void AvailableSpaceShouldBe50()
        {
            var server1 = new Server(_serverBase, _rackSlot, _cpu, _memory, _storage);
            var sw1 = new Switch(_swBase, _rackSlot, 64);
            var storage1 = new Storage(_storageBase, _rackSlot, _storage);

            var server2 = new Server(_serverBase, _rackSlot, _cpu, _memory, _storage);
            var sw2 = new Switch(_swBase, _rackSlot, 64);
            var storage2 = new Storage(_storageBase, _rackSlot, _storage);

            var rack = new Rack(24, "F1-A12");
            rack.AddEquipment(server1, 1);
            rack.AddEquipment(sw1, 3);
            rack.AddEquipment(storage1, 5);

            rack.AddEquipment(server2, 7);
            rack.AddEquipment(sw2, 9);
            rack.AddEquipment(storage2, 11);

            Assert.AreEqual(50.0, rack.RackFreeSpaceUsage());

        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldReturnInvalidWhenAnEquipmentIsAddedOnANotAvaibleSlot()
        {
            var server1 = new Server(_serverBase, _rackSlot, _cpu, _memory, _storage);
            var sw1 = new Switch(_swBase, _rackSlot, 64);
            var rack = new Rack(2, "F1-A12");
            rack.AddEquipment(server1, 1);
            rack.AddEquipment(sw1, 1);
            Assert.AreEqual(rack.Invalid, true);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldReturnAvailableSlot9()
        {
            var server1 = new Server(_serverBase, _rackSlot, _cpu, _memory, _storage);
            var sw1 = new Switch(_swBase, _rackSlot, 64);
            var server2 = new Server(_serverBase, _rackSlot, _cpu, _memory, _storage);
            var sw2 = new Switch(_swBase, _rackSlot, 64);
            var rack = new Rack(12, "F1-A12");

            rack.AddEquipment(server1, 1);
            rack.AddEquipment(server2, 3);
            rack.AddEquipment(sw1, 5);
            rack.AddEquipment(sw2, 7);

            Assert.AreEqual(rack.NextAvaiblePosition(), 9);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldReturnAvaibleSlot7to8()
        {
            var server1 = new Server(_serverBase, _rackSlot, _cpu, _memory, _storage);
            var server2 = new Server(_serverBase, _rackSlot, _cpu, _memory, _storage);
            var server3 = new Server(_serverBase, _rackSlot, _cpu, _memory, _storage);
            var server4 = new Server(_serverBase, _rackSlot, _cpu, _memory, _storage);
            var server5 = new Server(_serverBase, _rackSlot, _cpu, _memory, _storage);

            var rack = new Rack(12, "F1-A12");
            rack.AddEquipment(server1, 1);
            rack.AddEquipment(server2, 3);
            rack.AddEquipment(server3, 5);

            rack.AddEquipment(server4, 9);
            rack.AddEquipment(server5, 11);
            CollectionAssert.AreEqual(new int[] { 7, 8 }, rack.AvailablePositions());

        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldReturnAvaibleSlot3And5()
        {
            var server1 = new Server(_serverBase, _rackSlot, _cpu, _memory, _storage);
            var server2 = new Server(_serverBase, _rackSlot, _cpu, _memory, _storage);

            var rack = new Rack(6, "F1-A12");
            rack.AddEquipment(server1, 1);
            rack.AddEquipment(server2, 5);

            CollectionAssert.AreEqual(new int[] { 3, 4 }, rack.AvailablePositions());

        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldDeleteAnEquipment()
        {

            var server1 = new Server(_serverBase, _rackSlot, _cpu, _memory, _storage);
            var server2 = new Server(_serverBase, _rackSlot, _cpu, _memory, _storage);

            var rack = new Rack(4, "F1-A12");
            rack.AddEquipment(server1, 1);
            rack.AddEquipment(server2, 3);

            var totalSlots = rack.OccupedSlots;
            rack.RemoveEquipment(3, server2);
            var updatedTotalSlots = rack.OccupedSlots;

            Assert.AreNotEqual(totalSlots, updatedTotalSlots);

        }

    }
}
