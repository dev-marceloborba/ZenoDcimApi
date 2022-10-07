using System.Threading.Tasks;
using Flunt.Notifications;
using ZenoDcimManager.Domain.AutomationContext.Commands;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Domain.AutomationContext.Repositories;
using ZenoDcimManager.Shared.Commands;
using ZenoDcimManager.Shared.Handlers;

namespace ZenoDcimManager.Domain.AutomationContext.Handlers
{
    public class AlarmRuleHandler : Notifiable, ICommandHandler<CreateAlarmRuleCommand>
    {
        private readonly IAlarmRuleRepository _repository;

        public AlarmRuleHandler(IAlarmRuleRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(CreateAlarmRuleCommand command)
        {

            var alarmRule = new AlarmRule
            {
                Name = command.Name,
                Priority = command.Priority,
                Conditional = command.Conditional,
                Setpoint = command.Setpoint,
                EnableNotification = command.EnableNotification,
                EquipmentParameterId = command.EquipmentParameterId
            };

            await _repository.CreateAsync(alarmRule);
            await _repository.Commit();

            return new CommandResult(true, "Regra de alarme criada com sucesso", alarmRule);
        }
    }
}