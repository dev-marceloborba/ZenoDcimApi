using ZenoDcimManager.Domain.AutomationContext.Enums;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.AutomationContext.Entities
{
    public class Alarm : Entity
    {
        public string Name { get; set; }
        public string MessageOn { get; set; }
        public string MessageOff { get; set; }
        public EAlarmPriority AlarmPriority { get; set; }
        public EAlarmStatus Status { get; set; } = EAlarmStatus.INACTIVE;
        public double Setpoint { get; set; }
        public bool Enabled { get; set; } = true;
        public string TagName { get; set; }
    }
}