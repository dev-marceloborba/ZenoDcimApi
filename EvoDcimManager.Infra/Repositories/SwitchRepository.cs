using System;
using System.Collections.Generic;
using System.Linq;
using EvoDcimManager.Domain.ActiveContext.Entities;
using EvoDcimManager.Domain.ActiveContext.Repositories;
using EvoDcimManager.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EvoDcimManager.Infra.Repositories
{
    public class SwitchRepository : ISwitchRepository
    {
        private readonly ActiveContext _context;

        public SwitchRepository(ActiveContext context)
        {
            _context = context;
        }

        public void Delete(Switch item)
        {
            throw new NotImplementedException();
        }

        public Switch Find(Guid id)
        {
            return _context.Switches
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Switch> List()
        {
            return _context.Switches
                .AsNoTracking()
                .Include(x => x.BaseEquipment)
                .OrderBy(x => x.Id)
                .ToList();
        }

        public void Save(Switch item)
        {
            _context.Switches.Add(item);
            _context.SaveChanges();
        }

        public void Update(Switch item)
        {
            throw new NotImplementedException();
        }
    }
}