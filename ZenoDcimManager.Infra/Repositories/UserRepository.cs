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
        private readonly ZenoContext _context;

        public UserRepository(ZenoContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Delete(User model)
        {
            _context.Entry(model).State = EntityState.Deleted;
        }

        public async Task<User> FindByIdAsync(Guid id)
        {
            return await _context.Users
                .Where(x => x.Id == id)
                .Include(x => x.Group)
                .Include(x => x.UserPreferencies)
                .FirstOrDefaultAsync();
        }

        public async Task<User> FindUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<IEnumerable<User>> FindAllAsync()
        {
            return await _context.Users
                .AsNoTracking()
                .Include(x => x.UserPreferencies)
                .Include(x => x.Group)
                .Include(x => x.Company)
                .ThenInclude(x => x.Contracts)
                .OrderBy(x => x.FirstName)
                .ToListAsync();
        }

        public Task Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public void Update(User item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public async Task<bool> CheckIfExists(string parameter)
        {
            var result = await _context.Users
                .FirstOrDefaultAsync(x => x.Email == parameter);
            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}