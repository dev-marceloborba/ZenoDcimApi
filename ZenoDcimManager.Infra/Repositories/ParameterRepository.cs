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
    public class ParameterRepository : IParameterRepository
    {
        private readonly ZenoContext _context;

        public ParameterRepository(ZenoContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(Parameter model)
        {
            await _context.Parameters.AddAsync(model);
        }

        public void Delete(Parameter model)
        {
            _context.Entry(model).State = EntityState.Deleted;
        }

        public async Task<IEnumerable<Parameter>> FindAllAsync()
        {
            return await _context.Parameters
               .ToListAsync();
        }

        public async Task<Parameter> FindByIdAsync(Guid id)
        {
            return await _context.Parameters
                .FindAsync(id);
        }

        public async Task<IEnumerable<Parameter>> FindParametersByGroup(string groupName)
        {
            return await _context.ParameterGroupAssignments
                .AsNoTracking()
                .Include(x => x.EquipmentParameterGroup)
                .Include(x => x.Parameter)
                .Where(x => x.EquipmentParameterGroup.Name == groupName)
                .Select(x => x.Parameter)
                .ToListAsync();
        }

        public void Update(Parameter model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }
    }
}