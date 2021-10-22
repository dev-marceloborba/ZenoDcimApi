using System;
using System.Collections.Generic;
using System.Linq;
using EvoDcimManager.Domain.UserContext.Entities;
using EvoDcimManager.Domain.UserContext.Enums;
using EvoDcimManager.Domain.UserContext.Repositories;
using EvoDcimManager.Domain.UserContext.ValueObjects;

namespace EvoDcimManager.Tests.UserContext.Repositories
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