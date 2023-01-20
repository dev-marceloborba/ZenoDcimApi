using System.Threading.Tasks;
using Flunt.Notifications;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Domain.ZenoContext.Commands.Inputs;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Domain.ZenoContext.Repositories;
using ZenoDcimManager.Shared.Commands;
using ZenoDcimManager.Shared.Handlers;

namespace ZenoDcimManager.Domain.ZenoContext.Handlers
{
    public class EquipmentParameterHandler : Notifiable,
        ICommandHandler<CreateEquipmentParameterCommand>,
        ICommandHandler<CreateMultipleParametersCommand>
    {
        private readonly IEquipmentParameterRepository _equipmentParameterRepository;

        public EquipmentParameterHandler(IEquipmentParameterRepository equipmentParameterRepository)
        {
            _equipmentParameterRepository = equipmentParameterRepository;
        }

        public async Task<ICommandResult> Handle(CreateEquipmentParameterCommand command)
        {
            var parameter = new EquipmentParameter
            {
                Name = command.Name,
                Unit = command.Unit,
                Scale = command.Scale,
                DataSource = command.DataSource,
                EquipmentId = command.EquipmentId,
                Expression = command.Expression
            };

            foreach (var alarmRule in command.AlarmRules)
            {
                parameter.AlarmRules.Add(new AlarmRule
                {
                    Name = alarmRule.Name,
                    Conditional = alarmRule.Conditional,
                    EnableEmail = alarmRule.EnableEmail,
                    EnableNotification = alarmRule.EnableNotification,
                    Priority = alarmRule.Priority,
                    Setpoint = alarmRule.Setpoint
                });
            }

            await _equipmentParameterRepository.CreateAsync(parameter);
            await _equipmentParameterRepository.Commit();

            return new CommandResult(true, "Parametro criado com sucesso", parameter);
        }

        public async Task<ICommandResult> Handle(CreateMultipleParametersCommand command)
        {
            foreach (var item in command.Parameters)
            {
                var parameter = new EquipmentParameter
                {
                    Name = item.Name,
                    Unit = item.Unit,
                    Scale = item.Scale,
                    DataSource = item.DataSource,
                    EquipmentId = item.EquipmentId,
                    Expression = item.Expression
                };

                await _equipmentParameterRepository.CreateAsync(parameter);
            }

            await _equipmentParameterRepository.Commit();

            return new CommandResult(true, "Parametros criados com sucesso", null);
        }
    }
}