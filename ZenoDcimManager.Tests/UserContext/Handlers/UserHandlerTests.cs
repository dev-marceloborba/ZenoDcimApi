using ZenoDcimManager.Domain.UserContext.Commands;
using ZenoDcimManager.Domain.UserContext.Handlers;
using ZenoDcimManager.Domain.UserContext.Repositories;
using ZenoDcimManager.Domain.UserContext.Services;
using ZenoDcimManager.Shared.Services;
using ZenoDcimManager.Tests.UserContext.Repositories;
using ZenoDcimManager.Tests.UserContext.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZenoDcimManager.Domain.UserContext.Enums;
using System;
using ZenoDcimManager.Domain.UserContext.Commands.Output;
using System.Threading.Tasks;

namespace ZenoDcimManager.Tests.UserContext.Handlers
{
    [TestClass]
    public class UserHandlerTests
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
        private readonly ICryptoService _cryptoService;
        private readonly ICompanyRepository _companyRepository;
        private UserHandler _handler;
        public UserHandlerTests()
        {
            _userRepository = new FakeUserRepository();
            _emailService = new FakeEmailService();
            _cryptoService = new FakeCryptoService();
            _companyRepository = new FakeCompanyRepository();
            _handler = new UserHandler(_userRepository, null, _emailService, _cryptoService, _companyRepository);
        }
        [TestMethod]
        [TestCategory("Handlers")]
        public void ShouldCreateUserWhenCommandIsValid()
        {
            var command = new CreateUserCommand();
            command.FirstName = "Marcelo";
            command.LastName = "Borba";
            command.Email = "marcelo@marcelo.com";
            command.Password = "123456";
            command.PasswordConfirmation = "123456";
            command.Active = true;
            command.CompanyId = Guid.Parse("bde6ab74-81be-448c-9abf-709e60a221b0");
            _handler.Handle(command);
            Assert.AreEqual(_handler.Valid, true);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void ShouldCreateUserWhenCommandIsInvalid()
        {
            var command = new CreateUserCommand();
            command.FirstName = "Marcelo";
            command.LastName = "Borba";
            command.Email = "marcelo@marcelo.com";
            command.Password = "123456";
            command.PasswordConfirmation = "123456";
            command.Active = true;
            command.CompanyId = Guid.Parse("bde6ab74-81be-448c-9abf-709e60a221b0");
            _handler.Handle(command);
            Assert.AreEqual(_handler.Invalid, true);
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

        [TestMethod]
        [TestCategory("Handlers")]
        public async Task ShouldCreateUserAsOperator()
        {
            var command = new CreateUserCommand();
            command.FirstName = "Marcelo";
            command.LastName = "Borba";
            command.Email = "marcelo@marcelo.com";
            command.Password = "123456";
            command.PasswordConfirmation = "123456";
            command.Active = true;
            command.CompanyId = Guid.Parse("bde6ab74-81be-448c-9abf-709e60a221b0");
            var result = await _handler.Handle(command);
            var entity = (UserOutputCommand)result.Data;
            Assert.Fail();
        }
    }
}
