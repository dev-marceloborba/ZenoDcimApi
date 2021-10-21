using System;
using System.Collections.Generic;
using System.Linq;
using EvoDcimManager.Domain.ActiveContext.Entities;
using EvoDcimManager.Domain.ActiveContext.Repositories;

namespace EvoDcimManager.Tests.ActiveContext.Mocks.Repositories
{
    public class FakeRackRepository : IRackRepository
    {
        private List<Rack> _racks = new List<Rack>();
        private readonly BaseEquipment _serverBase = new BaseEquipment("Server01", "HP-Proliant", "HP", "12345679");
        private readonly Server _server;
        private Rack _rack;

        public FakeRackRepository()
        {
            _server = new Server(_serverBase, 1, 2, "Intel xeon", 128, 512);
            _rack = new Rack(16, "Rack-01");
            _rack.PlaceEquipment(_server);

            _racks.Add(_rack);
            _racks.Add(new Rack(16, "Rack-02"));
            _racks.Add(new Rack(16, "Rack-03"));
            _racks.Add(new Rack(16, "Rack-04"));
            _racks.Add(new Rack(16, "Rack-05"));
            _racks.Add(new Rack(16, "Rack-06"));
        }

        public void Delete(Rack item)
        {
            _racks.Remove(item);
        }

        public Rack Find(Guid id)
        {
            return _racks.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Rack> List()
        {
            return _racks.ToList();
        }

        public void Save(Rack item)
        {
            _racks.Add(item);
        }

        public Rack FindByLocalization(string localization)
        {
            return _racks.FirstOrDefault(x => x.Localization == localization);
        }

        public void Update(Rack item)
        {
            throw new NotImplementedException();
        }

        public Rack FindById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}