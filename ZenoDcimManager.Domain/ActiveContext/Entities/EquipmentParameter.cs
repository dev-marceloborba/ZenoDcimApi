using System;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.ActiveContext.Entities
{
    public class EquipmentParameter : Entity
    {
        public string Name { get; private set; }
        public string Unit { get; private set; }
        public double LowLimit { get; private set; }
        public double HighLimit { get; private set; }
        public int Scale { get; private set; }
        public string DataSource { get; private set; }
        public string Address { get; private set; }
        // Navigations Property
        public Guid? EquipmentParameterGroupId { get; private set; }
        public Guid? EquipmentId { get; private set; }

        public EquipmentParameter ()
        {

        }

        public EquipmentParameter(string name, string unit, double lowLimit, double highLimit, int scale, string dataSource, string address, Guid equipmentId)
        {
            Name = name;
            Unit = unit;
            LowLimit = lowLimit;
            HighLimit = highLimit;
            Scale = scale;
            DataSource = dataSource;
            Address = address;
            EquipmentId = equipmentId;
        }
    }
}