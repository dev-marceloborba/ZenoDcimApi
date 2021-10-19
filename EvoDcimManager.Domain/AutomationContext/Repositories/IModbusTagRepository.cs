using System.Collections.Generic;
using EvoDcimManager.Domain.AutomationContext.Entities;

namespace EvoDcimManager.Domain.AutomationContext.Repositories
{
    public interface IModbusTagRepository
    {
        void Save(ModbusTag modbusTag);
        IEnumerable<ModbusTag> FindAll();
    }
}