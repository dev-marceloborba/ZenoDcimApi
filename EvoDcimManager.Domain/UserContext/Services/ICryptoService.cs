namespace EvoDcimManager.Domain.UserContext.Services
{
    public interface ICryptoService
    {
        string EncryptPassword(string password);
    }
}