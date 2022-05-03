using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenoDcimManager.Domain.ActiveContext.Entities;
using ZenoDcimManager.Domain.ActiveContext.Enums;
using ZenoDcimManager.Domain.ActiveContext.Repositories;

namespace ZenoDcimManager.Tests.ActiveContext.Mocks.Repositories
{
    public class FakeRackRepository : IRackRepository
    {
        private List<Rack> _racks = new List<Rack>();
        private readonly BaseEquipment _serverBase = new BaseEquipment("Server01", "HP-Proliant", "HP", "12345679");
        private readonly RackEquipment _server;
        private Rack _rack;

        public FakeRackRepository()
        {
            _server = new RackEquipment(_serverBase, 1, 2, ERackEquipmentType.SERVER);
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

        public async Task<Rack> Find(Guid id)
        {
            return _racks.Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<IEnumerable<Rack>> List()
        {
            return _racks.ToList();
        }

        public async Task Save(Rack item)
        {
            _racks.Add(item);
        }

        public async Task<Rack> FindByLocalization(string localization)
        {
            return _racks.FirstOrDefault(x => x.Localization == localization);
        }

        public void Update(Rack item)
        {
            throw new NotImplementedException();
        }

        public async Task<Rack> FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task AddRackEquipments(Rack rack)
        {

        }

        public async Task Commit()
        {

        }
    }
}