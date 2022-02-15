using System.Collections.Generic;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.DataCenterContext.Entities
{
    public class Room : Entity
    {
        public string Name { get; private set; }
        public List<Equipment> Equipments { get; private set; }

        public Room(string name)
        {
            Name = name;
        }
    }
}