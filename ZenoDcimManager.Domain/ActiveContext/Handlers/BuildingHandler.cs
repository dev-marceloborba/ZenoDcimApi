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
        ICommandHandler<CreateFloorCommand>
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
    }
}