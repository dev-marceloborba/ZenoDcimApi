using ZenoDcimManager.Domain.ActiveContext.Commands;
using ZenoDcimManager.Domain.ActiveContext.Handlers;
using ZenoDcimManager.Domain.ActiveContext.Repositories;
using ZenoDcimManager.Tests.ActiveContext.Mocks.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZenoDcimManager.Tests.ActiveContext.Handlers
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