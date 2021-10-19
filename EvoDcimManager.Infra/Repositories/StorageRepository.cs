using System;
using System.Collections.Generic;
using System.Linq;
using EvoDcimManager.Domain.ActiveContext.Entities;
using EvoDcimManager.Domain.ActiveContext.Repositories;
using EvoDcimManager.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EvoDcimManager.Infra.Repositories
{
    public class StorageRepository : IStorageRepository
    {
        private readonly ActiveContext _context;

        public StorageRepository(ActiveContext context)
        {
            _context = context;
        }

        public void Delete(Storage item)
        {
            throw new NotImplementedException();
        }

        public Storage Find(Guid id)
        {
            return _context.Storages
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Storage> List()
        {
            return _context.Storages
              .AsNoTracking()
              .Include(x => x.BaseEquipment)
              .OrderBy(x => x.Id)
              .ToList();
        }

        public void Save(Storage item)
        {
            _context.Storages.Add(item);
            _context.SaveChanges();
        }

        public void Update(Storage item)
        {
            throw new NotImplementedException();
        }
    }
}