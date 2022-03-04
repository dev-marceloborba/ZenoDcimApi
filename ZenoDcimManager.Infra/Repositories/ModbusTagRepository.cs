using System;
using System.Collections.Generic;
using System.Linq;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Domain.AutomationContext.Repositories;
using ZenoDcimManager.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ZenoDcimManager.Infra.Repositories
{
    public class ModbusTagRepository : IModbusTagRepository
    {
        private readonly AutomationContext _context;

        public ModbusTagRepository(AutomationContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Delete(ModbusTag modbusTag)
        {
            _context.ModbusTags.Remove(modbusTag);
        }

        public void DeleteAllByClp(Plc plc)
        {
            plc.ModbusTags.Clear();
            _context.Entry(plc).State = EntityState.Deleted;
        }

        public void Edit(ModbusTag modbusTag)
        {
            _context.Entry(modbusTag).State = EntityState.Modified;
        }

        public IEnumerable<ModbusTag> FindAll()
        {
            return _context.ModbusTags
                .AsNoTracking()
                .OrderBy(x => x.Address)
                .ToList();
        }

        public ModbusTag FindById(Guid id)
        {
            return _context.ModbusTags
                .FirstOrDefault(x => x.Id == id);
        }

        public void Save(ModbusTag modbusTag)
        {
            _context.ModbusTags.Add(modbusTag);
        }

        public void SaveMultiple(List<ModbusTag> modbusTags)
        {
            _context.ModbusTags.AddRange(modbusTags);
        }
    }
}