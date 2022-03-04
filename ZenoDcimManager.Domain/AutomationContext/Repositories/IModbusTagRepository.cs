using System;
using System.Collections.Generic;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Shared.UnitOfWork;

namespace ZenoDcimManager.Domain.AutomationContext.Repositories
{
    public interface IModbusTagRepository : IUnitOfWork
    {
        void Delete(ModbusTag modbusTag);
        void Edit(ModbusTag modbusTag);
        void Save(ModbusTag modbusTag);
        void SaveMultiple(List<ModbusTag> modbusTags);
        void DeleteAllByClp(Plc plc);
        ModbusTag FindById(Guid id);
        IEnumerable<ModbusTag> FindAll();
    }
}