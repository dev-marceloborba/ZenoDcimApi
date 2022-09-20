using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZenoDcimManager.Domain.ServiceOrderContext.Entities;
using ZenoDcimManager.Domain.ServiceOrderContext.Repositories;
using ZenoDcimManager.Infra.Contexts;

namespace ZenoDcimManager.Infra.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ZenoContext _context;

        public SupplierRepository(ZenoContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(Supplier model)
        {
            await _context.Suppliers.AddAsync(model);
        }

        public void Delete(Supplier model)
        {
            _context.Entry(model).State = EntityState.Deleted;
        }

        public async Task<IEnumerable<Supplier>> FindAllAsync()
        {
            return await _context.Suppliers
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Supplier> FindByIdAsync(Guid id)
        {
            return await _context.Suppliers
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public void Update(Supplier model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }
    }
}