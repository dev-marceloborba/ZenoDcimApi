using System;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.AutomationContext.Commands
{
    public class RecognizeAlarmCommand : ICommand
    {
        public Guid AlarmId { get; set; }
        public DateTime RecognizedDate { get; set; }
        public void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}