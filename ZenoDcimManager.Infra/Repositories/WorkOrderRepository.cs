using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZenoDcimManager.Domain.ActiveContext.Repositories;
using ZenoDcimManager.Domain.ServiceOrderContext.DTOs;
using ZenoDcimManager.Domain.ServiceOrderContext.Entities;
using ZenoDcimManager.Domain.ServiceOrderContext.Enums;
using ZenoDcimManager.Infra.Contexts;

namespace ZenoDcimManager.Infra.Repositories
{
    public class WorkOrderRepository : IWorkOrderRepository
    {
        private readonly ZenoContext _context;

        public WorkOrderRepository(ZenoContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(WorkOrder model)
        {
            await _context.WorkOrders.AddAsync(model);
        }

        public void Delete(WorkOrder model)
        {
            _context.Entry(model).State = EntityState.Deleted;
        }

        public async Task<IEnumerable<WorkOrder>> FindAllAsync()
        {
            return await _context.WorkOrders
                .AsNoTracking()
                .Include(x => x.Site)
                .Include(x => x.Building)
                .Include(x => x.Floor)
                .Include(x => x.Room)
                .Include(x => x.Equipment)
                .ToListAsync();
        }

        public async Task<WorkOrder> FindByIdAsync(Guid id)
        {
            return await _context.WorkOrders
                .Where(x => x.Id == id)
                .Include(x => x.Site)
                .Include(x => x.Building)
                .Include(x => x.Floor)
                .Include(x => x.Room)
                .Include(x => x.Equipment)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<WorkOrder>> FindFilteredWorkOrders(WorkOrderFilterDto filterDto)
        {
            var query = _context.WorkOrders
                .AsNoTracking()
                .Include(x => x.Site)
                .Include(x => x.Building)
                .Include(x => x.Floor)
                .Include(x => x.Room)
                .Include(x => x.Equipment)
                .AsQueryable();

            if (filterDto.Status != 8)
                query = query.Where(x => x.Status == (EWorkOrderStatus)filterDto.Status);

            return await query.ToListAsync();
        }

        public void Update(WorkOrder model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }
    }
}

