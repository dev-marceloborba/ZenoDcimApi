using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Shared.Repositories;
using ZenoDcimManager.Shared.UnitOfWork;

namespace ZenoDcimManager.Domain.ZenoContext.Repositories
{
    public interface IEquipmentParameterRepository : CrudRepository<EquipmentParameter>, IUnitOfWork
    {
        Task<IEnumerable<EquipmentParameter>> FindParametersContainingName(string name);
        IList<EquipmentParameter> FindParametersByEquipmentId(Guid id);
        Task<EquipmentParameter> FindByIdWithoutTracking(Guid id);
    }
}