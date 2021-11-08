using System.Collections.Generic;
using ZenoDcimManager.Domain.AutomationContext.Entities;

namespace ZenoDcimManager.Domain.AutomationContext.Repositories
{
    public interface IAlarmRepository
    {
        void Save(Alarm alarm);
        IEnumerable<Alarm> FindAll();
    }
}