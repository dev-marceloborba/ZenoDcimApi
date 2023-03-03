using System;
using System.Collections.Generic;
using System.Linq;
using ZenoDcimManager.Domain.UserContext.Entities;
using ZenoDcimManager.Domain.UserContext.Repositories;
using ZenoDcimManager.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ZenoDcimManager.Domain.UserContext.Commands.Output;
using ZenoDcimManager.Domain.UserContext.ValueObjects;

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
            return await _context.Users
                .Where(x => x.Email == email)
                .Include(x => x.Group)
                .Include(x => x.UserPreferencies)
                .FirstOrDefaultAsync();
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

        public async Task<UserOutputCommand> FindUser(Guid id)
        {
            return await _context.Users
                .Where(x => x.Id == id)
                .Include(x => x.Group)
                .Include(x => x.UserPreferencies)
                .Select(x => new UserOutputCommand(x.Id, x.FirstName, x.LastName, x.Email, x.Active, x.UserPreferencies, new UserGroupOutputCommand
                {
                    Id = x.Group.Id,
                    Name = x.Group.Name,
                    Description = x.Group.Description,
                    Actions = new ActionPermissions
                    {
                        AckAlarms = x.Group.ActionAckAlarms,
                        EditConnections = x.Group.ActionEditConnections
                    },
                    Registers = new RegisterPermissions
                    {
                        Alarms = x.Group.RegisterAlarms,
                        Datacenter = x.Group.RegisterDatacenter,
                        Parameters = x.Group.RegisterParameters,
                        Users = x.Group.RegisterUsers,
                        Notifications = x.Group.RegisterNotifications
                    },
                    Views = new ViewPermissions
                    {
                        Alarms = x.Group.ViewAlarms,
                        Equipments = x.Group.ViewEquipments,
                        Parameters = x.Group.ViewParameters
                    },
                    General = new GeneralPermissions
                    {
                        ReceiveEmail = x.Group.ReceiveEmail
                    }
                }))
                .FirstOrDefaultAsync();
        }
    }
}