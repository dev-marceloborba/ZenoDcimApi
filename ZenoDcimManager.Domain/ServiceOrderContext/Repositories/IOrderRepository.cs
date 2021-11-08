using ZenoDcimManager.Domain.ServiceOrderContext.Entities;
using ZenoDcimManager.Shared.Repositories;

namespace ZenoDcimManager.Domain.ServiceOrderContext.Repositories
{
    public interface IOrderRepository : CrudRepository<Order>
    {

    }
}