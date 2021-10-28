using System;
using System.Collections.Generic;
using EvoDcimManager.Domain.ActiveContext.Entities;
using EvoDcimManager.Shared.Repositories;

namespace EvoDcimManager.Domain.ActiveContext.Repositories
{
    public interface IRackRepository : CrudRepository<Rack>
    {
        void AddRackEquipments(Rack rack);
        Rack FindByLocalization(string localization);
        Rack FindById(Guid id);
    }
}