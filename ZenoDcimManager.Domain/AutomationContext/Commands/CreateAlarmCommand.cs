using System;
using ZenoDcimManager.Domain.AutomationContext.Enums;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.AutomationContext.Commands
{
    public class CreateAlarmCommand : ICommand
    {
        public string Pathname { get; set; }
        public EAlarmStatus Status { get; set; }
        public EAlarmType Type { get; set; }
        public EAlarmPriority Priority { get; set; }
        public string Operator { get; set; }
        public double Value { get; set; }
        public DateTime InDate { get; set; }
        public DateTime? OutDate { get; set; }
        public bool Enabled { get; set; }
        public bool NotificationEnabled { get; set; }
        public bool EmailEnabled { get; set; }
        public Guid AlarmRuleId { get; set; }

        public void Validate()
        {

        }
    }
}