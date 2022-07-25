using System.Threading.Tasks;
using Flunt.Notifications;
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
                HighLimit = command.HighLimit,
                LowLimit = command.LowLimit,
                Scale = command.Scale,
                DataSource = command.DataSource,
                EquipmentId = command.EquipmentId,
            };

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
                    HighLimit = item.HighLimit,
                    LowLimit = item.LowLimit,
                    Scale = item.Scale,
                    DataSource = item.DataSource,
                    EquipmentId = item.EquipmentId,
                };

                await _equipmentParameterRepository.CreateAsync(parameter);
            }

            await _equipmentParameterRepository.Commit();

            return new CommandResult(true, "Parametros criados com sucesso", null);
        }
    }
}