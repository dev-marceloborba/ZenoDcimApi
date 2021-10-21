using EvoDcimManager.Domain.ActiveContext.Commands;
using EvoDcimManager.Domain.ActiveContext.Handlers;
using EvoDcimManager.Domain.ActiveContext.Repositories;
using EvoDcimManager.Tests.ActiveContext.Mocks.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvoDcimManager.Tests.ActiveContext.Handlers
{
    [TestClass]
    public class RackHandlerTests
    {
        private readonly IRackRepository _repository;

        public RackHandlerTests()
        {
            _repository = new FakeRackRepository();
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void ShouldNotCreateWhenRackInInvalid()
        {
            var command = new CreateRackCommand();
            command.Size = 0;
            command.Localization = "";
            var handler = new RackHandler(_repository);
            handler.Handle(command);
            Assert.AreEqual(handler.Invalid, true);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void ShouldCreateWhenRackValid()
        {
            var command = new CreateRackCommand();
            command.Size = 16;
            command.Localization = "A1-B1-B2-B2";
            var handler = new RackHandler(_repository);
            handler.Handle(command);
            Assert.AreEqual(handler.Valid, true);
        }
    }
}