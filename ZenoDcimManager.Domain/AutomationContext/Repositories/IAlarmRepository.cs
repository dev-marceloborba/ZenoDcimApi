using System.Collections.Generic;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Shared.UnitOfWork;

namespace ZenoDcimManager.Domain.AutomationContext.Repositories
{
    public interface IAlarmRepository : IUnitOfWork
    {
        void Save(Alarm alarm);
        IEnumerable<Alarm> FindAll();
    }
}