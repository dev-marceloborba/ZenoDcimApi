using EvoDcimManager.Domain.UserContext.Enums;
using EvoDcimManager.Domain.UserContext.ValueObjects;
using EvoDcimManager.Shared;

namespace EvoDcimManager.Domain.UserContext.Entities
{
    public class User : Entity
    {
        public User(Name name, Email email, Password password, EUserRole role)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
            Active = true;
        }

        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public Password Password { get; private set; }
        public EUserRole Role { get; private set; }
        public bool Active { get; private set; }

        public void Activate()
        {
            Active = true;
        }

        public void Deactivate()
        {
            Active = false;
        }

        public void ChangeRole(EUserRole role)
        {
            Role = role;
        }

        public void ChangeEmail(Email email)
        {
            Email = email;
        }
    }
}