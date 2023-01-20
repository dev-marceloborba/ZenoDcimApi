using System;
using System.Collections.Generic;
using ZenoDcimManager.Domain.AutomationContext.Commands;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.ZenoContext.Commands.Inputs
{
    public class CreateEquipmentParameterCommand : ICommand
    {
        public Guid EquipmentId { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public int Scale { get; set; }
        public string DataSource { get; set; }
        public string Address { get; set; }
        public string Expression { get; set; }
        public List<CreateAlarmRuleCommand> AlarmRules { get; set; } = new();
        public void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}