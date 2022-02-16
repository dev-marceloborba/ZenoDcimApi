using System.Collections.Generic;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.ActiveContext.Entities
{
    public class Room : Entity
    {
        public string Name { get; private set; }
        public List<Equipment> Equipments { get; private set; } = new List<Equipment>();

        public Room(string name)
        {
            Name = name;
        }

        public void AddEquipment(Equipment equipment)
        {
            Equipments.Add(equipment);
        }

        public void RemoveEquipment(Equipment equipment)
        {
            Equipments.Remove(equipment);
        }
    }
}