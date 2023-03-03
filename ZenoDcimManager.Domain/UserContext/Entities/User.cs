using System;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.UserContext.Entities
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public bool Active { get; set; }
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
        public Group Group { get; set; }
        public Guid GroupId { get; set; }
        public UserPreferencies UserPreferencies { get; set; }
        public Guid? UserPreferenciesId { get; set; }

        public User()
        {

        }

        public void Activate() => Active = true;

        public void Deactivate() => Active = false;


        public void ChangeEmail(string email) => Email = email;

        public override string ToString() => FirstName + " " + LastName;
    }
}