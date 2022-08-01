using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Shared.Repositories;
using ZenoDcimManager.Shared.UnitOfWork;

namespace ZenoDcimManager.Domain.AutomationContext.Repositories
{
    public interface IAlarmRuleRepository : CrudRepository<AlarmRule>, IUnitOfWork
    {
        Task<IEnumerable<AlarmRule>> FindAlarmRulesByEquipmentParameterId(Guid id);
    }
}