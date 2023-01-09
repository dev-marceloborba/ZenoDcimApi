using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using ZenoDcimManager.Domain.ZenoContext.Commands.Inputs;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Domain.ZenoContext.Repositories;
using ZenoDcimManager.Shared.Commands;
using ZenoDcimManager.Shared.Handlers;

namespace ZenoDcimManager.Domain.ZenoContext.Handlers
{
    public class ParameterGroupHandler : Notifiable,
        ICommandHandler<CreateEquipmentParameterGroupCommand>,
        ICommandHandler<CreateEquipmentOnGroupCommand>
    {
        private readonly IEquipmentParameterGroupRepository _parameterGroupRepository;
        private readonly IParameterRepository _parameterRepository;

        public ParameterGroupHandler(IEquipmentParameterGroupRepository parameterGroupRepository, IParameterRepository parameterRepository)
        {
            _parameterGroupRepository = parameterGroupRepository;
            _parameterRepository = parameterRepository;
        }

        public async Task<ICommandResult> Handle(CreateEquipmentParameterGroupCommand command)
        {
            var parameterGroupAssignments = new List<ParameterGroupAssignment>();

            var equipmentParameterGroup = new EquipmentParameterGroup
            {
                Name = command.Name,
                Group = command.Group,
            };

            foreach (var parameterId in command.ParametersId)
            {
                parameterGroupAssignments.Add(new ParameterGroupAssignment
                {
                    EquipmentParameterGroupId = equipmentParameterGroup.Id,
                    Parameter = await _parameterRepository.FindByIdAsync(parameterId)
                });
            }

            equipmentParameterGroup.ParameterGroupAssignments = parameterGroupAssignments;

            await _parameterGroupRepository.CreateAsync(equipmentParameterGroup);
            await _parameterGroupRepository.Commit();

            return new CommandResult(true, "Grupo de parâmetros criado com sucesso", equipmentParameterGroup);
        }

        public async Task<ICommandResult> Handle(CreateEquipmentOnGroupCommand command)
        {
            var group = await _parameterGroupRepository.FindByIdAsync(command.GroupId);

            var parameterList = new HashSet<ParameterGroupAssignment>();

            foreach (var item in command.Parameters)
            {
                parameterList.Add(new ParameterGroupAssignment()
                {
                    ParameterId = item.Id,
                    EquipmentParameterGroupId = group.Id
                });
            }

            group.ParameterGroupAssignments = parameterList.ToList();
            group.TrackModifiedDate();
            await _parameterGroupRepository.Commit();

            return new CommandResult(true, "Grupo atualizado com sucesso", group);
        }
    }
}