using ZenoDcimManager.Shared.ValueObjects;
using Flunt.Validations;

namespace ZenoDcimManager.Domain.ZenoContext.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string value)
        {
            Value = value;
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(Value, "Value", "Value cannot be empty or null")
                    .HasMinLen(Value, 4, "Value", "Value should have at least 4 characteres")
            );
        }

        public string Value { get; private set; }
    }
}