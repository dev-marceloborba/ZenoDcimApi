using System;
using System.Collections.Generic;
using System.Linq;
using ZenoDcimManager.Domain.ActiveContext.Entities;
using ZenoDcimManager.Domain.ActiveContext.Repositories;
using ZenoDcimManager.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ZenoDcimManager.Infra.Repositories
{
    public class RackRepository : IRackRepository
    {
        private readonly ActiveContext _context;

        public RackRepository(ActiveContext context)
        {
            _context = context;
        }

        public async Task AddRackEquipments(Rack rack)
        {
            foreach (var item in rack.RackEquipments)
            {
                await _context.RackEquipments.AddAsync(item);
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Delete(Rack item)
        {
            _context.Entry(item).State = EntityState.Deleted;
        }

        public async Task<Rack> Find(Guid id)
        {
            return await _context.Racks
                .AsNoTracking()
                .Include(x => x.RackEquipments)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Rack> FindById(Guid id)
        {
            return await _context.Racks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Rack> FindByLocalization(string localization)
        {
            return await _context.Racks
                .Include(x => x.RackEquipments)
                .FirstOrDefaultAsync(x => x.Localization == localization);
        }

        public async Task<IEnumerable<Rack>> List()
        {
            return await _context.Racks
                .AsNoTracking()
                .Include(x => x.RackEquipments)
                .ThenInclude(x => x.BaseEquipment)
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task Save(Rack item)
        {
            await _context.Racks.AddAsync(item);
        }

        public void Update(Rack item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}