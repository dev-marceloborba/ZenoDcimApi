using System;
using System.Collections.Generic;
using System.Linq;
using EvoDcimManager.Domain.ActiveContext.Entities;
using EvoDcimManager.Domain.ActiveContext.Repositories;
using EvoDcimManager.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EvoDcimManager.Infra.Repositories
{
    public class ServerRepository : IServerRepository
    {
        private readonly ActiveContext _context;

        public ServerRepository(ActiveContext context)
        {
            _context = context;
        }

        public void Delete(Server item)
        {
            throw new NotImplementedException();
        }

        public Server Find(Guid id)
        {
            return _context.Servers
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Server> List()
        {
            return _context.Servers
                .AsNoTracking()
                .Include(x => x.BaseEquipment)
                .Include(x => x.Rack)
                .OrderBy(x => x.Id)
                .ToList();
        }

        public void Save(Server item)
        {
            _context.Servers.Add(item);
            _context.SaveChanges();
        }

        public void Update(Server item)
        {
            throw new NotImplementedException();
        }
    }
}