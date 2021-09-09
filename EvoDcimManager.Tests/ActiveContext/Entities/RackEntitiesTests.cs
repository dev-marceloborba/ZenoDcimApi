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
        private readonly Capacity _occupation = new Capacity(1);

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldAdd3EquipmentsOnRack()
        {
            var server = new Server(_serverBase, _occupation, _cpu, _memory, _storage);
            var sw1 = new Switch(_swBase, _occupation, 64);
            var storage = new Storage(_storageBase, _occupation, _storage);

            var rack = new Rack(16, "F1-A12");
            rack.AddEquipment(server);
            rack.AddEquipment(sw1);
            rack.AddEquipment(storage);

            Assert.AreEqual(rack.OccupedSlots, 3);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldReturnInvalidIfRackCapacityIsFullWhenNewEquipmentIsAdded()
        {
            var server = new Server(_serverBase, _occupation, _cpu, _memory, _storage);
            var sw1 = new Switch(_swBase, _occupation, 64);
            var storage = new Storage(_storageBase, _occupation, _storage);

            var rack = new Rack(2, "F1-A12");
            rack.AddEquipment(server);
            rack.AddEquipment(sw1);
            rack.AddEquipment(storage);

            Assert.AreEqual(rack.Invalid, true);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void SpaceUsedShouldBe60()
        {
            var server1 = new Server(_serverBase, _occupation, _cpu, _memory, _storage);
            var sw1 = new Switch(_swBase, _occupation, 64);
            var storage1 = new Storage(_storageBase, _occupation, _storage);

            var server2 = new Server(_serverBase, _occupation, _cpu, _memory, _storage);
            var sw2 = new Switch(_swBase, _occupation, 64);
            var storage2 = new Storage(_storageBase, _occupation, _storage);

            var rack = new Rack(10, "F1-A12");
            rack.AddEquipment(server1);
            rack.AddEquipment(sw1);
            rack.AddEquipment(storage1);

            rack.AddEquipment(server2);
            rack.AddEquipment(sw2);
            rack.AddEquipment(storage2);

            Assert.AreEqual(60.0, rack.RackSpaceUsage());

        }

        [TestMethod]
        [TestCategory("Entities")]
        public void AvailableSpaceShouldBe40()
        {
            var server1 = new Server(_serverBase, _occupation, _cpu, _memory, _storage);
            var sw1 = new Switch(_swBase, _occupation, 64);
            var storage1 = new Storage(_storageBase, _occupation, _storage);

            var server2 = new Server(_serverBase, _occupation, _cpu, _memory, _storage);
            var sw2 = new Switch(_swBase, _occupation, 64);
            var storage2 = new Storage(_storageBase, _occupation, _storage);

            var rack = new Rack(10, "F1-A12");
            rack.AddEquipment(server1);
            rack.AddEquipment(sw1);
            rack.AddEquipment(storage1);

            rack.AddEquipment(server2);
            rack.AddEquipment(sw2);
            rack.AddEquipment(storage2);

            Assert.AreEqual(40.0, rack.RackFreeSpaceUsage());

        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldReturnInvalidWhenAnEquipmentIsAddedOnANotAvaibleSlot()
        {
            var server1 = new Server(_serverBase, _occupation, _cpu, _memory, _storage);
            var sw1 = new Switch(_swBase, _occupation, 64);
            var rack = new Rack(2, "F1-A12");
            rack.AddEquipment(server1);
            rack.AddEquipment(sw1, 1);
            Assert.AreEqual(rack.Invalid, true);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldReturnAvailableSlot5()
        {
            var server1 = new Server(_serverBase, _occupation, _cpu, _memory, _storage);
            var sw1 = new Switch(_swBase, _occupation, 64);
            var server2 = new Server(_serverBase, _occupation, _cpu, _memory, _storage);
            var sw2 = new Switch(_swBase, _occupation, 64);
            var rack = new Rack(12, "F1-A12");

            rack.AddEquipment(server1);
            rack.AddEquipment(server2);
            rack.AddEquipment(sw1);
            rack.AddEquipment(sw2);

            Assert.AreEqual(rack.NextAvaiblePosition(), 5);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldReturnAvaibleSlot4to6()
        {
            var server1 = new Server(_serverBase, _occupation, _cpu, _memory, _storage);
            var server2 = new Server(_serverBase, _occupation, _cpu, _memory, _storage);
            var server3 = new Server(_serverBase, _occupation, _cpu, _memory, _storage);
            var server4 = new Server(_serverBase, _occupation, _cpu, _memory, _storage);
            var server5 = new Server(_serverBase, _occupation, _cpu, _memory, _storage);

            var rack = new Rack(8, "F1-A12");
            rack.AddEquipment(server1);
            rack.AddEquipment(server2);
            rack.AddEquipment(server3);

            rack.AddEquipment(server4, 7);
            rack.AddEquipment(server5, 8);
            CollectionAssert.AreEqual(new int[] { 4, 5, 6 }, rack.AvailablePositions());

        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldReturnAvaibleSlot2And4()
        {
            var server1 = new Server(_serverBase, _occupation, _cpu, _memory, _storage);
            var server2 = new Server(_serverBase, _occupation, _cpu, _memory, _storage);

            var rack = new Rack(4, "F1-A12");
            rack.AddEquipment(server1, 1);
            rack.AddEquipment(server2, 3);

            CollectionAssert.AreEqual(new int[] { 2, 4 }, rack.AvailablePositions());

        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldDeleteAnEquipment()
        {

            var server1 = new Server(_serverBase, _occupation, _cpu, _memory, _storage);
            var server2 = new Server(_serverBase, _occupation, _cpu, _memory, _storage);

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
