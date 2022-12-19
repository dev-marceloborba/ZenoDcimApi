using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZenoDcimManager.Domain.AutomationContext.ViewModels;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Shared.Repositories;
using ZenoDcimManager.Shared.UnitOfWork;

namespace ZenoDcimManager.Domain.ZenoContext.Repositories
{
    public interface IRoomRepository : CrudRepository<Room>, IUnitOfWork
    {
        IEnumerable<Room> FindRoomByFloor(Guid floorId);
        Task<IEnumerable<RoomCardViewModel>> LoadCardSettings(Guid buildingId);
    }
}