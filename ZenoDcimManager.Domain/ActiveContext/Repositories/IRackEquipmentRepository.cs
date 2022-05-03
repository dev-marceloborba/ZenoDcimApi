using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZenoDcimManager.Domain.ActiveContext.Entities;
using ZenoDcimManager.Shared.UnitOfWork;

namespace ZenoDcimManager.Domain.ActiveContext.Repositories
{
    public interface IRackEquipmentRepository : IUnitOfWork
    {
        Task Create(RackEquipment rackEquipment);
        Task<IEnumerable<RackEquipment>> FindAll();
        Task<RackEquipment> FindById(Guid id);
        Task<RackEquipment> FindByName(string name);
        void Update(RackEquipment rackEquipment);
        void Delete(RackEquipment rackEquipment);
    }
}