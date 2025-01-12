using ZenoDcimManager.Domain.AutomationContext.ValueObjects;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.AutomationContext.Entities
{
    public abstract class Tag : Entity
    {
        public Tag(string name, double deadband)
        {
            Name = name;
            Deadband = deadband;
        }

        public string Name { get; private set; }
        public double Deadband { get; private set; }
        public void ChangeName(string name) => Name = name;
    }
}