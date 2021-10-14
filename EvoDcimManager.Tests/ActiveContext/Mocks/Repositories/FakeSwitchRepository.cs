using System;
using System.Collections.Generic;
using System.Linq;
using EvoDcimManager.Domain.ActiveContext.Entities;
using EvoDcimManager.Domain.ActiveContext.Repositories;
using EvoDcimManager.Domain.ActiveContext.ValueObjects;

namespace EvoDcimManager.Tests.ActiveContext.Mocks.Repositories
{
    public class FakeSwitchRepository : ISwitchRepository
    {
        private IList<Switch> _switches = new List<Switch>();
        private readonly BaseEquipment _baseEquipment = new BaseEquipment("Switch1", "STW1", "Datacom", "12345679");
        private readonly RackPosition _rackSlot = new RackPosition(1, 2);

        public FakeSwitchRepository()
        {
            _switches.Add(new Switch(_baseEquipment, 4));
        }

        public void Delete(Switch item)
        {
            throw new NotImplementedException();
        }

        public Switch Find(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Switch> List()
        {
            return _switches.ToList();
        }

        public void Save(Switch item)
        {
            _switches.Add(item);
        }

        public void Update(Switch item)
        {
            throw new NotImplementedException();
        }
    }
}