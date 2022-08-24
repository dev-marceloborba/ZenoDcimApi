using System.Collections.Generic;
using System.Linq;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Domain.AutomationContext.Repositories;
using ZenoDcimManager.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using ZenoDcimManager.Domain.AutomationContext.ViewModels;

namespace ZenoDcimManager.Infra.Repositories
{
    public class AlarmRepository : IAlarmRepository
    {
        private readonly ZenoContext _context;

        public AlarmRepository(ZenoContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(Alarm model)
        {
            await _context.Alarms.AddAsync(model);
        }

        public void Delete(Alarm model)
        {
            _context.Entry(model).State = EntityState.Deleted;
        }

        public async Task<IEnumerable<Alarm>> FindAllAsync()
        {
            return await _context.Alarms
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Alarm> FindByIdAsync(Guid id)
        {
            return await _context.Alarms
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<Alarm>> GetFilteredAlarms(AlarmFiltersViewModel filters)
        {
            // return await _context.Alarms.AsNoTracking().ToListAsync();
            var result = await _context.Alarms
                .Include(x => x.AlarmRule)
                .Select(x => new
                {
                    Value = x.Value,
                    Status = x.Status,
                    Enabled = x.Enabled,
                    Id = x.Id,
                    CreatedDate = x.CreatedDate,
                    ModifiedDate = x.ModifiedDate,
                    AlarmRule = x.AlarmRule
                })
                .ToListAsync();
            // .Where(x => x.CreatedDate >= filters.InitialDate && x.CreatedDate <= filters.FinalDate)
            //     .ToList().AsEnumerable();

            return (IList<Alarm>)result;

            // return (IEnumerable<Alarm>)result;

            // .ThenInclude(x => x.EquipmentParameter)
            // .ThenInclude(x => x.Equipment)
            // .ThenInclude(x => x.Floor)
            // .ThenInclude(x => x.Building)

            // .Where(x => x.CreatedDate >= filters.InitialDate && x.CreatedDate <= filters.FinalDate)
            // .ToListAsync();
        }

        public void Update(Alarm model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }
    }
}