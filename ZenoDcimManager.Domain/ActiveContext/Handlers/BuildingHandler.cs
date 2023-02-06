using System.Threading.Tasks;
using Flunt.Notifications;
using ZenoDcimManager.Domain.ActiveContext.Repositories;
using ZenoDcimManager.Domain.AutomationContext.Entities;
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
        private readonly IBuildingCardSettingsRepository _cardRepository;

        public BuildingHandler(IBuildingRepository buildingRepository, IBuildingCardSettingsRepository cardRepository)
        {
            _buildingRepository = buildingRepository;
            _cardRepository = cardRepository;
        }

        public async Task<ICommandResult> Handle(CreateBuildingCommand command)
        {
            var building = new Building
            {
                Name = command.Name,
                SiteId = command.SiteId,
            };

            await _buildingRepository.CreateAsync(building);

            var cardSettings = new BuildingCardSettings
            {
                BuildingId = building.Id,
                Parameter1 = null,
                Parameter2 = null,
                Parameter3 = null,
                Parameter4 = null,
                Parameter5 = null,
                Parameter6 = null,
            };

            await _cardRepository.CreateAsync(cardSettings);

            await _buildingRepository.Commit();

            return new CommandResult(true, "Prédio criado com sucesso", building);
        }
    }
}