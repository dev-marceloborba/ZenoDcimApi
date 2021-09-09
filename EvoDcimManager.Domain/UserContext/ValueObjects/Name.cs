using EvoDcimManager.Shared.Entities;
using Flunt.Validations;

namespace EvoDcimManager.Domain.UserContext.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "FirstName", "Minimo de 3 caracteres")
                .HasMaxLen(FirstName, 40, "FirstName", "Maximo de 40 caracteres")
                .HasMinLen(LastName, 3, "LastName", "Minimo de 3 caracteres")
                .HasMaxLen(LastName, 40, "LastName", "Maximo de 40 caracteres")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}