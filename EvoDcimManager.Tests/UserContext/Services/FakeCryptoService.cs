using EvoDcimManager.Domain.UserContext.Services;

namespace EvoDcimManager.Tests.UserContext.Services
{
    public class FakeCryptoService : ICryptoService
    {
        public string EncryptPassword(string password)
        {
            return "abcd";
        }
    }
}