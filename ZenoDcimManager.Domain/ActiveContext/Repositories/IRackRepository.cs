using System;
using System.Threading.Tasks;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Shared.Repositories;
using ZenoDcimManager.Shared.UnitOfWork;

namespace ZenoDcimManager.Domain.ZenoContext.Repositories
{
    public interface IRackRepository : CrudRepository<Rack>, IUnitOfWork
    {
        Task AddRackEquipments(Rack rack);
        Task<Rack> FindByLocalization(string localization);
    }
}