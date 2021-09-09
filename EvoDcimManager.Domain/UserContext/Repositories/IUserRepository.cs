using EvoDcimManager.Domain.UserContext.Entities;
using EvoDcimManager.Shared.Repositories;

namespace EvoDcimManager.Domain.UserContext.Repositories
{
    public interface IUserRepository : CrudRepository<User>
    {
        void Login(string email, string password);
    }
}