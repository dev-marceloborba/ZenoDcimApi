using EvoDcimManager.Domain.ActiveContext.Commands;
using EvoDcimManager.Domain.ActiveContext.Handlers;
using EvoDcimManager.Domain.ActiveContext.Repositories;
using EvoDcimManager.Tests.ActiveContext.Mocks.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvoDcimManager.Tests.ActiveContext.Handlers
{
    [TestClass]
    public class SwitchHandlerTests
    {
        private readonly ISwitchRepository _switchRepository;
        private readonly IRackRepository _rackRepository;

        public SwitchHandlerTests()
        {
            _switchRepository = new FakeSwitchRepository();
            _rackRepository = new FakeRackRepository();
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void ShouldCreateSwitchWhenCommandIsValid()
        {
            var command = new CreateSwitchCommand();
            command.Name = "Name";
            command.Model = "Model";
            command.Manufactor = "Manufactor";
            command.SerialNumber = "SerialNumber";
            command.EthPorts = 10;
            command.Occupation = 2;
            command.Position = 1;

            var handler = new CreateSwitchHandler(_switchRepository);
            handler.Handle(command);

            Assert.AreEqual(true, handler.Valid);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void ShouldNotCreateSwitchWhenCommandIsInvalid()
        {
            var command = new CreateSwitchCommand();
            command.Name = "Name";
            command.Model = "Model";
            command.Manufactor = "Manufactor";
            command.SerialNumber = "SerialNumber";
            command.EthPorts = 0;
            command.Occupation = 2;
            command.Position = 1;

            var handler = new CreateSwitchHandler(_switchRepository);
            handler.Handle(command);

            Assert.AreEqual(true, handler.Invalid);
        }
    }
}