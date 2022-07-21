using System;
using System.Collections.Generic;
using ZenoDcimManager.Domain.ActiveContext.Enums;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.ActiveContext.Entities
{
    public class Equipment : Entity
    {
        public int Class { get; set; }
        public string Component { get; set; }
        public string ComponentCode { get; set; }
        public string Description { get; set; }
        public Rack Rack { get; set; }
        public RackPdu RackPdu { get; set; }
        public List<EquipmentParameter> EquipmentParameters { get; set; } = new List<EquipmentParameter>();
        public EEquipmentGroup Group { get; set; }
        public Building Building { get; set; }
        public Floor Floor { get; set; }
        public Room Room { get; set; }
        // Navigation properties
        public Guid? BuildingId { get; set; }
        public Guid? FloorId { get; set; }
        public Guid? RoomId { get; set; }
        public Guid? RackId { get; set; }
        public Guid? RackPduId { get; set; }
    }
}