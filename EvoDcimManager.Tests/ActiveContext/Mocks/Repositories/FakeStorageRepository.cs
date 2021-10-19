using System;
using System.Collections.Generic;
using System.Linq;
using EvoDcimManager.Domain.ActiveContext.Entities;
using EvoDcimManager.Domain.ActiveContext.Repositories;
using EvoDcimManager.Domain.ActiveContext.ValueObjects;

namespace EvoDcimManager.Tests.ActiveContext.Mocks.Repositories
{
    public class FakeStorageRepository : IStorageRepository
    {
        private IList<Storage> _storages = new List<Storage>();
        private readonly BaseEquipment _baseEquipment = new BaseEquipment("Storage1", "STG1", "Seagate", "12345679");
        private readonly int _capactity = 512;

        public FakeStorageRepository()
        {
            _storages.Add(new Storage(_baseEquipment, 1, 2, _capactity));
        }

        public void Delete(Storage item)
        {
            throw new NotImplementedException();
        }

        public Storage Find(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Storage> List()
        {
            return _storages.ToList();
        }

        public void Save(Storage item)
        {
            _storages.Add(item);
        }

        public void Update(Storage item)
        {
            throw new NotImplementedException();
        }
    }
}