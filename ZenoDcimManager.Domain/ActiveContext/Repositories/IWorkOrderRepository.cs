using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZenoDcimManager.Domain.ServiceOrderContext.DTOs;
using ZenoDcimManager.Domain.ServiceOrderContext.Entities;
using ZenoDcimManager.Shared.Repositories;
using ZenoDcimManager.Shared.UnitOfWork;

namespace ZenoDcimManager.Domain.ActiveContext.Repositories
{
    public interface IWorkOrderRepository : CrudRepository<WorkOrder>, IUnitOfWork
    {
        Task<IEnumerable<WorkOrder>> FindFilteredWorkOrders(WorkOrderFilterDto filterDto);
    }
}

