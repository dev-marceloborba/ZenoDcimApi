using ZenoDcimManager.Domain.AutomationContext.Enums;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.AutomationContext.Commands
{
    public class AlarmCommand : ICommand
    {
        public string Name { get; set; }
        public string MessageIn { get; set; }
        public string MessageOff { get; set; }
        public EAlarmPriority AlarmPriority { get; private set; }
        public double Setpoint { get; private set; }
        public bool Enabled { get; private set; }

        public void Validate()
        {

        }
    }
}