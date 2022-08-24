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
    public class AlarmHandler : Notifiable, ICommandHandler<CreateAlarmCommand>
    {
        private readonly IAlarmRepository _repository;

        public AlarmHandler(IAlarmRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(CreateAlarmCommand command)
        {
            var alarm = new Alarm
            {
                Value = command.Value,
                Enabled = command.Enabled,
                Status = command.Status,
                AlarmRuleId = command.AlarmRuleId
            };

            // var alarmValidator = new AlarmValidator(alarm);

            // AddNotifications(alarmValidator);

            // if (alarmValidator.Invalid)
            //     return new CommandResult(false, "Error on creating alarm", alarmValidator.Notifications);

            await _repository.CreateAsync(alarm);
            await _repository.Commit();

            return new CommandResult(true, "Alarm created successful", alarm);
        }
    }
}