using System;
using System.Collections.Generic;
using System.Linq;
using EvoDcimManager.Domain.ActiveContext.Entities;
using EvoDcimManager.Domain.ActiveContext.Repositories;
using EvoDcimManager.Domain.ActiveContext.ValueObjects;

namespace EvoDcimManager.Tests.ActiveContext.Mocks.Repositories
{
    public class FakeServerRepository : IServerRepository
    {
        private IList<Server> _servers = new List<Server>();
        private readonly string _cpu = "Intel Xeon 16C 2.4GHz";
        private readonly int _memory = 32;
        private readonly int _storage = 512;
        private readonly Name _serverName = new Name("Server01");
        private readonly BaseEquipment _serverBase = new BaseEquipment("Server01", "HP-Proliant", "HP", "12345679");
        private readonly Capacity _occupation = new Capacity(2);
        private readonly RackPosition _rackSlot = new RackPosition(1, 2);

        public FakeServerRepository()
        {
            _servers.Add(new Server(_serverBase, _cpu, _memory, _storage));
        }

        public void Delete(Server item)
        {
            _servers.Remove(item);
        }

        public IEnumerable<Server> List()
        {
            return _servers.ToList();
        }

        public void Save(Server item)
        {
            _servers.Add(item);
        }

        public void Update(Server item)
        {
            throw new System.NotImplementedException();
        }

        public Server Find(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}