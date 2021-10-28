using System;
using System.Collections.Generic;
using System.Linq;
using EvoDcimManager.Domain.ActiveContext.Entities;
using EvoDcimManager.Domain.ActiveContext.Repositories;
using EvoDcimManager.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EvoDcimManager.Infra.Repositories
{
    public class RackEquipmentRepository : IRackEquipmentRepository
    {
        private readonly ActiveContext _context;

        public RackEquipmentRepository(ActiveContext context)
        {
            _context = context;
        }

        public void Create(RackEquipment rackEquipment)
        {
            _context.RackEquipments.Add(rackEquipment);
            _context.SaveChanges();
        }

        public void Delete(RackEquipment rackEquipment)
        {
            _context.RackEquipments.Remove(rackEquipment);
            _context.SaveChanges();
        }

        public IEnumerable<RackEquipment> FindAll()
        {
            return _context.RackEquipments
                .AsNoTracking()
                .Include(x => x.BaseEquipment)
                .OrderBy(x => x.InitialPosition)
                .ToList();
        }

        public RackEquipment FindById(Guid id)
        {
            return _context.RackEquipments
                .Include(x => x.BaseEquipment)
                .FirstOrDefault(x => x.Id == id);
        }

        public RackEquipment FindByName(string name)
        {
            return _context.RackEquipments
                .Include(x => x.BaseEquipment)
                .FirstOrDefault(x => x.BaseEquipment.Name == name);
        }

        public void Update(RackEquipment rackEquipment)
        {
            _context.Entry(rackEquipment).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}