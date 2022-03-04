using System;
using System.Collections.Generic;
using System.Linq;
using ZenoDcimManager.Domain.ActiveContext.Entities;
using ZenoDcimManager.Domain.ActiveContext.Repositories;
using ZenoDcimManager.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ZenoDcimManager.Infra.Repositories
{
    public class RackEquipmentRepository : IRackEquipmentRepository
    {
        private readonly ActiveContext _context;

        public RackEquipmentRepository(ActiveContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Create(RackEquipment rackEquipment)
        {
            _context.RackEquipments.Add(rackEquipment);
        }

        public void Delete(RackEquipment rackEquipment)
        {
            _context.RackEquipments.Remove(rackEquipment);
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
        }
    }
}