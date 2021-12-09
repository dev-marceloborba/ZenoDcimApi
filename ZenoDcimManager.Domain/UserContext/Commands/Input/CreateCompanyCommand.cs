using Flunt.Notifications;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.UserContext.Commands.Input
{
    public class CreateCompanyCommand : Notifiable, ICommand
    {
        public string CompanyName { get; set; } // razao social
        public string TradingName { get; set; } // nome fantasia
        public string RegistrationNumber { get; set; } // cnpj
        public void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}