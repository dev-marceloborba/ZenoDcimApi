using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Domain.AutomationContext.ViewModels;
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
                .AsNoTracking()
                .Include(x => x.Floor)
                    .ThenInclude(x => x.Building)
                    .ThenInclude(x => x.Site)
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<Room> FindByIdAsync(Guid id)
        {
            return await _context.Rooms
                .Where(x => x.Id == id)
                .Include(x => x.Floor)
                .Include(x => x.Equipments)
                .ThenInclude(x => x.EquipmentParameters)
                .FirstOrDefaultAsync();
        }

        public IEnumerable<Room> FindRoomByFloor(Guid floorId)
        {
            return _context.Floors
                .Where(x => x.Id == floorId)
                .Include(x => x.Rooms)
                //.ThenInclude(x => x.Equipments)
                .ThenInclude(x => x.Floor)
                .Select(x => x.Rooms)
                .Single();
        }

        public async Task<IEnumerable<RoomCardViewModel>> LoadCardSettings(Guid buildingId)
        {
            return await _context.Rooms
                .AsNoTracking()
                .Where(x => x.BuildingId == buildingId)
                .Include(x => x.CardSettings)
                    .ThenInclude(x => x.Parameter1)
                    .ThenInclude(x => x.EquipmentParameter)
                .Include(x => x.CardSettings)
                    .ThenInclude(x => x.Parameter2)
                    .ThenInclude(x => x.EquipmentParameter)
                .Include(x => x.CardSettings)
                    .ThenInclude(x => x.Parameter3)
                    .ThenInclude(x => x.EquipmentParameter)
                .Select(x => new RoomCardViewModel
                {
                    Id = x.CardSettings.Id,
                    RoomId = x.Id,
                    BuildingId = x.Building.Id,
                    Name = x.Name,
                    Parameter1 = x.CardSettings.Parameter1,
                    Parameter2 = x.CardSettings.Parameter2,
                    Parameter3 = x.CardSettings.Parameter3
                })
                .ToListAsync();
        }

        public void Update(Room model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }
    }
}