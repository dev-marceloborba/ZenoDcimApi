using System;
using System.Collections.Generic;
using System.Linq;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Domain.AutomationContext.Repositories;
using ZenoDcimManager.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ZenoDcimManager.Infra.Repositories
{
    public class ModbusTagRepository : IModbusTagRepository
    {
        private readonly ZenoContext _context;

        public ModbusTagRepository(ZenoContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
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