using System.Collections.Generic;
using System.Linq;
using EvoDcimManager.Domain.AutomationContext.Entities;
using EvoDcimManager.Domain.AutomationContext.Repositories;
using EvoDcimManager.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EvoDcimManager.Infra.Repositories
{
    public class PlcRepository : IPlcRepository
    {
        private readonly AutomationContext _context;

        public PlcRepository(AutomationContext context)
        {
            _context = context;
        }

        public IEnumerable<Plc> FindAll()
        {
            return _context.Plcs.AsNoTracking().ToList();
        }

        public void Save(Plc plc)
        {
            _context.Plcs.Add(plc);
            _context.SaveChanges();
        }
    }
}