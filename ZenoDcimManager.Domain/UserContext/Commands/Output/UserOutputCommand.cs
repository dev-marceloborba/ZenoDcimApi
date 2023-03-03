using System;
using ZenoDcimManager.Domain.UserContext.Entities;
using ZenoDcimManager.Domain.UserContext.Enums;

namespace ZenoDcimManager.Domain.UserContext.Commands.Output
{
    public class UserOutputCommand
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public UserPreferencies UserPreferencies { get; set; }
        public UserGroupOutputCommand Group { get; set; }

        public UserOutputCommand(Guid id, string firstName, string lastName, string email, bool active,
            UserPreferencies userPreferencies, UserGroupOutputCommand group)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Active = active;
            UserPreferencies = userPreferencies;
            Group = group;
        }


    }
}