using System.Collections.Generic;
using System.Threading.Tasks;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Shared.Repositories;
using ZenoDcimManager.Shared.UnitOfWork;

namespace ZenoDcimManager.Domain.ZenoContext.Repositories
{
    public interface IParameterRepository : CrudRepository<Parameter>, IUnitOfWork
    {
        Task<IEnumerable<Parameter>> FindParametersByGroup(string group);
    }
}