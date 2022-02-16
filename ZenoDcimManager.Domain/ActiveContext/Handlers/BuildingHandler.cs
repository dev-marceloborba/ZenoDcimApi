using Flunt.Notifications;
using ZenoDcimManager.Domain.ActiveContext.Commands.Inputs;
using ZenoDcimManager.Domain.ActiveContext.Entities;
using ZenoDcimManager.Domain.ActiveContext.Repositories;
using ZenoDcimManager.Shared.Commands;
using ZenoDcimManager.Shared.Handlers;

namespace ZenoDcimManager.Domain.ActiveContext.Handlers
{
    public class BuildingHandler : Notifiable,
        ICommandHandler<CreateBuildingCommand>,
        ICommandHandler<CreateFloorCommand>,
        ICommandHandler<CreateRoomCommand>,
        ICommandHandler<CreateEquipmentCommand>
    {
        private readonly IDataCenterRepository _dataCenterRepository;

        public BuildingHandler(IDataCenterRepository dataCenterRepository)
        {
            _dataCenterRepository = dataCenterRepository;
        }

        public ICommandResult Handle(CreateBuildingCommand command)
        {
            var building = new Building(command.Campus, command.Name);

            _dataCenterRepository.AddBuilding(building);

            return new CommandResult(true, "Prédio criado com sucesso", null);
        }

        public ICommandResult Handle(CreateFloorCommand command)
        {
            var building = _dataCenterRepository.FindBuildingById(command.BuildingId);

            building.AddFloor(new Floor(command.Name));

            _dataCenterRepository.AddFloor(building);

            return new CommandResult(true, "Andar criado com sucesso", null);
        }

        public ICommandResult Handle(CreateRoomCommand command)
        {
            var floor = _dataCenterRepository.FindFloorById(command.FloorId);

            floor.AddRoom(new Room(command.Name));

            _dataCenterRepository.AddRoom(floor);

            return new CommandResult(true, "Sala criada com sucesso", null);
        }

        public ICommandResult Handle(CreateEquipmentCommand command)
        {
            var equipment = new Equipment(
                command.Class,
                command.Component,
                command.ComponentCode,
                command.Description,
                null,
                null);

            var room = _dataCenterRepository.FindRoomById(command.RoomId);
            room.AddEquipment(equipment);

            _dataCenterRepository.AddEquipment(room);

            return new CommandResult(true, "Equipamento criado com sucesso", null);
        }
    }
}