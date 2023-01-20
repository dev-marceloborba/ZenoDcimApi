using System;
using ZenoDcimManager.Domain.AutomationContext.Enums;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Shared;
using ZenoDcimManager.Shared.Interfaces;

namespace ZenoDcimManager.Domain.AutomationContext.Entities
{
    public class AlarmRule : Entity,
        IPrototype<AlarmRule>,
        IDuplicate<AlarmRule>
    {
        public string Name { get; set; }
        public EAlarmPriority Priority { get; set; }
        public EAlarmConditonal Conditional { get; set; }
        public double Setpoint { get; set; }
        public bool EnableNotification { get; set; }
        public bool EnableEmail { get; set; }
        public EAlarmType Type { get; set; }

        public Guid? EquipmentParameterId { get; set; }
        public EquipmentParameter EquipmentParameter { get; set; }

        public AlarmRule Clone()
        {
            var clone = (AlarmRule)MemberwiseClone();
            clone.SetId(Guid.NewGuid());
            return clone;
        }

        public AlarmRule Duplicate()
        {
            var duplicated = Clone();
            duplicated.Name = duplicated.Name + " - cópia";
            return duplicated;
        }
    }
}