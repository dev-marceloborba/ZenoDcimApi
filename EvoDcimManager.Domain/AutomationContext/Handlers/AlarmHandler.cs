using EvoDcimManager.Domain.AutomationContext.Commands;
using EvoDcimManager.Domain.AutomationContext.Entities;
using EvoDcimManager.Domain.AutomationContext.Repositories;
using EvoDcimManager.Domain.AutomationContext.Validators;
using EvoDcimManager.Shared.Commands;
using EvoDcimManager.Shared.Handlers;
using Flunt.Notifications;

namespace EvoDcimManager.Domain.AutomationContext.Handlers
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