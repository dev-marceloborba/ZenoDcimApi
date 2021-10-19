using System.Collections.Generic;
using System.Linq;
using EvoDcimManager.Domain.AutomationContext.Entities;
using EvoDcimManager.Domain.AutomationContext.Repositories;
using EvoDcimManager.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EvoDcimManager.Infra.Repositories
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