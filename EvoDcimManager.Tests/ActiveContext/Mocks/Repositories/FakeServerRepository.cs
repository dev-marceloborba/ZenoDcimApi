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
        private readonly Cpu _cpu = new Cpu("Intel Xeon 16C 2.4GHz");
        private readonly Memory _memory = new Memory(32);
        private readonly Capacity _storage = new Capacity(512);
        private readonly Name _serverName = new Name("Server01");
        private readonly BaseEquipment _serverBase = new BaseEquipment("Server01", "HP-Proliant", "HP", "12345679");
        private readonly Capacity _occupation = new Capacity(2);

        public FakeServerRepository()
        {
            _servers.Add(new Server(_serverBase, _occupation, _cpu, _memory, _storage));
        }

        public Server Delete(Server item)
        {
            _servers.Remove(item);
            return item;
        }

        public IReadOnlyCollection<Server> List()
        {
            return _servers.ToList();
        }

        public Server Save(Server item)
        {
            _servers.Add(item);
            return item;
        }

        public Server Update(Server item)
        {
            throw new System.NotImplementedException();
        }

        public Server Find(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}