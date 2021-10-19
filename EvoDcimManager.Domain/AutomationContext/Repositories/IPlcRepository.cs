using System.Collections.Generic;
using EvoDcimManager.Domain.AutomationContext.Entities;

namespace EvoDcimManager.Domain.AutomationContext.Repositories
{
    public interface IPlcRepository
    {
        void Save(Plc plc);
        IEnumerable<Plc> FindAll();
    }
}