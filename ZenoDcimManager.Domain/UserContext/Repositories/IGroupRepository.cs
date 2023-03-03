using System.Collections.Generic;
using System.Threading.Tasks;
using ZenoDcimManager.Domain.UserContext.Commands.Output;
using ZenoDcimManager.Domain.UserContext.Entities;
using ZenoDcimManager.Shared.Repositories;
using ZenoDcimManager.Shared.UnitOfWork;

namespace ZenoDcimManager.Domain.UserContext.Repositories
{
    public interface IGroupRepository : CrudRepository<Group>, IUnitOfWork
    {
        new Task<IEnumerable<UserGroupOutputCommand>> FindAllAsync();
    }
}