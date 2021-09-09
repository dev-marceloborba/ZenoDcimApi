using EvoDcimManager.Domain.ServiceOrderContext.Entities;
using EvoDcimManager.Shared.Repositories;

namespace EvoDcimManager.Domain.ServiceOrderContext.Repositories
{
    public interface IOrderRepository : CrudRepository<Order>
    {

    }
}