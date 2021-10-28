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

        public void AddRackEquipments(Rack rack)
        {
            foreach (var item in rack.RackEquipments)
            {
                _context.RackEquipments.Add(item);
            }
            _context.SaveChanges();
        }

        public void Delete(Rack item)
        {
            _context.Racks.Remove(item);
            _context.SaveChanges();
        }

        public Rack Find(Guid id)
        {
            return _context.Racks
                .AsNoTracking()
                .Include(x => x.RackEquipments)
                .FirstOrDefault(x => x.Id == id);
        }

        public Rack FindById(Guid id)
        {
            return _context.Racks.FirstOrDefault(x => x.Id == id);
        }

        public Rack FindByLocalization(string localization)
        {
            return _context.Racks
                .Include(x => x.RackEquipments)
                .FirstOrDefault(x => x.Localization == localization);
        }

        public IEnumerable<Rack> List()
        {
            return _context.Racks
                .AsNoTracking()
                .Include(x => x.RackEquipments)
                .ThenInclude(x => x.BaseEquipment)
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
    }
}