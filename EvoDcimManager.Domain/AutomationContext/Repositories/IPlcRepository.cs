using System;
using System.Collections.Generic;
using EvoDcimManager.Domain.AutomationContext.Entities;

namespace EvoDcimManager.Domain.AutomationContext.Repositories
{
    public interface IPlcRepository
    {
        void Delete(Plc plc);
        void Edit(Plc plc);
        void Save(Plc plc);
        Plc FindById(Guid id);
        IEnumerable<Plc> FindAll();
    }
}