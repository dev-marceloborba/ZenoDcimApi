using System;
using System.Collections.Generic;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.ZenoContext.Entities
{
    public class Room : Entity
    {
        public string Name { get; set; }
        public List<Equipment> Equipments { get; set; } = new List<Equipment>();
        // Navigation property
        public Guid? FloorId { get; set; }
    }
}