using System.Threading.Tasks;
using Flunt.Notifications;
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
        public async Task<ICommandResult> Handle(CreateSiteCommand command)
        {
            var site = new Site
            {
                Name = command.Name
            };

            await _siteRepository.CreateAsync(site);
            await _siteRepository.Commit();

            return new CommandResult(true, "Site criado com sucesso", site);
        }
    }
}