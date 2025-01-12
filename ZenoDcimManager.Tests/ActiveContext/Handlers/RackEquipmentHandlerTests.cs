﻿using System.Linq;
using ZenoDcimManager.Domain.ZenoContext.Commands;
using ZenoDcimManager.Domain.ZenoContext.Enums;
using ZenoDcimManager.Domain.ZenoContext.Handlers;
using ZenoDcimManager.Domain.ZenoContext.Repositories;
using ZenoDcimManager.Tests.ZenoContext.Mocks.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZenoDcimManager.Tests.ZenoContext
{
    [TestClass]
    public class RackEquipmentHandlerTests
    {
        private readonly IRackEquipmentRepository _rackEquipmentRepository;
        private readonly IRackRepository _rackRepository;
        private readonly CreateRackEquipmentCommand _command;
        private readonly RackEquipmentHandler _handler;

        public RackEquipmentHandlerTests()
        {
            _rackEquipmentRepository = new FakeRackEquipmentRepository();
            _rackRepository = new FakeRackRepository();

            _command = new CreateRackEquipmentCommand();
            _command.Name = "Server01";
            _command.Manufactor = "Manufactor";
            _command.SerialNumber = "123465798";
            _command.Model = "model";
            _command.InitialPosition = 1;
            _command.FinalPosition = 2;
            _command.RackEquipmentType = ERackEquipmentType.SERVER;

            _handler = new RackEquipmentHandler(_rackEquipmentRepository, _rackRepository);
        }

        // [TestMethod]
        // [TestCategory("Handlers")]
        // public void ShouldNotCreateWhenCommandIsInvalid()
        // {
        //     _command.SerialNumber = "";

        //     _handler.Handle(_command);

        //     Assert.AreEqual(_handler.Invalid, true);
        // }

        [TestMethod]
        [TestCategory("Handlers")]
        public void ShouldCreateWhenCommandIsValid()
        {
            _handler.Handle(_command);

            Assert.AreEqual(_handler.Valid, true);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void ShouldNotCreateWhenRackDoesntExists()
        {
            // _command.RackLocalization = "ABC";

            _handler.Handle(_command);

            Assert.AreEqual(_handler.Invalid, true);
        }
    }
}