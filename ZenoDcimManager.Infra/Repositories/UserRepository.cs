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

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Delete(User item)
        {
            _context.Users.Remove(item);
        }

        public void DeleteUser(User user)
        {
            _context.Remove(user);
        }

        public User Find(Guid id)
        {
            return _context.Users.Find(id);
        }

        public User FindUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email);
        }

        public User FindUserById(Guid id)
        {
            throw _context.Users.Find(id);
        }

        public IEnumerable<User> List()
        {
            return _context.Users
                .AsNoTracking()
                .Include(x => x.Company)
                .ThenInclude(x => x.Contracts)
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
        }

        public void Update(User item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}