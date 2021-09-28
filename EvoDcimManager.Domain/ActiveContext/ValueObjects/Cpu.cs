using EvoDcimManager.Shared;
using EvoDcimManager.Shared.Entities;
using Flunt.Validations;

namespace EvoDcimManager.Domain.ActiveContext.ValueObjects
{
    public class Cpu : Entity
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