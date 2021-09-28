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
        public Rack Delete(Rack item)
        {
            throw new NotImplementedException();
        }

        public Rack Find(Guid id)
        {
            var result = _context.Racks
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
            return result;
        }

        public IReadOnlyCollection<Rack> List()
        {
            var result = _context.Racks
                .AsNoTracking()
                .OrderBy(x => x.Id)
                .ToList();
            return result;
        }

        public Rack Save(Rack item)
        {
            _context.Racks.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Rack Update(Rack item)
        {
            throw new NotImplementedException();
        }
    }
}