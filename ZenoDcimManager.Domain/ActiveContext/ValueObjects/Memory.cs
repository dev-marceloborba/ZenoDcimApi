using ZenoDcimManager.Shared.ValueObjects;
using Flunt.Validations;

namespace ZenoDcimManager.Domain.ZenoContext.ValueObjects
{
    public class Memory : ValueObject
    {
        public int Value { get; private set; }

        public Memory(int value)
        {
            Value = value;
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(Value, 0, "Memory", "Memory should be greater than zero")
            );
        }
    }
}