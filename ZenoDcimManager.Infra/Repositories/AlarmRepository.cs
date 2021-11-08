using System.Collections.Generic;
using System.Linq;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Domain.AutomationContext.Repositories;
using ZenoDcimManager.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ZenoDcimManager.Infra.Repositories
{
    public class AlarmRepository : IAlarmRepository
    {
        private readonly AutomationContext _context;

        public AlarmRepository(AutomationContext context)
        {
            _context = context;
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
            _context.SaveChanges();
        }
    }
}