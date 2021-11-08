using ZenoDcimManager.Domain.AutomationContext.Enums;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.AutomationContext.Entities
{
    public class Alarm : Entity
    {
        public Alarm(string name, string messageOn, string messageOff, EAlarmPriority alarmPriority, double setpoint)
        {
            Name = name;
            MessageOn = messageOn;
            MessageOff = messageOff;
            AlarmPriority = alarmPriority;
            Setpoint = setpoint;
            Enabled = true;
            Status = EAlarmStatus.INACTIVE;
        }

        public string Name { get; private set; }
        public string MessageOn { get; private set; }
        public string MessageOff { get; private set; }
        public EAlarmPriority AlarmPriority { get; private set; }
        public EAlarmStatus Status { get; private set; }
        public double Setpoint { get; private set; }
        public bool Enabled { get; private set; }

        public void ChangeName(string name) => Name = name;
        public void ChangePriority(EAlarmPriority alarmPriority) => AlarmPriority = alarmPriority;
        public void ChangeSetpoint(double setpoint) => Setpoint = setpoint;
        public void EnableAlarm() => Enabled = true;
        public void DisableAlarm() => Enabled = false;

        public void Activate() => Status = EAlarmStatus.ACTIVE;
        public void Inactivate() => Status = EAlarmStatus.INACTIVE;
        public void Ack() => Status = EAlarmStatus.ACKED;
    }
}