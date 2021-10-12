using System;
using System.Collections.Generic;
using System.Linq;
using EvoDcimManager.Domain.ActiveContext.Entities;
using EvoDcimManager.Domain.ActiveContext.Repositories;

namespace EvoDcimManager.Tests.ActiveContext.Mocks.Repositories
{
    public class FakeRackRepository : IRackRepository
    {
        private IList<Rack> _racks = new List<Rack>();

        public FakeRackRepository()
        {
            _racks.Add(new Rack(16, "Rack-01"));
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

        public IReadOnlyCollection<Rack> List()
        {
            return _racks.ToList();
        }

        public void Save(Rack item)
        {
            _racks.Add(item);
        }

        public void Update(Rack item)
        {
            // todo
            throw new System.NotImplementedException();
        }
    }
}