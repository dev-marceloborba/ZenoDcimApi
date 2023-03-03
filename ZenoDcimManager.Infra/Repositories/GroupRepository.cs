using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZenoDcimManager.Domain.UserContext.Commands.Output;
using ZenoDcimManager.Domain.UserContext.Entities;
using ZenoDcimManager.Domain.UserContext.Repositories;
using ZenoDcimManager.Domain.UserContext.ValueObjects;
using ZenoDcimManager.Infra.Contexts;

namespace ZenoDcimManager.Infra.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ZenoContext _context;

        public GroupRepository(ZenoContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(Group model)
        {
            await _context.Groups.AddAsync(model);
        }

        public void Delete(Group model)
        {
            _context.Entry(model).State = EntityState.Deleted;
        }

        public async Task<IEnumerable<Group>> FindAllAsync()
        {
            return await _context.Groups
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Group> FindByIdAsync(Guid id)
        {
            return await _context.Groups
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public void Update(Group model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }

        async Task<IEnumerable<UserGroupOutputCommand>> IGroupRepository.FindAllAsync()
        {
            return await _context.Groups
                .AsNoTracking()
                .Select(x => new UserGroupOutputCommand
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Actions = new ActionPermissions
                    {
                        AckAlarms = x.ActionAckAlarms,
                        EditConnections = x.ActionEditConnections
                    },
                    Registers = new RegisterPermissions
                    {
                        Alarms = x.RegisterAlarms,
                        Datacenter = x.RegisterDatacenter,
                        Parameters = x.RegisterParameters,
                        Users = x.RegisterUsers,
                        Notifications = x.RegisterNotifications
                    },
                    Views = new ViewPermissions
                    {
                        Alarms = x.ViewAlarms,
                        Equipments = x.ViewEquipments,
                        Parameters = x.ViewParameters
                    },
                    General = new GeneralPermissions
                    {
                        ReceiveEmail = x.ReceiveEmail
                    }
                })
                .ToListAsync();
        }
    }
}