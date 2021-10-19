using System.Collections.Generic;
using EvoDcimManager.Domain.AutomationContext.Entities;

namespace EvoDcimManager.Domain.AutomationContext.Repositories
{
    public interface IAlarmRepository
    {
        void Save(Alarm alarm);
        IEnumerable<Alarm> FindAll();
    }
}