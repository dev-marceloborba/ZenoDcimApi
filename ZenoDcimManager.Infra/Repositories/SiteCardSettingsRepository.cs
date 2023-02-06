using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZenoDcimManager.Domain.ActiveContext.Repositories;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Infra.Contexts;

namespace ZenoDcimManager.Infra.Repositories
{
    public class SiteCardSettingsRepository : ISiteCardSettingsRepository
    {

        private readonly ZenoContext _context;

        public SiteCardSettingsRepository(ZenoContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(SiteCardSettings model)
        {
            await _context.SiteCardSettings.AddAsync(model);
        }

        public void Delete(SiteCardSettings model)
        {
            _context.Entry(model).State = EntityState.Deleted;
        }

        public async Task<IEnumerable<SiteCardSettings>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<SiteCardSettings> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(SiteCardSettings model)
        {
            throw new NotImplementedException();
        }
    }
}