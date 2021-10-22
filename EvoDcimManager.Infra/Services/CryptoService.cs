using BC = BCrypt.Net.BCrypt;
using EvoDcimManager.Domain.UserContext.Services;

namespace EvoDcimManager.Infra.Services
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