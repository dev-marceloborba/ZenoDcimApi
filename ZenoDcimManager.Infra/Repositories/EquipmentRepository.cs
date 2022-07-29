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
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly ZenoContext _context;

        public EquipmentRepository(ZenoContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(Equipment model)
        {
            await _context.Equipments.AddAsync(model);
        }

        public void Delete(Equipment model)
        {
            _context.Entry(model).State = EntityState.Deleted;
        }

        public async Task<IEnumerable<Equipment>> FindAllAsync()
        {
            return await _context.Equipments
                .Include(x => x.EquipmentParameters)
                .Include(x => x.Building)
                .Include(x => x.Floor)
                .Include(x => x.Room)
                .ToListAsync();
        }

        public async Task<Equipment> FindByIdAsync(Guid id)
        {
            return await _context.Equipments
                .Where(x => x.Id == id)
                .Include(x => x.EquipmentParameters)
                .Include(x => x.Building)
                .Include(x => x.Floor)
                .Include(x => x.Room)
                .FirstOrDefaultAsync();
        }

        public IEnumerable<Equipment> FindEquipmentByRoom(Guid roomId)
        {
            return _context.Rooms
                .Where(x => x.Id == roomId)
                .Select(x => x.Equipments)
                .Single();
        }

        public void Update(Equipment model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }
    }
}