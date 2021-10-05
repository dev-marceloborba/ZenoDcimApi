using EvoDcimManager.Domain.ActiveContext.Commands;
using EvoDcimManager.Domain.ActiveContext.Handlers;
using EvoDcimManager.Domain.ActiveContext.Repositories;
using EvoDcimManager.Tests.ActiveContext.Mocks.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvoDcimManager.Tests.ActiveContext.Handlers
{
    [TestClass]
    public class StorageHandlerTests
    {
        private readonly IStorageRepository _storageRepository;
        private readonly IRackRepository _rackRepository;

        public StorageHandlerTests()
        {
            _storageRepository = new FakeStorageRepository();
            _rackRepository = new FakeRackRepository();
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void ShouldCreateStorageWhenCommandIsValid()
        {
            var command = new CreateStorageCommand();
            command.Name = "Name";
            command.Model = "Model";
            command.Manufactor = "Manufactor";
            command.SerialNumber = "SerialNumber";
            command.Capacity = 10;
            command.InitialPosition = 1;
            command.FinalPosition = 2;

            var handler = new CreateStorageHandler(_storageRepository);
            handler.Handle(command);

            Assert.AreEqual(true, handler.Valid);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void ShouldNotCreateStorageWhenCommandIsInvalid()
        {
            var command = new CreateStorageCommand();
            command.Name = "Name";
            command.Model = "Model";
            command.Manufactor = "Manufactor";
            command.SerialNumber = "SerialNumber";
            command.Capacity = 0;
            command.InitialPosition = 1;
            command.FinalPosition = 2;

            var handler = new CreateStorageHandler(_storageRepository);
            handler.Handle(command);

            Assert.AreEqual(true, handler.Invalid);
        }
    }
}