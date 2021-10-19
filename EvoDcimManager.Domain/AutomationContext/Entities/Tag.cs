using EvoDcimManager.Shared;

namespace EvoDcimManager.Domain.AutomationContext.Entities
{
    public abstract class Tag : Entity
    {
        protected Tag(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

    }
}