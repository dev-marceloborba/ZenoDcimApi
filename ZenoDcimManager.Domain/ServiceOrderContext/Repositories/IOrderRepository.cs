using ZenoDcimManager.Domain.ServiceOrderContext.Entities;
using ZenoDcimManager.Shared.Repositories;
using ZenoDcimManager.Shared.UnitOfWork;

namespace ZenoDcimManager.Domain.ServiceOrderContext.Repositories
{
    public interface IOrderRepository : CrudRepository<Order>, IUnitOfWork
    {

    }
}