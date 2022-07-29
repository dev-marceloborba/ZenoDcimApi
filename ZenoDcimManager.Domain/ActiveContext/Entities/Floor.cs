using System;
using System.Collections.Generic;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.ZenoContext.Entities
{
    public class Floor : Entity
    {
        public string Name { get; set; }
        public List<Room> Rooms { get; set; } = new List<Room>();
        // Navigation property
        public Guid? BuildingId { get; set; }
        public Building Building { get; set; }
    }
}