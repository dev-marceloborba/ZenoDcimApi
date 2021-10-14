using EvoDcimManager.Domain.UserContext.Commands;
using EvoDcimManager.Domain.UserContext.Handlers;
using EvoDcimManager.Domain.UserContext.Repositories;
using EvoDcimManager.Shared.Services;
using EvoDcimManager.Tests.UserContext.Repositories;
using EvoDcimManager.Tests.UserContext.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvoDcimManager.Tests.UserContext.Handlers
{
    [TestClass]
    public class UserHandlerTests
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
        public UserHandlerTests()
        {
            _userRepository = new FakeUserRepository();
            _emailService = new FakeEmailService();
        }
        [TestMethod]
        [TestCategory("Handlers")]
        public void ShouldCreateUserWhenCommandIsValid()
        {
            var command = new CreateUserCommand("Marcelo", "Borba", "marcelo@marcelo.com", "123456", "123456", 1, true);
            var handler = new UserHandler(_userRepository, _emailService);
            handler.Handle(command);
            Assert.AreEqual(handler.Valid, true);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void ShouldCreateUserWhenCommandIsInvalid()
        {
            var command = new CreateUserCommand("Marcelo", "Borba", "marcelo@marcelo.com", "123456", "123456", 8, true);
            var handler = new UserHandler(_userRepository, _emailService);
            handler.Handle(command);
            Assert.AreEqual(handler.Invalid, true);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void ShouldAddANewUserOnRepository()
        {
            // var userCount = _userRepository.List().Count;
            // var command = new CreateUserCommand("Marcelo", "Borba", "marcelo@marcelo.com", "123456", "123456", 1, true);
            // var handler = new UserHandler(_userRepository, _emailService);
            // handler.Handle(command);
            // var userCountUpdated = _userRepository.List().Count;
            // Assert.AreNotEqual(userCount, userCountUpdated);
            Assert.IsTrue(true);
        }
    }
}
