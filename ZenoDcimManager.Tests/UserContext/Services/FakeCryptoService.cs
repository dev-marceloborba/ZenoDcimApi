using ZenoDcimManager.Domain.UserContext.Services;

namespace ZenoDcimManager.Tests.UserContext.Services
{
    public class FakeCryptoService : ICryptoService
    {
        public string EncryptPassword(string password)
        {
            return "abcd";
        }

        public bool ValidatePassword(string password1, string password2)
        {
            return password1 == password2;
        }
    }
}