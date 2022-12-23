using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Domain.AutomationContext.Repositories;
using ZenoDcimManager.Infra.Contexts;

namespace ZenoDcimManager.Infra.Repositories
{
    public class AlarmRuleRepository : IAlarmRuleRepository
    {
        private readonly ZenoContext _context;

        public AlarmRuleRepository(ZenoContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(AlarmRule model)
        {
            await _context.AlarmRules.AddAsync(model);
        }

        public void Delete(AlarmRule model)
        {
            _context.Entry(model).State = EntityState.Deleted;
        }

        public async Task<IEnumerable<AlarmRule>> FindAlarmRulesByEquipmentId(Guid id)
        {
            return await _context.AlarmRules
                .AsNoTracking()
                .Include(x => x.EquipmentParameter)
                    .ThenInclude(x => x.Equipment)
                .Where(x => x.EquipmentParameter.EquipmentId == id)
                .ToListAsync();
        }

        public async Task<IEnumerable<AlarmRule>> FindAlarmRulesByEquipmentParameterId(Guid id)
        {
            return await _context.EquipmentParameters
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Include(x => x.AlarmRules)
                .Select(x => x.AlarmRules)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<AlarmRule>> FindAllAsync()
        {
            return await _context.AlarmRules
                .AsNoTracking()
                .Include(x => x.EquipmentParameter)
                .ToListAsync();
        }

        public async Task<AlarmRule> FindByIdAsync(Guid id)
        {
            return await _context.AlarmRules
                .Where(x => x.Id == id)
                .Include(x => x.EquipmentParameter)
                .FirstOrDefaultAsync();
        }

        public void Update(AlarmRule model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }
    }
}