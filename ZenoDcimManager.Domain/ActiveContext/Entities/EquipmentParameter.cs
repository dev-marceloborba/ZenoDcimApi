using System;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.ZenoContext.Entities
{
    public class EquipmentParameter : Entity
    {
        public string Name { get; set; }
        public string Unit { get; set; }
        public double LowLimit { get; set; }
        public double HighLimit { get; set; }
        public int Scale { get; set; }
        public string DataSource { get; set; }

        // Navigations Property
        public Guid? EquipmentId { get; set; }
        public string? ModbusTagName { get; set; }
    }
}