using System;
using System.Collections.Generic;
using System.Linq;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Domain.ZenoContext.Repositories;
using ZenoDcimManager.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ZenoDcimManager.Infra.Repositories
{
    public class RackRepository : IRackRepository
    {
        private readonly ZenoContext _context;

        public RackRepository(ZenoContext context)
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

        public void Delete(Rack model)
        {
            _context.Entry(model).State = EntityState.Deleted;
        }

        public async Task<Rack> FindByIdAsync(Guid id)
        {
            return await _context.Racks
                .Include(x => x.RackEquipments)
                .ThenInclude(x => x.BaseEquipment)
                .Include(x => x.Site)
                .ThenInclude(x => x.Buildings)
                .ThenInclude(x => x.Floors)
                .ThenInclude(x => x.Rooms)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Rack> FindByLocalization(string localization)
        {
            return await _context.Racks
                .Include(x => x.RackEquipments)
                .ThenInclude(x => x.BaseEquipment)
                .FirstOrDefaultAsync(x => x.Localization == localization);
        }

        public async Task<IEnumerable<Rack>> FindAllAsync()
        {
            return await _context.Racks
                .AsNoTracking()
                .Include(x => x.RackEquipments)
                .ThenInclude(x => x.BaseEquipment)
                .Include(x => x.Site)
                .Include(x => x.Building)
                .Include(x => x.Floor)
                .Include(x => x.Room)
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task CreateAsync(Rack item)
        {
            await _context.Racks.AddAsync(item);
        }

        public void Update(Rack model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }
    }
}