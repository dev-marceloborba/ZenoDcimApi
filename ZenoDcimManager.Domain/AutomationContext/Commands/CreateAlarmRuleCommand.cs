using System;
using ZenoDcimManager.Domain.AutomationContext.Enums;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.AutomationContext.Commands
{
    public class CreateAlarmRuleCommand : ICommand
    {
        public string Name { get; set; }
        public EAlarmPriority Priority { get; set; }
        public EAlarmConditonal Conditional { get; set; }
        public double Setpoint { get; set; }
        public bool EnableNotification { get; set; }
        public bool EnableEmail { get; set; }
        public Guid EquipmentParameterId { get; set; }
        public void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}