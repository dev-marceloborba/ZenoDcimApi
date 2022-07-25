using System.Threading.Tasks;
using Flunt.Notifications;
using ZenoDcimManager.Domain.ZenoContext.Commands.Inputs;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Domain.ZenoContext.Repositories;
using ZenoDcimManager.Shared.Commands;
using ZenoDcimManager.Shared.Handlers;

namespace ZenoDcimManager.Domain.ZenoContext.Handlers
{
    public class BuildingHandler : Notifiable,
        ICommandHandler<CreateBuildingCommand>
    {
        private readonly IBuildingRepository _buildingRepository;

        public BuildingHandler(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        public async Task<ICommandResult> Handle(CreateBuildingCommand command)
        {
            var building = new Building
            {
                Name = command.Name,
                SiteId = command.SiteId,
            };

            await _buildingRepository.CreateAsync(building);
            await _buildingRepository.Commit();

            return new CommandResult(true, "Prédio criado com sucesso", building);
        }
    }
}