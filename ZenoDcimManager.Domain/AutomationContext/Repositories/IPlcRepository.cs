using System;
using System.Collections.Generic;
using ZenoDcimManager.Domain.AutomationContext.Entities;

namespace ZenoDcimManager.Domain.AutomationContext.Repositories
{
    public interface IPlcRepository
    {
        void CreateTags(Plc plc);
        void Delete(Plc plc);
        void Edit(Plc plc);
        void Save(Plc plc);
        Plc FindById(Guid id);
        Plc FindByName(string name);
        IEnumerable<Plc> FindAll();
    }
}