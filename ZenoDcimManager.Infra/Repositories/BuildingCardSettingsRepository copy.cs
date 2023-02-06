using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZenoDcimManager.Domain.ActiveContext.Repositories;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Infra.Contexts;

namespace ZenoDcimManager.Infra.Repositories
{
    public class BuildingCardSettingsRepository : IBuildingCardSettingsRepository
    {

        private readonly ZenoContext _context;

        public BuildingCardSettingsRepository(ZenoContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(BuildingCardSettings model)
        {
            await _context.BuildingCardSettings.AddAsync(model);
        }

        public void Delete(BuildingCardSettings model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BuildingCardSettings>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<BuildingCardSettings> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(BuildingCardSettings model)
        {
            throw new NotImplementedException();
        }
    }
}