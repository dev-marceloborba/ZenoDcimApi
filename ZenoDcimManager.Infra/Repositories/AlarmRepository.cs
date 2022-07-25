using System.Collections.Generic;
using System.Linq;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Domain.AutomationContext.Repositories;
using ZenoDcimManager.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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

        public IEnumerable<Alarm> FindAll()
        {
            return _context.Alarms
                .AsNoTracking()
                .ToList();
        }

        public void Save(Alarm alarm)
        {
            _context.Alarms.Add(alarm);
        }
    }
}