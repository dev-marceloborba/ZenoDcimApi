using System;
using System.Collections.Generic;
using EvoDcimManager.Domain.ActiveContext.Entities;
using EvoDcimManager.Shared.Repositories;

namespace EvoDcimManager.Domain.ActiveContext.Repositories
{
    public interface IRackRepository : CrudRepository<Rack>
    {
        void UpdateRackSlots(IEnumerable<RackPosition> rackPosition);
    }
}