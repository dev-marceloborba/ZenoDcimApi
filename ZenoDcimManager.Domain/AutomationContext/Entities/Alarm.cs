using System;
using ZenoDcimManager.Domain.AutomationContext.Enums;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.AutomationContext.Entities
{
    public class Alarm : Entity
    {
        public string Pathname { get; set; }
        public double Value { get; set; }
        public DateTime? InDate { get; set; }
        public DateTime? OutDate { get; set; }
        public EAlarmStatus Status { get; set; } = EAlarmStatus.INACTIVE;
        public bool Enabled { get; set; } = true;

        public Guid AlarmRuleId { get; set; }
        public AlarmRule AlarmRule { get; set; }
    }
}