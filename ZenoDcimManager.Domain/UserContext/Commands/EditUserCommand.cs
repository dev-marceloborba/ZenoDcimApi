using ZenoDcimManager.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace ZenoDcimManager.Domain.UserContext.Commands
{
    public class EditUserCommand : Notifiable, ICommand
    {
        public EditUserCommand()
        {

        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public int Role { get; set; }
        public bool Status { get; set; }
        public Guid CompanyId { get; set; }

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