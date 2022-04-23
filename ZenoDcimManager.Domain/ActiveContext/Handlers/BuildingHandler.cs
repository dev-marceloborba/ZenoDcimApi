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
        ICommandHandler<CreateEquipmentParameterGroupCommand>,
        ICommandHandler<CreateSiteCommand>
    {
        private readonly IDataCenterRepository _dataCenterRepository;

        public BuildingHandler(IDataCenterRepository dataCenterRepository)
        {
            _dataCenterRepository = dataCenterRepository;
        }

        public ICommandResult Handle(CreateBuildingCommand command)
        {
            var building = new Building(command.Campus, command.Name, command.SiteId);

            _dataCenterRepository.AddBuilding(building);
            _dataCenterRepository.Commit();

            return new CommandResult(true, "Prédio criado com sucesso", building);
        }

        public ICommandResult Handle(CreateFloorCommand command)
        {

            var floor = new Floor(command.Name, command.BuildingId);

            _dataCenterRepository.AddFloor(floor);
            _dataCenterRepository.Commit();

            return new CommandResult(true, "Andar criado com sucesso", floor);
        }

        public ICommandResult Handle(CreateRoomCommand command)
        {

            var room = new Room(command.Name, command.FloorId);

            _dataCenterRepository.AddRoom(room);
            _dataCenterRepository.Commit();

            return new CommandResult(true, "Sala criada com sucesso", room);
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
                command.Alarms,
                command.RoomId
                ); ;

            _dataCenterRepository.AddEquipment(equipment);
            _dataCenterRepository.Commit();

            return new CommandResult(true, "Equipamento criado com sucesso", equipment);
        }

        public ICommandResult Handle(CreateMultipleEquipmentsCommand command)
        {
            foreach (var item in command.Equipments)
            {
                var equipment = new Equipment(
                    item.Class,
                    item.Component,
                    item.ComponentCode,
                    item.Description,
                    null,
                    null,
                    item.Group,
                    item.Status,
                    item.Alarms,
                    item.RoomId
                    );

                _dataCenterRepository.AddEquipment(equipment);

            }

            _dataCenterRepository.Commit();

            return new CommandResult(true, "Equipamentos criados com sucesso", null);
        }

        public ICommandResult Handle(CreateEquipmentParameterCommand command)
        {

            var parameter = new EquipmentParameter(
                command.Name,
                command.Unit,
                command.LowLimit,
                command.HighLimit,
                command.Scale,
                command.DataSource,
                command.Address,
                command.EquipmentId
                );

            _dataCenterRepository.AddEquipmentParameter(parameter);
            _dataCenterRepository.Commit();

            return new CommandResult(true, "Parametro criado com sucesso", parameter);
        }

        public ICommandResult Handle(CreateMultipleParametersCommand command)
        {

            foreach (var item in command.Parameters)
            {
                var parameter = new EquipmentParameter(
                       item.Name,
                       item.Unit,
                       item.LowLimit,
                       item.HighLimit,
                       item.Scale,
                       item.DataSource,
                       item.Address,
                       item.EquipmentId
                       );

                _dataCenterRepository.AddEquipmentParameter(parameter);
            }

            _dataCenterRepository.Commit();

            return new CommandResult(true, "Parametros criados com sucesso", null);
        }

        public ICommandResult Handle(CreateEquipmentParameterGroupCommand command)
        {
            var equipmentParameterGroup = new EquipmentParameterGroup(command.Name);

            foreach (var item in command.ParametersId)
            {
                var parameter = _dataCenterRepository.FindEquipmentParameterById(item);
                equipmentParameterGroup.AddParameter(parameter);
            }

            _dataCenterRepository.AddEquipmentParameterGroup(equipmentParameterGroup);
            _dataCenterRepository.Commit();

            return new CommandResult(true, "Grupo de parâmetros criado com sucesso", null);
        }

        public ICommandResult Handle(CreateSiteCommand command)
        {
            var site = new Site(command.Name);

            _dataCenterRepository.AddSite(site);
            _dataCenterRepository.Commit();

            return new CommandResult(true, "Site criado com sucesso", null);
        }
    }
}