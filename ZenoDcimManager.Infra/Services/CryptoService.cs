using BC = BCrypt.Net.BCrypt;
using ZenoDcimManager.Domain.UserContext.Services;

namespace ZenoDcimManager.Infra.Services
{
    public class CryptoService : ICryptoService
    {
        public string EncryptPassword(string password)
        {
            return BC.HashPassword(password);
        }

        public bool ValidatePassword(string password, string hashedPassword)
        {
            return (!BC.Verify(password, hashedPassword));
        }
    }
}