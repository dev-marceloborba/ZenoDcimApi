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
              .Include(x => x.Buildings)
              .OrderBy(x => x.Name)
              .ToListAsync();
        }

        public async Task<Site> FindByIdAsync(Guid id)
        {
            return await _context.Sites.FindAsync(id);
        }

        public void Update(Site model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }
    }
}