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

    }
}