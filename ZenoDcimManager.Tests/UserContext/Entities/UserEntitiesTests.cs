using ZenoDcimManager.Domain.UserContext.Entities;
using ZenoDcimManager.Domain.UserContext.Enums;
using ZenoDcimManager.Domain.UserContext.Validators;
using ZenoDcimManager.Domain.UserContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZenoDcimManager.Tests.UserContext.Entities
{
    [TestClass]
    public class UserEntitiesTests
    {

        private readonly Name _name = new Name("Marcelo", "Borba");
        private readonly Email _email = new Email("marcelo@marcelo.com");
        private readonly Password _password = new Password("123456789", "123456789");
        private readonly Company _company = new Company("Mindcloud", "Mindcloud", "12456789123");
        private readonly User _user;
        public UserEntitiesTests()
        {
            _user = new User("Marcelo", "Borba", "marcelo@marcelo.com", "123456798", EUserRole.ADMIN, _company);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldCreateActiveUser()
        {
            Assert.AreEqual(_user.Active, true);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldChangeUserToInactive()
        {
            _user.Deactivate();
            Assert.AreEqual(_user.Active, false);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldChangeRoleToOperator()
        {
            _user.ChangeRole(EUserRole.OPERATOR);
            Assert.AreEqual(_user.Role, EUserRole.OPERATOR);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldChangeRoleToViewOnly()
        {
            _user.ChangeRole(EUserRole.VIEW_ONLY);
            Assert.AreEqual(_user.Role, EUserRole.VIEW_ONLY);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldChangeRoleToExternalClient()
        {
            _user.ChangeRole(EUserRole.EXTERNAL_CLIENT);
            Assert.AreEqual(_user.Role, EUserRole.EXTERNAL_CLIENT);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldChangeUserEmail()
        {
            _user.ChangeEmail("novoemail@gmail.com");
            Assert.AreNotEqual(_user.Email, _email.Address);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldCreateAValidUser()
        {
            var userValidator = new UserValidator(_user);
            Assert.AreEqual(userValidator.Valid, true);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldCreateAnInvalidUser()
        {
            var user = new User("Marcelo", "", "marcelo@marcelo.com", "123456798", EUserRole.ADMIN, _company);
            var userValidator = new UserValidator(user);
            Assert.AreEqual(userValidator.Invalid, true);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldCreateUserAsOperator()
        {
            var user = new User("Marcelo", "Borba", "marcelo@mindcloud.com", "12345678", EUserRole.OPERATOR, _company);
            Assert.AreEqual(user.Role, EUserRole.OPERATOR);
        }
    }
}
