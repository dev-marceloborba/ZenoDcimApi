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

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldAdd3EquipmentsOnRack()
        {
            var rack = new Rackv2(16, "F1-A12");
            rack.InitEmptyRack();

            var server = new Serverv2(_serverBase, _cpu, _memory, _storage);

            rack.PlaceEquipment(new RackPosition(server, 1, 2));
            rack.PlaceEquipment(new RackPosition(server, 3, 4));
            rack.PlaceEquipment(new RackPosition(server, 5, 6));

            Assert.AreEqual(rack.TotalEquipments(), 3);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldHave6OccupedSlots()
        {
            var rack = new Rackv2(16, "F1-A12");
            rack.InitEmptyRack();

            var server = new Serverv2(_serverBase, _cpu, _memory, _storage);

            rack.PlaceEquipment(new RackPosition(server, 1, 2));
            rack.PlaceEquipment(new RackPosition(server, 3, 4));
            rack.PlaceEquipment(new RackPosition(server, 5, 6));

            Assert.AreEqual(rack.TotalOccupedSlots(), 6);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldReturnInvalidIfRackCapacityIsFullWhenNewEquipmentIsAdded()
        {
            var rack = new Rackv2(6, "F1-A12");
            rack.InitEmptyRack();

            var server = new Serverv2(_serverBase, _cpu, _memory, _storage);

            rack.PlaceEquipment(new RackPosition(server, 1, 2));
            rack.PlaceEquipment(new RackPosition(server, 3, 4));
            rack.PlaceEquipment(new RackPosition(server, 5, 6));
            rack.PlaceEquipment(new RackPosition(server, 7, 8));

            Assert.AreEqual(rack.Invalid, true);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void SpaceUsedShouldBe50()
        {
            var rack = new Rackv2(8, "F1-A12");
            rack.InitEmptyRack();

            var server = new Serverv2(_serverBase, _cpu, _memory, _storage);

            rack.PlaceEquipment(new RackPosition(server, 1, 2));
            rack.PlaceEquipment(new RackPosition(server, 3, 4));

            Assert.AreEqual(50.0, rack.PercentUsedSpace());
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void AvailableSpaceShouldBe50()
        {
            var rack = new Rackv2(8, "F1-A12");
            rack.InitEmptyRack();

            var server = new Serverv2(_serverBase, _cpu, _memory, _storage);

            rack.PlaceEquipment(new RackPosition(server, 1, 2));
            rack.PlaceEquipment(new RackPosition(server, 3, 4));
            Assert.AreEqual(50.0, rack.PercentAvailableSpace());
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldReturnInvalidWhenAnEquipmentIsAddedOnANotAvaibleSlot()
        {
            var rack = new Rackv2(8, "F1-A12");
            rack.InitEmptyRack();

            var server = new Serverv2(_serverBase, _cpu, _memory, _storage);

            rack.PlaceEquipment(new RackPosition(server, 1, 2));
            rack.PlaceEquipment(new RackPosition(server, 1, 2));
            Assert.AreEqual(rack.Invalid, true);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldReturnAvailableSlot9()
        {
            var rack = new Rackv2(10, "F1-A12");
            rack.InitEmptyRack();

            var server = new Serverv2(_serverBase, _cpu, _memory, _storage);

            rack.PlaceEquipment(new RackPosition(server, 1, 2));
            rack.PlaceEquipment(new RackPosition(server, 3, 4));
            rack.PlaceEquipment(new RackPosition(server, 5, 6));
            rack.PlaceEquipment(new RackPosition(server, 7, 8));

            Assert.AreEqual(rack.FirstAvailablePosition(), 9);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldReturnAvaibleSlot7to8()
        {
            var rack = new Rackv2(12, "F1-A12");
            rack.InitEmptyRack();

            var server1 = new Serverv2(_serverBase, _cpu, _memory, _storage);
            var server2 = new Serverv2(_serverBase, _cpu, _memory, _storage);
            var server3 = new Serverv2(_serverBase, _cpu, _memory, _storage);
            var server4 = new Serverv2(_serverBase, _cpu, _memory, _storage);
            var server5 = new Serverv2(_serverBase, _cpu, _memory, _storage);

            rack.PlaceEquipment(new RackPosition(server1, 1, 2));
            rack.PlaceEquipment(new RackPosition(server2, 3, 4));
            rack.PlaceEquipment(new RackPosition(server3, 5, 6));
            rack.PlaceEquipment(new RackPosition(server4, 9, 10));
            rack.PlaceEquipment(new RackPosition(server5, 11, 12));

            CollectionAssert.AreEqual(new int[] { 7, 8 }, rack.AvailablePositions());
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldReturnAvaibleSlot3And4()
        {
            var rack = new Rackv2(6, "F1-A12");
            rack.InitEmptyRack();

            var server1 = new Serverv2(_serverBase, _cpu, _memory, _storage);
            var server2 = new Serverv2(_serverBase, _cpu, _memory, _storage);

            rack.PlaceEquipment(new RackPosition(server1, 1, 2));
            rack.PlaceEquipment(new RackPosition(server1, 5, 6));

            CollectionAssert.AreEqual(new int[] { 3, 4 }, rack.AvailablePositions());
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldInsertTwoServersAndRemoveTheFirstOne()
        {
            var rack = new Rackv2(6, "F1-A12");
            rack.InitEmptyRack();

            var server1 = new Serverv2(_serverBase, _cpu, _memory, _storage);
            var server2 = new Serverv2(_serverBase, _cpu, _memory, _storage);

            rack.PlaceEquipment(new RackPosition(server1, 1, 2));
            rack.PlaceEquipment(new RackPosition(server1, 5, 6));
            rack.RemoveEquipment(1);

            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4 }, rack.AvailablePositions());
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldDeleteAnEquipment()
        {
            var rack = new Rackv2(6, "F1-A12");
            rack.InitEmptyRack();

            var server1 = new Serverv2(_serverBase, _cpu, _memory, _storage);
            var server2 = new Serverv2(_serverBase, _cpu, _memory, _storage);

            rack.PlaceEquipment(new RackPosition(server1, 1, 2));
            rack.PlaceEquipment(new RackPosition(server1, 5, 6));
            var totalSlots = rack.TotalEquipments();
            rack.RemoveEquipment(1);
            var updatedTotalSlots = rack.TotalEquipments();

            Assert.AreNotEqual(totalSlots, updatedTotalSlots);

        }
    }
}
