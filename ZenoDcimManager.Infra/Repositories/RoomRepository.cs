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
    public class RoomRepository : IRoomRepository
    {
        private readonly ZenoContext _context;

        public RoomRepository(ZenoContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(Room model)
        {
            await _context.Rooms.AddAsync(model);
        }

        public void Delete(Room model)
        {
            _context.Entry(model).State = EntityState.Deleted;
        }

        public async Task<IEnumerable<Room>> FindAllAsync()
        {
            return await _context.Rooms
                .Include(x => x.Equipments.OrderBy(y => y.Description))
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<Room> FindByIdAsync(Guid id)
        {
            return await _context.Rooms
                .Where(x => x.Id == id)
                .Include(x => x.Equipments)
                .ThenInclude(x => x.EquipmentParameters)
                .FirstOrDefaultAsync();
        }

        public IEnumerable<Room> FindRoomByFloor(Guid floorId)
        {
            return _context.Floors
                .Where(x => x.Id == floorId)
                .Select(x => x.Rooms)
                .Single();
        }

        public void Update(Room model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }
    }
}