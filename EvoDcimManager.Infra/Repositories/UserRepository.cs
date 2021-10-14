using System;
using System.Collections.Generic;
using EvoDcimManager.Domain.UserContext.Entities;
using EvoDcimManager.Domain.UserContext.Repositories;
using EvoDcimManager.Infra.Contexts;

namespace EvoDcimManager.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public void Delete(User item)
        {
            throw new NotImplementedException();
        }

        public User Find(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> List()
        {
            throw new NotImplementedException();
        }

        public void Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public void Save(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}