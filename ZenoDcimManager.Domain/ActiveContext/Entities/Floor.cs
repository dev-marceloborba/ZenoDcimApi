using System;
using System.Collections.Generic;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.ActiveContext.Entities
{
    public class Floor : Entity
    {
        public string Name { get; private set; }
        public List<Room> Rooms { get; private set; } = new List<Room>();
        // Navigation property
        public Guid? BuildingId { get; private set; }

        public Floor () { }

        public Floor(string name, Guid buildingId)
        {
            Name = name;
            BuildingId = buildingId;
        }

        public void AddRoom(Room room)
        {
            Rooms.Add(room);
        }

        public void RemoveRoom(Room room)
        {
            Rooms.Remove(room);
        }
    }
}