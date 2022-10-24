using System;
using System.Collections.Generic;
using System.Linq;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Domain.ZenoContext.Repositories;
using ZenoDcimManager.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ZenoDcimManager.Infra.Repositories
{
    public class RackEquipmentRepository : IRackEquipmentRepository
    {
        private readonly ZenoContext _context;

        public RackEquipmentRepository(ZenoContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Create(RackEquipment rackEquipment)
        {
            await _context.RackEquipments.AddAsync(rackEquipment);
        }

        public void Delete(RackEquipment rackEquipment)
        {
            _context.Entry(rackEquipment).State = EntityState.Deleted;
        }

        public async Task<IEnumerable<RackEquipment>> FindAll()
        {
            return await _context.RackEquipments
                .AsNoTracking()
                .Include(x => x.BaseEquipment)
                .OrderBy(x => x.InitialPosition)
                .ToListAsync();
        }

        public async Task<RackEquipment> FindById(Guid id)
        {
            return await _context.RackEquipments
                .Include(x => x.BaseEquipment)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<RackEquipment> FindByName(string name)
        {
            return await _context.RackEquipments
                .Include(x => x.BaseEquipment)
                .FirstOrDefaultAsync(x => x.BaseEquipment.Name == name);
        }

        public async Task<IEnumerable<RackEquipment>> FindEquipmentsWithoutRack()
        {
            return await _context.RackEquipments
                .AsNoTracking()
                .Include(x => x.BaseEquipment)
                .Where(x => x.InitialPosition == 0 && x.FinalPosition == 0)
                .ToListAsync();
        }

        public async Task<IEnumerable<RackEquipment>> FindRackEquipmentsByRackId(Guid id)
        {
            return await _context.RackEquipments
                .AsNoTracking()
                .Where(x => x.RackId == id)
                .Include(x => x.BaseEquipment)
                .ToListAsync();
        }

        public void Update(RackEquipment rackEquipment)
        {
            _context.Entry(rackEquipment).State = EntityState.Modified;
        }
    }
}