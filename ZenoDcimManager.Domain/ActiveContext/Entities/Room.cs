using System;
using System.Collections.Generic;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.ActiveContext.Entities
{
    public class Room : Entity
    {
        public string Name { get; private set; }
        public List<Equipment> Equipments { get; private set; } = new List<Equipment>();
        // Navigation property
        public Guid? FloorId { get; private set; }

        public Room () { }

        public Room(string name, Guid floorId)
        {
            Name = name;
            FloorId = FloorId;
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