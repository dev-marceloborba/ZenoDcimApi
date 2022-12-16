using System.Collections.Generic;
using System.Threading.Tasks;
using ZenoDcimManager.Domain.AutomationContext.ViewModels;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Shared.Repositories;
using ZenoDcimManager.Shared.UnitOfWork;

namespace ZenoDcimManager.Domain.ZenoContext.Repositories
{
    public interface ISiteRepository : CrudRepository<Site>, IUnitOfWork
    {
        Task<IEnumerable<SiteCardViewModel>> LoadSiteCards();
    }
}