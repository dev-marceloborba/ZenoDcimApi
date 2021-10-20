using System;
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

        public void Delete(Plc plc)
        {
            _context.Remove(plc);
            _context.SaveChanges();
        }

        public void Edit(Plc plc)
        {
            _context.Entry(plc).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<Plc> FindAll()
        {
            return _context.Plcs
                .AsNoTracking()
                .OrderBy(x => x.Name)
                .ToList();
        }

        public Plc FindById(Guid id)
        {
            return _context.Plcs.FirstOrDefault(x => x.Id == id);
        }

        public void Save(Plc plc)
        {
            _context.Plcs.Add(plc);
            _context.SaveChanges();
        }
    }
}