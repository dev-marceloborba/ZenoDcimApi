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
    public class BuildingRepository : IBuildingRepository
    {
        private readonly ZenoContext _context;

        public BuildingRepository(ZenoContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(Building model)
        {
            await _context.Buildings.AddAsync(model);
        }

        public void Delete(Building model)
        {
            _context.Entry(model).State = EntityState.Deleted;
        }

        public async Task<IEnumerable<Building>> FindAllAsync()
        {
            return await _context.Buildings
                .Include(x => x.Floors.OrderBy(y => y.Name))
                .ThenInclude(x => x.Rooms.OrderBy(y => y.Name))
                .ThenInclude(x => x.Equipments.OrderBy(y => y.Description))
                .ThenInclude(x => x.EquipmentParameters.OrderBy(y => y.Name))
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<Building> FindByIdAsync(Guid id)
        {
            return await _context.Buildings
               .Where(x => x.Id == id)
               .Include(x => x.Floors)
               .ThenInclude(x => x.Rooms)
               .FirstAsync();
        }

        public void Update(Building model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }
    }
}