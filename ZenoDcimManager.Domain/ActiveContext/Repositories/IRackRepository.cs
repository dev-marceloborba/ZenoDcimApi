using System;
using System.Collections.Generic;
using ZenoDcimManager.Domain.ActiveContext.Entities;
using ZenoDcimManager.Shared.Repositories;
using ZenoDcimManager.Shared.UnitOfWork;

namespace ZenoDcimManager.Domain.ActiveContext.Repositories
{
    public interface IRackRepository : CrudRepository<Rack>, IUnitOfWork
    {
        void AddRackEquipments(Rack rack);
        Rack FindByLocalization(string localization);
        Rack FindById(Guid id);
    }
}