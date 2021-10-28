using System;
using System.Collections.Generic;
using System.Linq;
using EvoDcimManager.Domain.ActiveContext.Entities;
using EvoDcimManager.Domain.ActiveContext.Enums;
using EvoDcimManager.Domain.ActiveContext.Repositories;

namespace EvoDcimManager.Tests.ActiveContext.Mocks.Repositories
{
    public class FakeRackEquipmentRepository : IRackEquipmentRepository
    {
        private readonly List<RackEquipment> _rackEquipments = new List<RackEquipment>();
        private readonly BaseEquipment _baseEquipment;
        public FakeRackEquipmentRepository()
        {
            _baseEquipment = new BaseEquipment("Server1", "mode1", "manufactor1", "s1232131");
            _rackEquipments.Add(new RackEquipment(_baseEquipment, 1, 2, ERackEquipmentType.SERVER));
            _rackEquipments.Add(new RackEquipment(_baseEquipment, 3, 4, ERackEquipmentType.SWITCH));
            _rackEquipments.Add(new RackEquipment(_baseEquipment, 5, 6, ERackEquipmentType.STORAGE));
        }
        public void Create(RackEquipment rackEquipment)
        {

        }

        public void Delete(RackEquipment rackEquipment)
        {

        }

        public IEnumerable<RackEquipment> FindAll()
        {
            return _rackEquipments.ToList();
        }

        public RackEquipment FindById(Guid id)
        {
            return _rackEquipments.FirstOrDefault(x => x.Id == id);
        }

        public RackEquipment FindByName(string name)
        {
            return new RackEquipment();
            // return _rackEquipments.FirstOrDefault(x => x.BaseEquipment.Name == name);
        }

        public void Update(RackEquipment rackEquipment)
        {

        }
    }
}