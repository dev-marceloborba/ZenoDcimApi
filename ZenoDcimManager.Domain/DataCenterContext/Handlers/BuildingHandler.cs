using ZenoDcimManager.Domain.DataCenterContext.Commands.Inputs;
using ZenoDcimManager.Domain.DataCenterContext.Entities;
using ZenoDcimManager.Domain.DataCenterContext.Repositories;
using ZenoDcimManager.Shared.Commands;
using ZenoDcimManager.Shared.Handlers;

namespace ZenoDcimManager.Domain.DataCenterContext.Handlers
{
    public class BuildingHandler : ICommandHandler<CreateBuildingCommand>
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
    }
}