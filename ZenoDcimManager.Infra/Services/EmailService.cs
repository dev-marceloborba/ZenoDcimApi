using System;
using ZenoDcimManager.Shared.Services;

namespace ZenoDcimManager.Infra.Services
{
    public class EmailService : IEmailService
    {
        public void Send(string to, string email, string subject, string body)
        {
            Console.WriteLine("email send");
        }
    }
}