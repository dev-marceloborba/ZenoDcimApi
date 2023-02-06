using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZenoDcimManager.Domain.ActiveContext.Repositories;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Infra.Contexts;

namespace ZenoDcimManager.Infra.Repositories
{
    public class RoomCardSettingsRepository : IRoomCardSettingsRepository
    {
        private readonly ZenoContext _context;

        public RoomCardSettingsRepository(ZenoContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(RoomCardSettings model)
        {
            await _context.RoomCardSettings.AddAsync(model);
        }

        public void Delete(RoomCardSettings model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RoomCardSettings>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<RoomCardSettings> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(RoomCardSettings model)
        {
            throw new NotImplementedException();
        }
    }
}