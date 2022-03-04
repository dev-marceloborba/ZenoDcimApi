using ZenoDcimManager.Domain.UserContext.Entities;
using ZenoDcimManager.Shared.Repositories;
using ZenoDcimManager.Shared.UnitOfWork;

namespace ZenoDcimManager.Domain.UserContext.Repositories
{
    public interface IUserRepository : CrudRepository<User>, IUnitOfWork
    {
        void DeleteByEmail(string email);
        User FindUserByEmail(string email);
        void Login(string email, string password);
    }
}