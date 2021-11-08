using ZenoDcimManager.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace ZenoDcimManager.Domain.UserContext.Commands
{
    public class LoginCommand : Notifiable, ICommand
    {
        public LoginCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
            );
        }
    }
}