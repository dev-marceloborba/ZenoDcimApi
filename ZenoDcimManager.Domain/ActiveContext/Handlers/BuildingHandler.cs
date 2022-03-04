using System.Linq;
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
        ICommandHandler<CreateEquipmentCommand>,
        ICommandHandler<CreateMultipleEquipmentsCommand>
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
            _dataCenterRepository.Commit();

            return new CommandResult(true, "Prédio criado com sucesso", null);
        }

        public ICommandResult Handle(CreateFloorCommand command)
        {
            var building = _dataCenterRepository.FindBuildingById(command.BuildingId);

            building.AddFloor(new Floor(command.Name));

            _dataCenterRepository.AddFloor(building);
            _dataCenterRepository.Commit();

            return new CommandResult(true, "Andar criado com sucesso", null);
        }

        public ICommandResult Handle(CreateRoomCommand command)
        {
            var building = _dataCenterRepository.FindBuildingById(command.BuildingId);
            var floor = building.Floors.Find(x => x.Id == command.FloorId);

            floor.AddRoom(new Room(command.Name));

            _dataCenterRepository.AddRoom(floor);
            _dataCenterRepository.Commit();

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
            _dataCenterRepository.Commit();

            return new CommandResult(true, "Equipamento criado com sucesso", null);
        }

        public ICommandResult Handle(CreateMultipleEquipmentsCommand command)
        {
            var firstCommand = command.Equipments.ToArray()[0];

            var building = _dataCenterRepository.FindBuildingById(firstCommand.BuildingId);
            // return new CommandResult(true, "Equipamentos criados com sucesso", command);
            foreach (var item in command.Equipments)
            {
                var floor = building.Floors.Find(x => x.Id == item.FloorId);
                var room = floor.Rooms.Find(x => x.Id == item.RoomId);

                var equipment = new Equipment(item.Class, item.Component, item.ComponentCode, item.Description, null, null);

                room.AddEquipment(equipment);

            }

            _dataCenterRepository.AddEquipment(building);
            _dataCenterRepository.Commit();

            // foreach (var floor in building.Floors)
            // {
            //     foreach (var room in floor.Rooms)
            //     {
            //         foreach (var equipment in room.Equipments)
            //         {
            //             _dataCenterRepository.AddEquipment(equipment);
            //         }
            //     }
            // }

            return new CommandResult(true, "Equipamentos criados com sucesso", building);
        }
    }
}