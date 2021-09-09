using EvoDcimManager.Shared.Services;

namespace EvoDcimManager.Tests.UserContext.Services
{
    public class FakeEmailService : IEmailService
    {
        public void Send(string to, string email, string subject, string body)
        {

        }
    }
}