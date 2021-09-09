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
                new User(new Name("Marcelo", "Borba"), new Email("marcelo@marcelo.com"), new Password("123456", "123465"), EUserRole.ADMIN)
            );
            _users.Add(
                new User(new Name("Gustavo", "Dalmolin"), new Email("gustavo@gustavo.com"), new Password("123456", "123465"), EUserRole.EXTERNAL_CLIENT)
            );
        }


        public User Delete(User item)
        {
            _users.Remove(item);
            return item;
        }

        public User Find(Guid id)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<User> List()
        {
            return _users.ToList();
        }

        public void Login(string email, string password)
        {
            throw new System.NotImplementedException();
        }

        public User Save(User item)
        {
            _users.Add(item);
            return item;
        }

        public User Update(User item)
        {
            _users.ForEach(x =>
            {
                if (x.Id == item.Id)
                    x = item;
            });
            return item;
        }
    }
}