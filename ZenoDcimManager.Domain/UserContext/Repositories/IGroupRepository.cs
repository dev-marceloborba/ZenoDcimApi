using System.Collections.Generic;
using System.Threading.Tasks;
using ZenoDcimManager.Domain.UserContext.Entities;
using ZenoDcimManager.Domain.UserContext.ViewModels;
using ZenoDcimManager.Shared.Repositories;
using ZenoDcimManager.Shared.UnitOfWork;

namespace ZenoDcimManager.Domain.UserContext.Repositories
{
    public interface IGroupRepository : CrudRepository<Group>, IUnitOfWork
    {
        new Task<IEnumerable<UserGroupResponseViewModel>> FindAllAsync();
    }
}