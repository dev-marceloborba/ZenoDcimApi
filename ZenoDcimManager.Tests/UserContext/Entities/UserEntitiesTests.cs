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
            _user = new User();
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



    }
}
