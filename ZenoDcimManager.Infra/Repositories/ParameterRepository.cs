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
            var parametersByGroup =
               from pga in _context.ParameterGroupAssignments
               join p in _context.Parameters on pga.ParameterId equals p.Id
               join epg in _context.EquipmentParameterGroups on pga.EquipmentParameterGroupId equals epg.Id
               where epg.Name == groupName
               select p;

            return await parametersByGroup.ToListAsync();
        }

        public void Update(Parameter model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }
    }
}