using EvoDcimManager.Shared;

namespace EvoDcimManager.Domain.AutomationContext.Entities
{
    public abstract class Tag : Entity
    {
        public Tag(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public void ChangeName(string name) => Name = name;

    }
}