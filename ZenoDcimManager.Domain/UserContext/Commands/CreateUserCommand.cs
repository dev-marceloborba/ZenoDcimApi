using ZenoDcimManager.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace ZenoDcimManager.Domain.UserContext.Commands
{
    public class CreateUserCommand : Notifiable, ICommand
    {
        public CreateUserCommand()
        {

        }
        public CreateUserCommand(string firstName, string lastName, string email, string password, string passwordConfirmation, int role, bool active)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            PasswordConfirmation = passwordConfirmation;
            Role = role;
            Active = active;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public int Role { get; set; }
        public bool Active { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsTrue(ValidateRole(), "Role", "Invalid role")
                .AreNotEquals(Password, PasswordConfirmation, "Password", "Password doenst match")
            );
        }

        public bool ValidateRole()
        {
            return ((int)Role <= 4);
        }
    }
}