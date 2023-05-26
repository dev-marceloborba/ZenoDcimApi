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
    public class EquipmentParameterRepository : IEquipmentParameterRepository
    {
        private readonly ZenoContext _context;

        public EquipmentParameterRepository(ZenoContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(EquipmentParameter model)
        {
            await _context.EquipmentParameters.AddAsync(model);
        }

        public void Delete(EquipmentParameter model)
        {
            _context.Entry(model).State = EntityState.Deleted;
        }

        public async Task<IEnumerable<EquipmentParameter>> FindAllAsync()
        {
            return await _context.EquipmentParameters
                .AsNoTracking()
                .Include(x => x.AlarmRules)
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<EquipmentParameter> FindByIdAsync(Guid id)
        {
            return await _context.EquipmentParameters
                .Where(x => x.Id == id)
                .Include(x => x.AlarmRules.OrderBy(y => y.Setpoint))
                .FirstOrDefaultAsync();
        }

        public async Task<EquipmentParameter> FindByIdWithoutTracking(Guid id)
        {
            return await _context.EquipmentParameters
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Include(x => x.AlarmRules)
                .FirstOrDefaultAsync();
        }

        public IList<EquipmentParameter> FindParametersByEquipmentId(Guid id)
        {
            // return _context.Equipments
            //     .Where(x => x.Id == id)
            //     .Select(x => x.EquipmentParameters)
            //     .First()
            //     .OrderBy(x => x.Name)
            //     .ToList();
            return _context.EquipmentParameters
                .Include(x => x.Equipment)
                .ThenInclude(x => x.Room)
                .ThenInclude(x => x.Floor)
                .ThenInclude(x => x.Building)
                .ThenInclude(x => x.Site)
                .Where(x => x.EquipmentId == id)
                .OrderBy(x => x.Name)
                .ToList();
        }

        public async Task<IEnumerable<EquipmentParameter>> FindParametersContainingName(string name)
        {
            return await _context.EquipmentParameters
                .Where(x => x.Pathname.Contains(name))
                .ToListAsync();
        }

        public void Update(EquipmentParameter model)
        {
            _context.Entry(model).State = EntityState.Modified;
            // _context.EquipmentParameters.Update(model);
        }
    }
}