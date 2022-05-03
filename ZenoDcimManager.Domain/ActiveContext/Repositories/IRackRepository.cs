using System;
using System.Threading.Tasks;
using ZenoDcimManager.Domain.ActiveContext.Entities;
using ZenoDcimManager.Shared.Repositories;
using ZenoDcimManager.Shared.UnitOfWork;

namespace ZenoDcimManager.Domain.ActiveContext.Repositories
{
    public interface IRackRepository : CrudRepository<Rack>, IUnitOfWork
    {
        Task AddRackEquipments(Rack rack);
        Task<Rack> FindByLocalization(string localization);
        Task<Rack> FindById(Guid id);
    }
}