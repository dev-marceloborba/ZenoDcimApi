using System;
using ZenoDcimManager.Domain.UserContext.Enums;

namespace ZenoDcimManager.Domain.UserContext.Commands.Output
{
    public class UserOutputCommand
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public EUserRole Role { get; set; }
        public bool Active { get; set; }

        public UserOutputCommand(Guid id, string firstName, string lastName, string email, EUserRole role, bool active)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Role = role;
            Active = active;
        }


    }
}