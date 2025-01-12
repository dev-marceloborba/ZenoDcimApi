using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Shared.Repositories;
using ZenoDcimManager.Shared.UnitOfWork;

namespace ZenoDcimManager.Domain.ZenoContext.Repositories
{
    public interface IEquipmentParameterGroupRepository : CrudRepository<EquipmentParameterGroup>, IUnitOfWork
    {
    }
}