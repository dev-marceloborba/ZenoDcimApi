using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Domain.ZenoContext.Enums;
using ZenoDcimManager.Domain.ZenoContext.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZenoDcimManager.Tests.ZenoContext.Entities
{
    [TestClass]
    public class RackEquipmentEntityTests
    {
        private readonly Rack _rack = new Rack(16, "F1-A12");
        private readonly BaseEquipment _serverBase = new BaseEquipment("Server01", "HP-Proliant", "HP", "12345679");
        private RackEquipment _server;

        public RackEquipmentEntityTests()
        {
            _server = new RackEquipment(_serverBase, 1, 2, ERackEquipmentType.SERVER);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldCreateAValidServer()
        {
            var rackEquipment = new RackEquipment(_serverBase, 1, 2, ERackEquipmentType.SERVER);
            var rackEquipmentValidator = new RackEquipmentValidator(rackEquipment);
            Assert.AreEqual(rackEquipmentValidator.Valid, true);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldNotCreateAnInvalidServer()
        {
            var server = new RackEquipment(_serverBase, 2, 2, ERackEquipmentType.SERVER);
            var rackEquipmentValidator = new RackEquipmentValidator(server);
            Assert.AreEqual(rackEquipmentValidator.Invalid, true);
        }
    }
}