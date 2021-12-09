using ZenoDcimManager.Domain.UserContext.Entities;
using Flunt.Notifications;

namespace ZenoDcimManager.Domain.UserContext.Validators
{
    public class UserValidator : Notifiable
    {
        public UserValidator(User user)
        {
            AddNotifications(new Flunt.Validations.Contract()
                .Requires()
                .HasMinLen(user.FirstName, 3, "FirstName", "Minimo de 3 caracteres")
                .HasMaxLen(user.FirstName, 40, "FirstName", "Maximo de 40 caracteres")
                .HasMinLen(user.LastName, 3, "LastName", "Minimo de 3 caracteres")
                .HasMaxLen(user.LastName, 40, "LastName", "Maximo de 40 caracteres")
                .IsEmail(user.Email, "Address", "E-mail invalido")
            );
        }
    }
}