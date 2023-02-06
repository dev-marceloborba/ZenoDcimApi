using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZenoDcimManager.Domain.AutomationContext.ViewModels;
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
                .AsNoTracking()
                .Include(x => x.Site)
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
               .Include(x => x.CardSettings)
               .Include(x => x.Site)
               .Include(x => x.Floors)
                .ThenInclude(x => x.Rooms)
                .ThenInclude(x => x.Equipments)
                .ThenInclude(x => x.EquipmentParameters)
                .ThenInclude(x => x.AlarmRules)
               .FirstAsync();
        }

        public async Task<IEnumerable<BuildingCardViewModel>> LoadBuildingCards(Guid id)
        {
            return await _context.Buildings
                .AsNoTracking()
                .Where(x => x.SiteId == id)
                .Include(x => x.CardSettings)
                    .ThenInclude(x => x.Parameter1)
                    .ThenInclude(x => x.EquipmentParameter)
                .Include(x => x.CardSettings)
                    .ThenInclude(x => x.Parameter2)
                    .ThenInclude(x => x.EquipmentParameter)
                .Include(x => x.CardSettings)
                    .ThenInclude(x => x.Parameter3)
                    .ThenInclude(x => x.EquipmentParameter)
                .Include(x => x.CardSettings)
                    .ThenInclude(x => x.Parameter4)
                    .ThenInclude(x => x.EquipmentParameter)
                .Include(x => x.CardSettings)
                    .ThenInclude(x => x.Parameter5)
                    .ThenInclude(x => x.EquipmentParameter)
                .Include(x => x.CardSettings)
                    .ThenInclude(x => x.Parameter6)
                    .ThenInclude(x => x.EquipmentParameter)
                .Select(x => new BuildingCardViewModel
                {
                    Id = x.CardSettings.Id == null ? new Guid() : x.CardSettings.Id,
                    BuildingId = x.Id,
                    Name = x.Name,
                    Parameter1 = x.CardSettings.Parameter1,
                    Parameter2 = x.CardSettings.Parameter2,
                    Parameter3 = x.CardSettings.Parameter3,
                    Parameter4 = x.CardSettings.Parameter4,
                    Parameter5 = x.CardSettings.Parameter5,
                    Parameter6 = x.CardSettings.Parameter6,
                })
                .ToListAsync();
        }

        public void Update(Building model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }
    }
}