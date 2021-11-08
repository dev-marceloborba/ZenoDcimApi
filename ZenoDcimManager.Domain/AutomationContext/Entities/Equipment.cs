using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.AutomationContext.Entities
{
    public abstract class Equipment : Entity
    {
        public string Name { get; private set; }
        public string Manufactor { get; private set; }
        public string Model { get; private set; }

        public Equipment(string name, string manufactor, string model)
        {
            Name = name;
            Manufactor = manufactor;
            Model = model;
        }
    }
}