using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZenoDcimManager.Domain.ServiceOrderContext.Entities;
using ZenoDcimManager.Domain.ServiceOrderContext.Repositories;
using ZenoDcimManager.Infra.Contexts;

namespace ZenoDcimManager.Infra.Repositories
{
    public class WorkOrderEventRepository : IWorkOrderEventRepository
    {
        private readonly ZenoContext _context;

        public WorkOrderEventRepository(ZenoContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(WorkOrderEvent model)
        {
            await _context.WorkOrderEvents.AddAsync(model);
        }

        public void Delete(WorkOrderEvent model)
        {
            _context.Entry(model).State = EntityState.Deleted;
        }

        public async Task<IEnumerable<WorkOrderEvent>> FindAllAsync()
        {
            return await _context.WorkOrderEvents
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<WorkOrderEvent> FindByIdAsync(Guid id)
        {
            return await _context.WorkOrderEvents
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public void Update(WorkOrderEvent model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }
    }
}