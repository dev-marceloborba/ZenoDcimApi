using System;
using ZenoDcimManager.Domain.AutomationContext.Enums;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.AutomationContext.Entities
{
    public class Alarm : Entity
    {
        public string Pathname { get; set; }
        public double Value { get; set; }
        public DateTime InDate { get; set; }
        public DateTime? OutDate { get; set; }
        public DateTime? RecognizedDate { get; set; }
        public EAlarmStatus Status { get; set; } = EAlarmStatus.INACTIVE;
        public bool Enabled { get; set; } = true;
        public TimeSpan AckInterval { get; set; }
        public EAlarmPriority Priority { get; set; }
        public bool NotificationEnabled { get; set; }
        public bool EmailEnabled { get; set; }

        public Guid AlarmRuleId { get; set; }
        public AlarmRule AlarmRule { get; set; }
    }
}