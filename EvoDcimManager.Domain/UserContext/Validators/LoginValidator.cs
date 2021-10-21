using Flunt.Notifications;
using Flunt.Validations;

namespace EvoDcimManager.Domain.UserContext.Validators
{
    public class LoginValidator : Notifiable
    {
        public LoginValidator(string source, string target)
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(source, target, "Password", "Password doesnt match")
            );
        }
    }
}