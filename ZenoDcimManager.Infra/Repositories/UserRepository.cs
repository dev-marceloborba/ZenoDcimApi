using System;
using System.Collections.Generic;
using System.Linq;
using ZenoDcimManager.Domain.UserContext.Entities;
using ZenoDcimManager.Domain.UserContext.Repositories;
using ZenoDcimManager.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ZenoDcimManager.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Delete(User item)
        {
            _context.Entry(item).State = EntityState.Deleted;
        }

        public async Task<User> Find(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> FindUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> FindUserById(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> List()
        {
            return await _context.Users
                .AsNoTracking()
                .Include(x => x.Company)
                .ThenInclude(x => x.Contracts)
                .OrderBy(x => x.FirstName)
                .ToListAsync();
        }

        public Task Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public async Task Save(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public void Update(User item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}