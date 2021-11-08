using ZenoDcimManager.Domain.UserContext.Entities;
using ZenoDcimManager.Shared.Repositories;

namespace ZenoDcimManager.Domain.UserContext.Repositories
{
    public interface IUserRepository : CrudRepository<User>
    {
        void DeleteByEmail(string email);
        User FindUserByEmail(string email);
        void Login(string email, string password);
    }
}