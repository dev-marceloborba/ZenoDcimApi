using System.Collections.Generic;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.DataCenterContext.Entities
{
    public class Floor : Entity
    {
        public string Name { get; private set; }
        public List<Room> Rooms { get; private set; } = new List<Room>();

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