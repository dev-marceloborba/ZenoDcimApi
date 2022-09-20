using System;
using ZenoDcimManager.Domain.ServiceOrderContext.Entities;
using ZenoDcimManager.Shared.Repositories;
using ZenoDcimManager.Shared.UnitOfWork;

namespace ZenoDcimManager.Domain.ActiveContext.Repositories
{
	public interface IWorkOrderRepository : CrudRepository<WorkOrder>, IUnitOfWork
	{
	}
}

