using System;
using System.Collections.Generic;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Domain.ZenoContext.Enums;
using ZenoDcimManager.Shared;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ZenoDcimManager.Domain.ZenoContext.Entities
{
    public class Equipment : Entity
    {
        public string Component { get; set; }
        public string ComponentCode { get; set; }
        public string Description { get; set; }
        public string Manufactor { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public EEquipmentStatus Status { get; set; }
        public Rack Rack { get; set; }
        public RackPdu RackPdu { get; set; }
        public List<EquipmentParameter> EquipmentParameters { get; set; } = new List<EquipmentParameter>();
        public EEquipmentGroup Group { get; set; }
        public Site Site { get; set; }
        public Building Building { get; set; }
        public Floor Floor { get; set; }
        public Room Room { get; set; }
        public double Weight { get; set; }
        public string Size { get; set; }
        public double PowerLimit { get; set; }
        public EquipmentCardSettings CardSettings { get; set; }
        // Navigation properties
        public Guid? SiteId { get; set; }
        public Guid? BuildingId { get; set; }
        public Guid? FloorId { get; set; }
        public Guid? RoomId { get; set; }
        public Guid? RackId { get; set; }
        public Guid? RackPduId { get; set; }

        public override string ToString()
        {
            return Component;
        }

        public string GetPathname()
        {
            return Room.Floor.Building.Site.Name + '*' + Room.Floor.Building.Name + '*' + Room.Floor.Name + '*' + Room.Name + '*' + this.ToString();
        }
    }
}