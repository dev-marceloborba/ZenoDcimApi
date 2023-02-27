using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZenoDcimManager.Domain.ActiveContext.ValueObjects;
using ZenoDcimManager.Domain.AutomationContext.ViewModels;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Domain.ZenoContext.Repositories;
using ZenoDcimManager.Infra.Contexts;

namespace ZenoDcimManager.Infra.Repositories
{
    public class SiteRepository : ISiteRepository
    {
        private readonly ZenoContext _context;
        public SiteRepository(ZenoContext context)
        {
            _context = context;
        }
        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(Site model)
        {
            await _context.Sites.AddAsync(model);
        }

        public void Delete(Site model)
        {
            _context.Entry(model).State = EntityState.Deleted;
        }

        public async Task<IEnumerable<Site>> FindAllAsync()
        {
            return await _context.Sites
              .AsNoTracking()
              .Include(x => x.Buildings)
              .ThenInclude(x => x.Floors)
              .ThenInclude(x => x.Rooms)
              .ThenInclude(x => x.Equipments)
              .ThenInclude(x => x.EquipmentParameters)
              .OrderBy(x => x.Name)
              .ToListAsync();
        }

        public async Task<Site> FindByIdAsync(Guid id)
        {
            return await _context.Sites
                .Where(x => x.Id == id)
                .Include(x => x.CardSettings)
                .Include(x => x.Buildings)
                    .ThenInclude(x => x.Floors)
                    .ThenInclude(x => x.Rooms)
                    .ThenInclude(x => x.Equipments)
                    .ThenInclude(x => x.EquipmentParameters)
                    .ThenInclude(x => x.AlarmRules)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<SiteCardViewModel>> LoadSiteCards()
        {
            return await _context.Sites
                .AsNoTracking()
                .Include(x => x.CardSettings)
                    .ThenInclude(x => x.Parameter1)
                    .ThenInclude(x => x.EquipmentParameter)
                    .ThenInclude(x => x.Equipment)
                .Include(x => x.CardSettings)
                    .ThenInclude(x => x.Parameter2)
                    .ThenInclude(x => x.EquipmentParameter)
                    .ThenInclude(x => x.Equipment)
                .Include(x => x.CardSettings)
                    .ThenInclude(x => x.Parameter3)
                    .ThenInclude(x => x.EquipmentParameter)
                    .ThenInclude(x => x.Equipment)
                .Include(x => x.CardSettings)
                    .ThenInclude(x => x.Parameter4)
                    .ThenInclude(x => x.EquipmentParameter)
                    .ThenInclude(x => x.Equipment)
                .Include(x => x.CardSettings)
                    .ThenInclude(x => x.Parameter5)
                    .ThenInclude(x => x.EquipmentParameter)
                    .ThenInclude(x => x.Equipment)
                .Include(x => x.CardSettings)
                    .ThenInclude(x => x.Parameter6)
                    .ThenInclude(x => x.EquipmentParameter)
                    .ThenInclude(x => x.Equipment)
                .Select(x => new SiteCardViewModel
                {
                    Id = x.CardSettings.Id == null ? new Guid() : x.CardSettings.Id,
                    SiteId = x.Id,
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

        public void Update(Site model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }
    }
}