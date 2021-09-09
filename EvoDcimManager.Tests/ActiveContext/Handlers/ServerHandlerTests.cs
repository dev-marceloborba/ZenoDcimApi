using System;
using System.Linq;
using EvoDcimManager.Domain.ActiveContext.Commands;
using EvoDcimManager.Domain.ActiveContext.Handlers;
using EvoDcimManager.Domain.ActiveContext.Repositories;
using EvoDcimManager.Tests.ActiveContext.Mocks.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvoDcimManager.Tests.ActiveContext
{
    [TestClass]
    public class ServerHandlerTests
    {
        private readonly IServerRepository _serverRepository;
        private readonly IRackRepository _rackRepository;

        public ServerHandlerTests()
        {
            _serverRepository = new FakeServerRepository();
            _rackRepository = new FakeRackRepository();
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void ShouldNotCreateWhenCommandIsInvalid()
        {
            var command = new CreateServerCommand();
            command.Name = "Server01";
            command.Manufactor = "Manufactor";
            command.SerialNumber = "";
            command.Model = "model";
            command.Cpu = "Intel x86";
            command.Memory = 32;
            command.Storage = 512;
            command.RackPosition = 3;
            command.RackId = _rackRepository.List().FirstOrDefault().Id;

            var handler = new CreateServerHandler(_serverRepository, _rackRepository);
            handler.Handle(command);

            Assert.AreEqual(handler.Invalid, true);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void ShouldCreateWhenCommandIsValid()
        {
            var command = new CreateServerCommand();
            command.Name = "Server01";
            command.Manufactor = "Manufactor";
            command.SerialNumber = "123465798";
            command.Model = "model";
            command.Cpu = "Intel x86";
            command.Memory = 32;
            command.Storage = 512;
            command.RackPosition = 3;
            command.Occupation = 1;
            command.RackId = _rackRepository.List().FirstOrDefault().Id;

            var handler = new CreateServerHandler(_serverRepository, _rackRepository);
            handler.Handle(command);

            Assert.AreEqual(handler.Valid, true);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void ShouldNotCreateWhenRackDoesntExists()
        {
            var command = new CreateServerCommand();
            command.Name = "Server01";
            command.Manufactor = "Manufactor";
            command.SerialNumber = "123465798";
            command.Model = "model";
            command.Cpu = "Intel x86";
            command.Memory = 32;
            command.Storage = 512;
            command.RackPosition = 3;
            command.RackId = Guid.NewGuid();

            var handler = new CreateServerHandler(_serverRepository, _rackRepository);
            handler.Handle(command);

            Assert.AreEqual(handler.Invalid, true);
        }
    }
}