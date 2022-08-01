using System;
using ZenoDcimManager.Domain.AutomationContext.Enums;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.AutomationContext.Entities
{
    public class AlarmRule : Entity
    {
        public string Name { get; set; }
        public EAlarmPriority Priority { get; set; }
        public EAlarmConditonal Conditional { get; set; }
        public double Setpoint { get; set; }

        public Guid? EquipmentParameterId { get; set; }
        public EquipmentParameter EquipmentParameter { get; set; }
    }
}