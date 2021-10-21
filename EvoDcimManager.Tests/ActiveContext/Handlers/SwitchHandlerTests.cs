using System.Linq;
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
        private SwitchHandler _handler;

        public SwitchHandlerTests()
        {
            _switchRepository = new FakeSwitchRepository();
            _rackRepository = new FakeRackRepository();
            _handler = new SwitchHandler(_switchRepository, _rackRepository);
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
            command.InitialPosition = 1;
            command.FinalPosition = 2;
            command.RackLocalization = _rackRepository.List().FirstOrDefault().Localization;

            _handler.Handle(command);

            Assert.AreEqual(true, _handler.Valid);
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
            command.InitialPosition = 1;
            command.FinalPosition = 2;
            command.RackLocalization = _rackRepository.List().FirstOrDefault().Localization;

            _handler.Handle(command);

            Assert.AreEqual(true, _handler.Invalid);
        }
    }
}