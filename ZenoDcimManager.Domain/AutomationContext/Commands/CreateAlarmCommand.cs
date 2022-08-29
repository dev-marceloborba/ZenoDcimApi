using System;
using ZenoDcimManager.Domain.AutomationContext.Enums;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.AutomationContext.Commands
{
    public class CreateAlarmCommand : ICommand
    {
        public EAlarmStatus Status { get; set; }
        public double Value { get; set; }
        public DateTime InDate { get; set; }
        public DateTime OutDate { get; set; }
        public bool Enabled { get; set; }
        public Guid AlarmRuleId { get; set; }

        public void Validate()
        {

        }
    }
}