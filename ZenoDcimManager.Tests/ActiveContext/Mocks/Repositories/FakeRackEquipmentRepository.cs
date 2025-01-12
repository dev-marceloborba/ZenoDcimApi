﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Domain.ZenoContext.Enums;
using ZenoDcimManager.Domain.ZenoContext.Repositories;

namespace ZenoDcimManager.Tests.ZenoContext.Mocks.Repositories
{
    public class FakeRackEquipmentRepository : IRackEquipmentRepository
    {
        private readonly List<RackEquipment> _rackEquipments = new List<RackEquipment>();
        private readonly BaseEquipment _baseEquipment;
        public FakeRackEquipmentRepository()
        {
            // _baseEquipment = new BaseEquipment("Server1", "mode1", "manufactor1", "s1232131");
            // _rackEquipments.Add(new RackEquipment(_baseEquipment, 1, 2, ERackEquipmentType.SERVER));
            // _rackEquipments.Add(new RackEquipment(_baseEquipment, 3, 4, ERackEquipmentType.SWITCH));
            // _rackEquipments.Add(new RackEquipment(_baseEquipment, 5, 6, ERackEquipmentType.STORAGE));
        }

        public async Task Commit()
        {

        }

        public async Task Create(RackEquipment rackEquipment)
        {

        }

        public void Delete(RackEquipment rackEquipment)
        {

        }

        public async Task<IEnumerable<RackEquipment>> FindAll()
        {
            return _rackEquipments.ToList();
        }

        public async Task<RackEquipment> FindById(Guid id)
        {
            return _rackEquipments.FirstOrDefault(x => x.Id == id);
        }

        public async Task<RackEquipment> FindByName(string name)
        {
            return new RackEquipment();
            // return _rackEquipments.FirstOrDefault(x => x.BaseEquipment.Name == name);
        }

        public Task<IEnumerable<RackEquipment>> FindEquipmentsWithoutRack()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RackEquipment>> FindRackEquipmentsByRackId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(RackEquipment rackEquipment)
        {

        }
    }
}