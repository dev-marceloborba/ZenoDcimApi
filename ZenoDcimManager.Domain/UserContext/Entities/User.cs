using ZenoDcimManager.Domain.UserContext.Enums;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.UserContext.Entities
{
    public class User : Entity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string HashedPassword { get; private set; }
        public EUserRole Role { get; private set; }
        public bool Active { get; private set; }
        public Company Company { get; private set; }

        public User()
        {

        }

        public User(string firstName, string lastName, string email, EUserRole role, Company company)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Role = role;
            Active = true;
            Company = company;
        }
        public User(string firstName, string lastName, string email, string hashedPassword, EUserRole role, Company company) : this(firstName, lastName, email, role, company)
        {
            HashedPassword = hashedPassword;
        }

        public void Activate() => Active = true;

        public void Deactivate() => Active = false;

        public void ChangeRole(EUserRole role) => Role = role;

        public void ChangeEmail(string email) => Email = email;

        public void ChangeFirstName(string firstName) => FirstName = firstName;
        public void ChangeLastName(string lastName) => LastName = lastName;
        public User CopyWith(User user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            // HashedPassword = user.HashedPassword;
            Role = user.Role;
            Active = user.Active;
            Company = user.Company;
            return this;
        }

        public override string ToString() => FirstName + " " + LastName;
    }
}