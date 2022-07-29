using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZenoDcimManager.Domain.ActiveContext.Repositories;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Infra.Contexts;

namespace ZenoDcimManager.Infra.Repositories
{
	public class VirtualParameterRepository : IVirtualParameterRepository
	{
        private readonly ZenoContext _context;

        public VirtualParameterRepository(ZenoContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(VirtualParameter model)
        {
            await _context.Parameters.AddAsync(model);
        }

        public void Delete(VirtualParameter model)
        {
            _context.Entry(model).State = EntityState.Deleted;
        }

        public async Task<IEnumerable<VirtualParameter>> FindAllAsync()
        {
            return await _context.VirtualParameters
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<VirtualParameter> FindByIdAsync(Guid id)
        {
            return await _context.VirtualParameters
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public void Update(VirtualParameter model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }
    }
}

