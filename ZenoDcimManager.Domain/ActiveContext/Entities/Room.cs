using System;
using System.Collections.Generic;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.ZenoContext.Entities
{
    public class Room : Entity
    {
        public string Name { get; set; }
        public List<Equipment> Equipments { get; set; } = new List<Equipment>();
        // Navigation property
        public Guid? FloorId { get; set; }
        public Floor Floor { get; set; }
        public Guid? BuildingId { get; set; }
        public Building Building { get; set; }
        public RoomCardSettings CardSettings { get; set; }
        public string GetPathname()
        {
            return Floor.Building.Site.Name + '*' + Floor.Building.Name + '*' + Floor.Name + '*' + Name;
        }
    }
}