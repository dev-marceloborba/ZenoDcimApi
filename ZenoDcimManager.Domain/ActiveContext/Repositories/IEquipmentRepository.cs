using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZenoDcimManager.Domain.AutomationContext.ViewModels;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Shared.Repositories;
using ZenoDcimManager.Shared.UnitOfWork;

namespace ZenoDcimManager.Domain.ZenoContext.Repositories
{
    public interface IEquipmentRepository : CrudRepository<Equipment>, IUnitOfWork
    {
        Task<Equipment> FindEquipmentByName(Guid siteId, Guid buildingId, Guid floorId, Guid roomId, string name);
        IEnumerable<Equipment> FindEquipmentByRoom(Guid roomId);
        Task<IEnumerable<EquipmentCardViewModel>> LoadEquipmentCards(Guid roomId);
    }
}