using System;
using ZenoDcimManager.Domain.UserContext.Entities;
using ZenoDcimManager.Shared.Repositories;
using ZenoDcimManager.Shared.UnitOfWork;

namespace ZenoDcimManager.Domain.UserContext.Repositories
{
    public interface IUserRepository : CrudRepository<User>, IUnitOfWork
    {
        void DeleteUser(User user);
        User FindUserByEmail(string email);
        User FindUserById(Guid id);
        void Login(string email, string password);
    }
}