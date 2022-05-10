using System;
using Flunt.Notifications;
using ZenoDcimManager.Shared.ValueObjects;

namespace ZenoDcimManager.Shared
{
    public abstract class Entity : DateTracker, IEquatable<Entity>
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; private set; }

        public bool Equals(Entity other)
        {
            return Id == other.Id;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}