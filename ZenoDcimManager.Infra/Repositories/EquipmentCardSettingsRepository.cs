using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZenoDcimManager.Domain.ActiveContext.Repositories;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Infra.Contexts;

namespace ZenoDcimManager.Infra.Repositories
{
    public class EquipmentCardSettingsRepository : IEquipmentCardSettingsRepository
    {

        private readonly ZenoContext _context;

        public EquipmentCardSettingsRepository(ZenoContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(EquipmentCardSettings model)
        {
            await _context.EquipmentCardSettings.AddAsync(model);
        }

        public void Delete(EquipmentCardSettings model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EquipmentCardSettings>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<EquipmentCardSettings> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(EquipmentCardSettings model)
        {
            throw new NotImplementedException();
        }
    }
}