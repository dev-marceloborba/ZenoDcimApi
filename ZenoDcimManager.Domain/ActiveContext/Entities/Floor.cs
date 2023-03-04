using System;
using System.Collections.Generic;
using ZenoDcimManager.Shared;
using ZenoDcimManager.Shared.Interfaces;

namespace ZenoDcimManager.Domain.ZenoContext.Entities
{
    public class Floor : Entity,
        IPrototype<Floor>,
        IDuplicate<Floor>
    {
        public string Name { get; set; }
        public List<Room> Rooms { get; set; } = new List<Room>();
        // Navigation property
        public Guid? BuildingId { get; set; }
        public Building Building { get; set; }

        public Floor Clone()
        {
            var clone = (Floor)MemberwiseClone();
            clone.SetId(Guid.NewGuid());
            return clone;
        }

        public int GetRoomsQuantity() => Rooms.Count;

        public Floor Duplicate()
        {
            var duplicated = Clone();
            duplicated.Name = duplicated.Name + " - cópia";
            return duplicated;
        }

        public string GetPathname()
        {
            return Building.Site.Name + '*' + Building.Name + '*' + Name;
        }
    }
}