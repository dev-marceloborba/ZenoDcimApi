using ZenoDcimManager.Domain.AutomationContext.Commands;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Domain.AutomationContext.Repositories;
using ZenoDcimManager.Domain.AutomationContext.Validators;
using ZenoDcimManager.Shared.Commands;
using ZenoDcimManager.Shared.Handlers;
using Flunt.Notifications;

namespace ZenoDcimManager.Domain.AutomationContext.Handlers
{
    public class AlarmHandler : Notifiable, ICommandHandler<AlarmCommand>
    {
        private readonly IAlarmRepository _alarmRepository;

        public AlarmHandler(IAlarmRepository alarmRepository)
        {
            _alarmRepository = alarmRepository;
        }

        public ICommandResult Handle(AlarmCommand command)
        {
            var alarm = new Alarm(
                command.MessageIn,
                command.MessageOff,
                command.Name,
                command.AlarmPriority,
                command.Setpoint
            );

            var alarmValidator = new AlarmValidator(alarm);

            AddNotifications(alarmValidator);

            if (alarmValidator.Invalid)
                return new CommandResult(false, "Error on creating alarm", alarmValidator.Notifications);

            _alarmRepository.Save(alarm);
            return new CommandResult(true, "Alarm created successful", alarm);
        }
    }
}