using System;
using System.Collections.Generic;
using System.Linq;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Domain.AutomationContext.Repositories;
using ZenoDcimManager.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ZenoDcimManager.Infra.Repositories
{
    public class PlcRepository : IPlcRepository
    {
        private readonly AutomationContext _context;

        public PlcRepository(AutomationContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void CreateTags(Plc plc)
        {
            var count = plc.ModbusTags.Count();
            _context.ModbusTags.Add(plc.ModbusTags.ElementAt(count - 1));
        }

        public void Delete(Plc plc)
        {
            _context.Remove(plc);
        }

        public void Edit(Plc plc)
        {
            _context.Entry(plc).State = EntityState.Modified;
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
        }
    }
}