using System;
using System.Collections.Generic;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Shared.Repositories;
using ZenoDcimManager.Shared.UnitOfWork;

namespace ZenoDcimManager.Domain.ZenoContext.Repositories
{
    public interface IEquipmentParameterRepository : CrudRepository<EquipmentParameter>, IUnitOfWork
    {
        IList<EquipmentParameter> FindParametersByEquipmentId(Guid id);
    }
}