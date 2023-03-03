using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenoDcimManager.Domain.UserContext.Commands.Output;
using ZenoDcimManager.Domain.UserContext.Entities;
using ZenoDcimManager.Domain.UserContext.Enums;
using ZenoDcimManager.Domain.UserContext.Repositories;

namespace ZenoDcimManager.Tests.UserContext.Repositories
{
    public class FakeUserRepository : IUserRepository
    {
        private readonly List<User> _users;
        private readonly Company _company = new Company("Mindcloud", "Mindcloud", "12456789123");

        public FakeUserRepository()
        {
            _users = new List<User>();

        }

        public async Task Commit()
        {
        }

        public void Delete(User model)
        {
            _users.Remove(model);
        }


        public async Task<User> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> FindAllAsync()
        {
            return _users.ToList();
        }

        public Task Login(string email, string password)
        {
            throw new System.NotImplementedException();
        }

        public async Task CreateAsync(User item)
        {
            _users.Add(item);
        }

        public void Update(User model)
        {
            _users.ForEach(x =>
            {
                if (x.Id == model.Id)
                    x = model;
            });
        }

        public Task<bool> CheckIfExists(string parameter)
        {
            throw new NotImplementedException();
        }

        public Task<UserOutputCommand> FindUser(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}