using ZenoDcimManager.Domain.ZenoContext.Commands;
using ZenoDcimManager.Domain.ZenoContext.Handlers;
using ZenoDcimManager.Domain.ZenoContext.Repositories;
using ZenoDcimManager.Tests.ZenoContext.Mocks.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZenoDcimManager.Tests.ZenoContext.Handlers
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
            command.Size = "";
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
            command.Size = "16";
            command.Localization = "A1-B1-B2-B2";
            var handler = new RackHandler(_repository);
            handler.Handle(command);
            Assert.AreEqual(handler.Valid, true);
        }
    }
}