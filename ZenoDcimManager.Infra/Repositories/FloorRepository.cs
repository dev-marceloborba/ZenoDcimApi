using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Domain.ZenoContext.Repositories;
using ZenoDcimManager.Infra.Contexts;

namespace ZenoDcimManager.Infra.Repositories
{
    public class FloorRepository : IFloorRepository
    {
        private readonly ZenoContext _context;

        public FloorRepository(ZenoContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(Floor model)
        {
            await _context.Floors.AddAsync(model);
        }

        public void Delete(Floor model)
        {
            _context.Entry(model).State = EntityState.Deleted;
        }

        public async Task<IEnumerable<Floor>> FindAllAsync()
        {
            return await _context.Floors
                .AsNoTracking()
                .Include(x => x.Building)
                    .ThenInclude(x => x.Site)
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<Floor> FindByIdAsync(Guid id)
        {
            return await _context.Floors
                .Where(x => x.Id == id)
                .Include(x => x.Building)
                .FirstOrDefaultAsync();
        }

        public IEnumerable<Floor> FindFloorByBuilding(Guid buildingId)
        {
            return _context.Buildings
                .Where(x => x.Id == buildingId)
                .Select(x => x.Floors)
                .Single();
        }

        public void Update(Floor model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }
    }
}