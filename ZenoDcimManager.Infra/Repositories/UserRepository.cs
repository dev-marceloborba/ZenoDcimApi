using System;
using System.Collections.Generic;
using System.Linq;
using ZenoDcimManager.Domain.UserContext.Entities;
using ZenoDcimManager.Domain.UserContext.Repositories;
using ZenoDcimManager.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ZenoDcimManager.Infra.Repositories
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

        public void DeleteByEmail(string email)
        {
            var user = FindUserByEmail(email);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public User Find(Guid id)
        {
            return _context.Users.Find(id);
        }

        public User FindUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email);
        }

        public IEnumerable<User> List()
        {
            return _context.Users
                .AsNoTracking()
                .OrderBy(x => x.FirstName)
                .ToList();
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