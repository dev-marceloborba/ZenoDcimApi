using System;
using System.Collections.Generic;
using EvoDcimManager.Domain.AutomationContext.Entities;

namespace EvoDcimManager.Domain.AutomationContext.Repositories
{
    public interface IModbusTagRepository
    {
        void Delete(ModbusTag modbusTag);
        void Edit(ModbusTag modbusTag);
        void Save(ModbusTag modbusTag);
        ModbusTag FindById(Guid id);
        IEnumerable<ModbusTag> FindAll();
    }
}