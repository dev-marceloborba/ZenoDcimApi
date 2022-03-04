using System;
using System.Collections.Generic;
using ZenoDcimManager.Domain.ActiveContext.Entities;
using ZenoDcimManager.Shared.UnitOfWork;

namespace ZenoDcimManager.Domain.ActiveContext.Repositories
{
    public interface IRackEquipmentRepository : IUnitOfWork
    {
        void Create(RackEquipment rackEquipment);
        IEnumerable<RackEquipment> FindAll();
        RackEquipment FindById(Guid id);
        RackEquipment FindByName(string name);
        void Update(RackEquipment rackEquipment);
        void Delete(RackEquipment rackEquipment);
    }
}