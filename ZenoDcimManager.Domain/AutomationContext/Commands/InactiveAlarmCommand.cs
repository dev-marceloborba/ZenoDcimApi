using System;
using ZenoDcimManager.Domain.AutomationContext.Enums;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.AutomationContext.Commands
{
    public class InactiveAlarmCommand : ICommand
    {

        public Guid Id { get; set; }
        public DateTime OutDate { get; set; }
        public double Value { get; set; }

        public void Validate()
        {

        }
    }
}