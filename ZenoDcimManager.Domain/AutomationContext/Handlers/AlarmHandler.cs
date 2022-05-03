using ZenoDcimManager.Domain.AutomationContext.Commands;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Domain.AutomationContext.Repositories;
using ZenoDcimManager.Domain.AutomationContext.Validators;
using ZenoDcimManager.Shared.Commands;
using ZenoDcimManager.Shared.Handlers;
using Flunt.Notifications;
using System.Threading.Tasks;

namespace ZenoDcimManager.Domain.AutomationContext.Handlers
{
    public class AlarmHandler : Notifiable, ICommandHandler<AlarmCommand>
    {
        private readonly IAlarmRepository _alarmRepository;

        public AlarmHandler(IAlarmRepository alarmRepository)
        {
            _alarmRepository = alarmRepository;
        }

        public async Task<ICommandResult> Handle(AlarmCommand command)
        {
            var alarm = new Alarm()
            {
                MessageOn = command.MessageIn,
                MessageOff = command.MessageOff,
                Name = command.Name,
                AlarmPriority = command.AlarmPriority,
                Setpoint = command.Setpoint
            };
                

            var alarmValidator = new AlarmValidator(alarm);

            AddNotifications(alarmValidator);

            if (alarmValidator.Invalid)
                return new CommandResult(false, "Error on creating alarm", alarmValidator.Notifications);

            _alarmRepository.Save(alarm);
            await _alarmRepository.Commit();

            return new CommandResult(true, "Alarm created successful", alarm);
        }
    }
}