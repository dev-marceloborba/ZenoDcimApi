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

        public Server Delete(Server item)
        {
            throw new NotImplementedException();
        }

        public Server Find(Guid id)
        {
            var result = _context.Servers
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
            return result;
        }

        public IReadOnlyCollection<Server> List()
        {
            var result = _context.Servers
                .AsNoTracking()
                .OrderBy(x => x.Id)
                .ToList();
            return result;
        }

        public Server Save(Server item)
        {
            _context.Servers.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Server Update(Server item)
        {
            throw new NotImplementedException();
        }
    }
}