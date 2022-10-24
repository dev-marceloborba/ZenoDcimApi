using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Shared.UnitOfWork;

namespace ZenoDcimManager.Domain.ZenoContext.Repositories
{
    public interface IRackEquipmentRepository : IUnitOfWork
    {
        Task Create(RackEquipment rackEquipment);
        Task<IEnumerable<RackEquipment>> FindAll();
        Task<RackEquipment> FindById(Guid id);
        Task<RackEquipment> FindByName(string name);
        Task<IEnumerable<RackEquipment>> FindRackEquipmentsByRackId(Guid id);
        Task<IEnumerable<RackEquipment>> FindEquipmentsWithoutRack();
        void Update(RackEquipment rackEquipment);
        void Delete(RackEquipment rackEquipment);
    }
}