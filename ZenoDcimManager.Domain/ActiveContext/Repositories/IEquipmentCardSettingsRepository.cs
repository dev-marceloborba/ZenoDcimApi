using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Shared.Repositories;
using ZenoDcimManager.Shared.UnitOfWork;

namespace ZenoDcimManager.Domain.ActiveContext.Repositories
{
    public interface IEquipmentCardSettingsRepository : CrudRepository<EquipmentCardSettings>, IUnitOfWork
    {

    }
}