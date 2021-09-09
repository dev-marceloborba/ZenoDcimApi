using EvoDcimManager.Domain.ActiveContext.Entities;
using EvoDcimManager.Domain.ActiveContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvoDcimManager.Tests.ActiveContext.Entities
{
    [TestClass]
    public class ServerEntityTests
    {

        private readonly Cpu _cpu = new Cpu("Intel Xeon 16C 2.4GHz");
        private readonly Memory _memory = new Memory(32);
        private readonly Capacity _storage = new Capacity(512);
        private readonly Capacity _occupation = new Capacity(1);
        private readonly Name _serverName = new Name("Server01");
        private readonly Rack _rack = new Rack(16, "F1-A12");
        private readonly BaseEquipment _serverBase = new BaseEquipment("Server01", "HP-Proliant", "HP", "12345679");

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldCreateAValidServer()
        {
            var server = new Server(_serverBase, _occupation, _cpu, _memory, _storage);
            Assert.AreEqual(server.Valid, true);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldNotCreateAnInvalidServer()
        {
            var equipment = new BaseEquipment("", "HP-Proliant", "HP", "12345679");
            var server = new Server(equipment, _occupation, _cpu, _memory, _storage);
            Assert.AreEqual(server.Invalid, true);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldAssociateAValidRack()
        {
            var server = new Server(_serverBase, _occupation, _cpu, _memory, _storage);
            server.AssociateRack(_rack);
            Assert.IsNotNull(server.Rack);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldNotAssociateAnInvalidRack()
        {
            var server = new Server(_serverBase, _occupation, _cpu, _memory, _storage);
            var rack = new Rack(0, "");
            server.AssociateRack(rack);
            Assert.AreEqual(server.Invalid, true);
        }
    }
}