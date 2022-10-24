using System;
using System.Threading.Tasks;
using ZenoDcimManager.Domain.UserContext.Entities;
using ZenoDcimManager.Shared.Helpers;
using ZenoDcimManager.Shared.Repositories;
using ZenoDcimManager.Shared.UnitOfWork;

namespace ZenoDcimManager.Domain.UserContext.Repositories
{
    public interface IUserRepository : CrudRepository<User>, IUnitOfWork, ICheckIfExists
    {
        Task<User> FindUserByEmail(string email);
        Task Login(string email, string password);
    }
}