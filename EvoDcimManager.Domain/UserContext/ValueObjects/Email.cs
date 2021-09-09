using EvoDcimManager.Shared.Entities;
using Flunt.Validations;

namespace EvoDcimManager.Domain.UserContext.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Address, "Address", "E-mail invalido")
            );
        }

        public string Address { get; private set; }
    }
}