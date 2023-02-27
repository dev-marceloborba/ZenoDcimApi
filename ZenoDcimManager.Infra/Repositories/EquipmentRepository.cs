using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZenoDcimManager.Domain.AutomationContext.ViewModels;
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
                .AsNoTracking()
                .Include(x => x.Site)
                .Include(x => x.Building)
                .Include(x => x.Floor)
                .Include(x => x.Room)
                .Include(x => x.EquipmentParameters)
                .OrderBy(x => x.Component)
                .ToListAsync();
        }

        public async Task<Equipment> FindByIdAsync(Guid id)
        {
            return await _context.Equipments
                .Where(x => x.Id == id)
                .Include(x => x.Site)
                .Include(x => x.Building)
                .Include(x => x.Floor)
                .Include(x => x.Room)
                .Include(x => x.EquipmentParameters)
                    .ThenInclude(x => x.AlarmRules.OrderBy(x => x.Setpoint))
                .FirstOrDefaultAsync();

            // TODO: a tabela de equipamento pode ter relação apenas com Room, visto:
            // Equipment tem relação 1:1 com Room
            // Room tem relação 1:1 com Floor
            // Floor tem relação 1:1 com Building
            // Building tem relação 1:1 com Site

            // return await _context.Equipments
            //     .Where(x => x.Id == id)
            //         .Include(x => x.Room)
            //             .ThenInclude(x => x.Floor)
            //             .ThenInclude(x => x.Building)
            //             .ThenInclude(x => x.Site)
            //         .Include(x => x.EquipmentParameters)
            //             .ThenInclude(x => x.AlarmRules)
            //     .FirstOrDefaultAsync();
        }

        public IEnumerable<Equipment> FindEquipmentByRoom(Guid roomId)
        {
            return _context.Rooms
                .Where(x => x.Id == roomId)
                .Select(x => x.Equipments)
                .Single();
        }

        public async Task<IEnumerable<EquipmentCardViewModel>> LoadEquipmentCards(Guid roomId)
        {
            return await _context.Equipments
                .AsNoTracking()
                .Where(x => x.RoomId == roomId)
                .Include(x => x.CardSettings)
                    .ThenInclude(x => x.Parameter1)
                    .ThenInclude(x => x.EquipmentParameter)
                .Include(x => x.CardSettings)
                    .ThenInclude(x => x.Parameter2)
                    .ThenInclude(x => x.EquipmentParameter)
                .Include(x => x.CardSettings)
                    .ThenInclude(x => x.Parameter3)
                    .ThenInclude(x => x.EquipmentParameter)
                .Select(x => new EquipmentCardViewModel
                {
                    Id = x.CardSettings.Id == null ? new Guid() : x.CardSettings.Id,
                    EquipmentId = x.Id,
                    RoomId = (Guid)x.RoomId,
                    Name = x.Component,
                    Parameter1 = x.CardSettings.Parameter1,
                    Parameter2 = x.CardSettings.Parameter2,
                    Parameter3 = x.CardSettings.Parameter3,
                })
                .ToListAsync();
        }

        public void Update(Equipment model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }
    }
}