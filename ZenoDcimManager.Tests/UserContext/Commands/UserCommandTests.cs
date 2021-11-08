using ZenoDcimManager.Domain.UserContext.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZenoDcimManager.Tests.UserContext.Commands
{
    [TestClass]
    public class UserCommandTests
    {
        [TestMethod]
        [TestCategory("Commands")]
        public void ShouldReturnValidCommand()
        {
            var command = new CreateUserCommand("Marcelo", "Borba", "marcelo@marcelo.com", "123456", "123456", 1, true);
            command.Validate();
            Assert.AreEqual(command.Valid, true);
        }

        [TestMethod]
        [TestCategory("Commands")]
        public void ShouldReturnInvalidCommand()
        {
            var command = new CreateUserCommand("Marcelo", "Borba", "marcelo@marcelo.com", "123456", "123456", 8, true);
            command.Validate();
            Assert.AreEqual(command.Invalid, true);
        }
    }
}
