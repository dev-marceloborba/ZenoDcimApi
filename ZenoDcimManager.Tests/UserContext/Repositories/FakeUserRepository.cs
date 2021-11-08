using System;
using System.Collections.Generic;
using System.Linq;
using ZenoDcimManager.Domain.UserContext.Entities;
using ZenoDcimManager.Domain.UserContext.Enums;
using ZenoDcimManager.Domain.UserContext.Repositories;
using ZenoDcimManager.Domain.UserContext.ValueObjects;

namespace ZenoDcimManager.Tests.UserContext.Repositories
{
    public class FakeUserRepository : IUserRepository
    {
        private readonly List<User> _users;

        public FakeUserRepository()
        {
            _users = new List<User>();
            _users.Add(
                new User("Marcelo", "Borba", "marcelo@marcelo.com", "123456798", EUserRole.ADMIN)
            );
            _users.Add(
                new User("Juliane", "Mattei", "juliane@marcelo.com", "123456798", EUserRole.ADMIN)
            );
        }


        public void Delete(User item)
        {
            _users.Remove(item);
        }

        public void DeleteByEmail(string email)
        {

        }

        public User Find(Guid id)
        {
            throw new NotImplementedException();
        }

        public User FindUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> List()
        {
            return _users.ToList();
        }

        public void Login(string email, string password)
        {
            throw new System.NotImplementedException();
        }

        public void Save(User item)
        {
            _users.Add(item);
        }

        public void Update(User item)
        {
            _users.ForEach(x =>
            {
                if (x.Id == item.Id)
                    x = item;
            });
        }
    }
}