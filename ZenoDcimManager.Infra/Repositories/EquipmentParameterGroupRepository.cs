using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Domain.ZenoContext.Repositories;
using ZenoDcimManager.Infra.Contexts;

namespace ZenoDcimManager.Infra.Repositories
{
    public class EquipmentParameterGroupRepository : IEquipmentParameterGroupRepository
    {
        private readonly ZenoContext _context;

        public EquipmentParameterGroupRepository(ZenoContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(EquipmentParameterGroup model)
        {
            await _context.EquipmentParameterGroups.AddAsync(model);
        }

        public void Delete(EquipmentParameterGroup model)
        {
            _context.Entry(model).State = EntityState.Deleted;
        }

        public async Task<IEnumerable<EquipmentParameterGroup>> FindAllAsync()
        {
            return await _context.EquipmentParameterGroups
                .AsNoTracking()
                .Include(x => x.ParameterGroupAssignments)
                    .ThenInclude(x => x.Parameter)
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<EquipmentParameterGroup> FindByIdAsync(Guid id)
        {
            return await _context.EquipmentParameterGroups
                .Where(x => x.Id == id)
                .Include(x => x.ParameterGroupAssignments)
                .SingleAsync();
        }

        public void Update(EquipmentParameterGroup model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }
    }
}