namespace ZenoDcimManager.Shared.Services
{
    public interface IEmailService
    {
        void Send(string to, string email, string subject, string body);
    }
}