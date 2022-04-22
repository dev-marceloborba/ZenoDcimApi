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
        ICommandHandler<CreateMultipleEquipmentsCommand>,
        ICommandHandler<CreateEquipmentParameterCommand>,
        ICommandHandler<CreateMultipleParametersCommand>,
        ICommandHandler<CreateEquipmentParameterGroupCommand>
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
                null,
                command.Group,
                command.Status,
                command.Alarms
                );

            var room = _dataCenterRepository.FindRoomById(command.RoomId);
            room.AddEquipment(equipment);

            _dataCenterRepository.AddEquipment(room);
            _dataCenterRepository.Commit();

            return new CommandResult(true, "Equipamento criado com sucesso", null);
        }

        public ICommandResult Handle(CreateMultipleEquipmentsCommand command)
        {
            foreach (var item in command.Equipments)
            {
                var building = _dataCenterRepository.FindBuildingById(item.BuildingId);
                var floor = building.Floors.Find(x => x.Id == item.FloorId);
                var room = floor.Rooms.Find(x => x.Id == item.RoomId);

                var equipment = new Equipment(
                    item.Class,
                    item.Component,
                    item.ComponentCode,
                    item.Description,
                    null,
                    null,
                    item.Group,
                    item.Status,
                    item.Alarms
                    );

                room.AddEquipment(equipment);
                _dataCenterRepository.AddEquipment(building);

            }

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

            return new CommandResult(true, "Equipamentos criados com sucesso", null);
        }

        public ICommandResult Handle(CreateEquipmentParameterCommand command)
        {
            var equipment = _dataCenterRepository.FindEquipmentById(command.EquipmentId);

            var parameter = new EquipmentParameter(
                command.Name,
                command.Unit,
                command.LowLimit,
                command.HighLimit,
                command.Scale,
                command.DataSource,
                command.Address);

            //equipment.ClearList();

            equipment.AddEquipmentParameter(parameter);

            _dataCenterRepository.AddEquipmentParameter(equipment);
            _dataCenterRepository.Commit();

            return new CommandResult(true, "Parametro criado com sucesso", null);
        }

        public ICommandResult Handle(CreateMultipleParametersCommand command)
        {

            Equipment equipment = null;

            foreach (var item in command.Parameters)
            {
                if (equipment is null)
                { 
                    equipment = _dataCenterRepository.FindEquipmentById(item.EquipmentId);
                } else
                {
                    var parameter = new EquipmentParameter(item.Name, item.Unit, item.LowLimit, item.HighLimit, item.Scale, item.DataSource, item.Address);
                    equipment.AddEquipmentParameter(parameter);
                }
            }

            _dataCenterRepository.AddEquipmentParameter(equipment);
            _dataCenterRepository.Commit();

            return new CommandResult(true, "Parametros criados com sucesso", equipment);
        }

        public ICommandResult Handle(CreateEquipmentParameterGroupCommand command)
        {
            var equipmentParameterGroup = new EquipmentParameterGroup(command.Name);

            foreach (var item in equipmentParameterGroup.Parameters)
            {
                //var parameter = _dataCenterRepository.FindParametersByEquipmentId(item.Id);
                var parameter = _dataCenterRepository.FindEquipmentParameterById(item.Id);
                equipmentParameterGroup.AddParameter(parameter);
            }

            _dataCenterRepository.AddEquipmentParameterGroup(equipmentParameterGroup);
            _dataCenterRepository.Commit();

            return new CommandResult(true, "Grupo de parâmetros criado com sucesso", null);
        }
    }
}