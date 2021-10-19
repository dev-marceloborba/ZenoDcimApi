using EvoDcimManager.Domain.AutomationContext.Enums;
using EvoDcimManager.Shared;

namespace EvoDcimManager.Domain.AutomationContext.Entities
{
    public class Alarm : Entity
    {
        public Alarm(string name, EAlarmPriority alarmPriority, double setpoint)
        {
            Name = name;
            AlarmPriority = alarmPriority;
            Setpoint = setpoint;
            Enabled = true;
        }

        public string Name { get; private set; }
        public EAlarmPriority AlarmPriority { get; private set; }
        public double Setpoint { get; private set; }
        public bool Enabled { get; private set; }

        public void ChangeName(string name) => Name = name;
        public void ChangePriority(EAlarmPriority alarmPriority) => AlarmPriority = alarmPriority;
        public void ChangeSetpoint(double setpoint) => Setpoint = setpoint;

        public void EnableAlarm()
        {
            Enabled = true;
        }

        public void DisableAlarm()
        {
            Enabled = false;
        }
    }
}