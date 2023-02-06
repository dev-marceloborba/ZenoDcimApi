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
    public class SiteHandler : Notifiable,
        ICommandHandler<CreateSiteCommand>
    {
        private readonly ISiteRepository _siteRepository;
        private readonly ISiteCardSettingsRepository _cardRepository;

        public SiteHandler(ISiteRepository siteRepository, ISiteCardSettingsRepository cardRepository)
        {
            _siteRepository = siteRepository;
            _cardRepository = cardRepository;
        }

        public async Task<ICommandResult> Handle(CreateSiteCommand command)
        {
            var site = new Site
            {
                Name = command.Name
            };

            await _siteRepository.CreateAsync(site);

            var cardSettings = new SiteCardSettings
            {
                SiteId = site.Id,
                Parameter1 = null,
                Parameter2 = null,
                Parameter3 = null,
                Parameter4 = null,
                Parameter5 = null,
                Parameter6 = null,
            };

            await _cardRepository.CreateAsync(cardSettings);

            await _siteRepository.Commit();

            return new CommandResult(true, "Site criado com sucesso", site);
        }
    }
}