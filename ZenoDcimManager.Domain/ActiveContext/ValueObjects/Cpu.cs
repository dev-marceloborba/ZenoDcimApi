using ZenoDcimManager.Shared.ValueObjects;
using Flunt.Validations;

namespace ZenoDcimManager.Domain.ZenoContext.ValueObjects
{
    public class Cpu : ValueObject
    {
        public string Name { get; private set; }

        public Cpu(string name)
        {
            Name = name;
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Name, 5, "Name", "CPU name needs a minimum of 5 characters")
            );
        }
    }
}