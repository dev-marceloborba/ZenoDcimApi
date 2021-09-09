using EvoDcimManager.Shared.Entities;
using Flunt.Validations;

namespace EvoDcimManager.Domain.ActiveContext.ValueObjects
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