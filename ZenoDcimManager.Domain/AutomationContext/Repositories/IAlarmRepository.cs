using System.Collections.Generic;
using System.Threading.Tasks;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Domain.AutomationContext.ViewModels;
using ZenoDcimManager.Shared.Repositories;
using ZenoDcimManager.Shared.UnitOfWork;

namespace ZenoDcimManager.Domain.AutomationContext.Repositories
{
    public interface IAlarmRepository : CrudRepository<Alarm>, IUnitOfWork
    {
        Task<IList<Alarm>> GetFilteredAlarms(AlarmFiltersViewModel filters);
    }
}