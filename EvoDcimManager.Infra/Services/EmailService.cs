using System;
using EvoDcimManager.Shared.Services;

namespace EvoDcimManager.Infra.Services
{
    public class EmailService : IEmailService
    {
        public void Send(string to, string email, string subject, string body)
        {
            Console.WriteLine("email send");
        }
    }
}