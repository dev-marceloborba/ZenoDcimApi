using ZenoDcimManager.Shared.ValueObjects;
using Flunt.Validations;

namespace ZenoDcimManager.Domain.ZenoContext.ValueObjects
{
    public class Capacity : ValueObject
    {
        public int Value { get; private set; }

        public Capacity(int value)
        {
            Value = value;
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(Value, 0, "Capacity", "Capacity should be greater than zero")
            );
        }
    }
}