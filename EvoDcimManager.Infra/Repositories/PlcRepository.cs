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

        public void CreateTags(Plc plc)
        {
            var count = plc.ModbusTags.Count();
            _context.ModbusTags.Add(plc.ModbusTags.ElementAt(count - 1));
            _context.SaveChanges();
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
                .Include(x => x.ModbusTags.OrderBy(y => y.Address))
                .OrderBy(x => x.Id)
                .ToList();
        }

        public Plc FindById(Guid id)
        {
            return _context.Plcs
                .Include(x => x.ModbusTags.OrderBy(y => y.Address))
                .FirstOrDefault(x => x.Id == id);
        }

        public Plc FindByName(string name)
        {
            return _context.Plcs
                .Include(x => x.ModbusTags)
                .FirstOrDefault(x => x.Name == name);
        }

        public void Save(Plc plc)
        {
            _context.Plcs.Add(plc);
            _context.SaveChanges();
        }
    }
}