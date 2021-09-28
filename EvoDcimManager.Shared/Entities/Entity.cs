using System;
using Flunt.Notifications;

namespace EvoDcimManager.Shared
{
    public abstract class Entity : Notifiable
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        // public int Id { get; set; }
    }
}