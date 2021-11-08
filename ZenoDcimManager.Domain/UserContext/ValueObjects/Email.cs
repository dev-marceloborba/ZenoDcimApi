using ZenoDcimManager.Shared.ValueObjects;
using Flunt.Validations;

namespace ZenoDcimManager.Domain.UserContext.ValueObjects
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