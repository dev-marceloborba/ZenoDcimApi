using System.Threading.Tasks;
using Flunt.Notifications;
using ZenoDcimManager.Domain.ZenoContext.Commands.Inputs;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Domain.ZenoContext.Repositories;
using ZenoDcimManager.Shared.Commands;
using ZenoDcimManager.Shared.Handlers;

namespace ZenoDcimManager.Domain.ZenoContext.Handlers
{
    public class EquipmentHandler : Notifiable,
        ICommandHandler<CreateEquipmentCommand>,
        ICommandHandler<CreateMultipleEquipmentsCommand>
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentHandler(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public async Task<ICommandResult> Handle(CreateEquipmentCommand command)
        {
            var equipment = new Equipment
            {
                Component = command.Component,
                ComponentCode = command.ComponentCode,
                Group = command.Group,
                Description = command.Description,
                BuildingId = command.BuildingId,
                FloorId = command.FloorId,
                RoomId = command.RoomId,
                Weight = command.Weight,
                Size = command.Size,
                PowerLimit = command.PowerLimit,
                Manufactor = command.Manufactor,
                Status = command.Status
            };

            await _equipmentRepository.CreateAsync(equipment);
            await _equipmentRepository.Commit();

            return new CommandResult(true, "Equipamento criado com sucesso", equipment);
        }

        public async Task<ICommandResult> Handle(CreateMultipleEquipmentsCommand command)
        {
            foreach (var item in command.Equipments)
            {
                var equipment = new Equipment
                {
                    Component = item.Component,
                    ComponentCode = item.ComponentCode,
                    Group = item.Group,
                    Description = item.Description,
                    RoomId = item.RoomId,
                    Weight = item.Weight,
                    Size = item.Size,
                    PowerLimit = item.PowerLimit,
                };

                await _equipmentRepository.CreateAsync(equipment);
            }

            await _equipmentRepository.Commit();

            return new CommandResult(true, "Equipamentos criados com sucesso", null);
        }
    }
}