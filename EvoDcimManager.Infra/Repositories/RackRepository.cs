using System;
using System.Collections.Generic;
using System.Linq;
using EvoDcimManager.Domain.ActiveContext.Entities;
using EvoDcimManager.Domain.ActiveContext.Repositories;
using EvoDcimManager.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EvoDcimManager.Infra.Repositories
{
    public class RackRepository : IRackRepository
    {
        private readonly ActiveContext _context;
        public RackRepository(ActiveContext context)
        {
            _context = context;
        }
        public void Delete(Rack item)
        {
            throw new NotImplementedException();
        }

        public Rack Find(Guid id)
        {
            return _context.Racks
                .AsNoTracking()
                .Include(x => x.Slots)
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Rack> List()
        {
            return _context.Racks
                .AsNoTracking()
                .Include(x => x.Slots)
                .ThenInclude(x => x.Equipment.BaseEquipment)
                .Include(x => x.Slots)
                .ThenInclude(x => x.Equipment.Rack)
                .OrderBy(x => x.Id)
                .ToList();
        }

        public void Save(Rack item)
        {
            _context.Racks.Add(item);
            _context.SaveChanges();
        }

        public void Update(Rack item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void UpdateRackSlots(IEnumerable<RackPosition> positions)
        {
            _context.Entry(positions).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}