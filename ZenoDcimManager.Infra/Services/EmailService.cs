using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using ZenoDcimManager.Shared.Services;

namespace ZenoDcimManager.Infra.Services
{
    public class EmailService : IEmailService
    {
        public void Send(string to, string email, string subject, string body)
        {
            string fromName = "Zeno DCIM";
            string fromEmail = "alarm@mindcloud-software.com";

            var smtpClient = new SmtpClient("smtp.sendgrid.net", 587);
            smtpClient.Credentials = new NetworkCredential("apikey", "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");
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;

            var mail = new MailMessage();
            mail.From = new MailAddress(fromEmail, fromName);
            mail.To.Add(new MailAddress(email, to));
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            try
            {
                smtpClient.SendAsync(mail, null);
            }
            catch
            {
                Console.WriteLine("Error on send e-mail");
            }
        }
    }
}