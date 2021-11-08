namespace ZenoDcimManager.Domain.UserContext.Services
{
    public interface ICryptoService
    {
        string EncryptPassword(string password);
        bool ValidatePassword(string password, string hashedPassword);
    }
}