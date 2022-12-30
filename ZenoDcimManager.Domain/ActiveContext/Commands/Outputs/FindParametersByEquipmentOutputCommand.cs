using System;
using System.Collections.Generic;
using ZenoDcimManager.Domain.ActiveContext.Entities;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Domain.ZenoContext.Entities;

namespace ZenoDcimManager.Domain.ActiveContext.Commands.Outputs
{
    public class FindParametersByEquipmentOutputCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public double LowLowLimit { get; set; }
        public double LowLimit { get; set; }
        public double HighLimit { get; set; }
        public double HighHighLimit { get; set; }
        public int Scale { get; set; }
        public string DataSource { get; set; }
        public string Expression { get; set; }

        // Navigations Property
        public Guid? EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
        public string ModbusTagName { get; set; }

        public RealtimeData Data { get; set; }
        public List<AlarmRule> AlarmRules { get; set; }
        public string Pathname { get; set; }
    }
}