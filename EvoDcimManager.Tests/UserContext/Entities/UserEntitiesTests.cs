using EvoDcimManager.Domain.UserContext.Entities;
using EvoDcimManager.Domain.UserContext.Enums;
using EvoDcimManager.Domain.UserContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvoDcimManager.Tests.UserContext.Entities
{
    [TestClass]
    public class UserEntitiesTests
    {

        private readonly Name _name = new Name("Marcelo", "Borba");
        private readonly Email _email = new Email("marcelo@marcelo.com");
        private readonly Password _password = new Password("123456789", "123456789");

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldCreateActiveUser()
        {
            var user = new User(_name, _email, _password, EUserRole.ADMIN);
            Assert.AreEqual(user.Active, true);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldChangeUserToInactive()
        {
            var user = new User(_name, _email, _password, EUserRole.ADMIN);
            user.Deactivate();
            Assert.AreEqual(user.Active, false);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldChangeRoleToOperator()
        {
            var user = new User(_name, _email, _password, EUserRole.ADMIN);
            user.ChangeRole(EUserRole.OPERATOR);
            Assert.AreEqual(user.Role, EUserRole.OPERATOR);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldChangeRoleToViewOnly()
        {
            var user = new User(_name, _email, _password, EUserRole.ADMIN);
            user.ChangeRole(EUserRole.VIEW_ONLY);
            Assert.AreEqual(user.Role, EUserRole.VIEW_ONLY);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldChangeRoleToExternalClient()
        {
            var user = new User(_name, _email, _password, EUserRole.ADMIN);
            user.ChangeRole(EUserRole.EXTERNAL_CLIENT);
            Assert.AreEqual(user.Role, EUserRole.EXTERNAL_CLIENT);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldChangeUserEmail()
        {
            var user = new User(_name, _email, _password, EUserRole.ADMIN);
            user.ChangeEmail(new Email("novoemail@gmail.com"));
            Assert.AreNotEqual(user.Email.Address, _email.Address);
        }
    }
}
