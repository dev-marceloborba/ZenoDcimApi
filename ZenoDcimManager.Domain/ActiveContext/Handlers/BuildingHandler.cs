using System.Threading.Tasks;
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
        ICommandHandler<CreateSiteCommand>,
        ICommandHandler<CreateParameterCommand>
    {
        private readonly IDataCenterRepository _dataCenterRepository;

        public BuildingHandler(IDataCenterRepository dataCenterRepository)
        {
            _dataCenterRepository = dataCenterRepository;
        }

        public async Task<ICommandResult> Handle(CreateBuildingCommand command)
        {
            var building = new Building
            {
                Name = command.Name,
                SiteId = command.SiteId,
            };

            await _dataCenterRepository.AddBuilding(building);
            await _dataCenterRepository.Commit();

            return new CommandResult(true, "Prédio criado com sucesso", building);
        }

        public async Task<ICommandResult> Handle(CreateFloorCommand command)
        {

            var floor = new Floor
            {
                Name = command.Name,
                BuildingId = command.BuildingId,
            };

            await _dataCenterRepository.AddFloor(floor);
            await _dataCenterRepository.Commit();

            return new CommandResult(true, "Andar criado com sucesso", floor);
        }

        public async Task<ICommandResult> Handle(CreateRoomCommand command)
        {

            var room = new Room
            {
                Name = command.Name,
                FloorId = command.FloorId
            };    

            await _dataCenterRepository.AddRoom(room);
            await _dataCenterRepository.Commit();

            return new CommandResult(true, "Sala criada com sucesso", room);
        }

        public async Task<ICommandResult> Handle(CreateEquipmentCommand command)
        {
            var equipment = new Equipment
            {
                Component = command.Component,
                ComponentCode = command.ComponentCode,
                Class = command.Class,
                Group = command.Group,
                Description = command.Description,
                Alarms = command.Alarms,
                Status = command.Status,
                RoomId = command.RoomId,
            };

            await _dataCenterRepository.AddEquipment(equipment);
            await _dataCenterRepository.Commit();

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
                    Class = item.Class,
                    Group = item.Group,
                    Description = item.Description,
                    Alarms = item.Alarms,
                    Status = item.Status,
                    RoomId = item.RoomId,
                };

               await _dataCenterRepository.AddEquipment(equipment);
            }

            await _dataCenterRepository.Commit();

            return new CommandResult(true, "Equipamentos criados com sucesso", null);
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
    
            await _dataCenterRepository.AddEquipmentParameter(parameter);
            await _dataCenterRepository.Commit();

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

                await _dataCenterRepository.AddEquipmentParameter(parameter);
            }

            await _dataCenterRepository.Commit();

            return new CommandResult(true, "Parametros criados com sucesso", null);
        }

        public async Task<ICommandResult> Handle(CreateEquipmentParameterGroupCommand command)
        {
            var equipmentParameterGroup = new EquipmentParameterGroup()
            {
                Name = command.Name,
                Group = command.Group,
            };

            foreach (var item in command.ParametersId)
            {
                var parameter = _dataCenterRepository.FindEquipmentParameterById(item);
                //equipmentParameterGroup.AddParameter(parameter);
            }

            await _dataCenterRepository.AddEquipmentParameterGroup(equipmentParameterGroup);
            await _dataCenterRepository.Commit();

            return new CommandResult(true, "Grupo de parâmetros criado com sucesso", null);
        }

        public async Task<ICommandResult> Handle(CreateSiteCommand command)
        {
            var site = new Site
            {
                Name = command.Name
            };

            await _dataCenterRepository.AddSite(site);
            await _dataCenterRepository.Commit();

            return new CommandResult(true, "Site criado com sucesso", site);
        }

        public async Task<ICommandResult> Handle(CreateParameterCommand command)
        {
            var parameter = new Parameter
            {
                Name = command.Name,
                Unit = command.Unit,
                LowLimit = command.LowLimit,
                HighLimit = command.HighLimit,
                Scale = command.Scale
            };

            parameter.ParameterGroupAssignments.Add(
                new ParameterGroupAssignment
                {
                    ParameterId = parameter.Id,
                    EquipmentParameterGroupId = command.GroupId
                });

            await _dataCenterRepository.AddParameter(parameter);
            await _dataCenterRepository.Commit();

            return new CommandResult(true, "Parâmetro criado com sucesso", parameter);
        }
    }
}