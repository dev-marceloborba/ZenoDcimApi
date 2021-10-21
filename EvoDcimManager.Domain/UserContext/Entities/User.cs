using EvoDcimManager.Domain.UserContext.Enums;
using EvoDcimManager.Shared;

namespace EvoDcimManager.Domain.UserContext.Entities
{
    public class User : Entity
    {
        public User()
        {

        }
        public User(string firstName, string lastName, string email, string hashedPassword, EUserRole role)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            HashedPassword = hashedPassword;
            Role = role;
            Active = true;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string HashedPassword { get; private set; }
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

        public void ChangeEmail(string email)
        {
            Email = email;
        }

        public override string ToString()
        {
            return FirstName + ' ' + LastName;
        }
    }
}