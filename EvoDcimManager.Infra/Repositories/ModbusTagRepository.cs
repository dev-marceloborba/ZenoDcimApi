using System.Collections.Generic;
using System.Linq;
using EvoDcimManager.Domain.AutomationContext.Entities;
using EvoDcimManager.Domain.AutomationContext.Repositories;
using EvoDcimManager.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EvoDcimManager.Infra.Repositories
{
    public class ModbusTagRepository : IModbusTagRepository
    {
        private readonly AutomationContext _context;

        public ModbusTagRepository(AutomationContext context)
        {
            _context = context;
        }

        public IEnumerable<ModbusTag> FindAll()
        {
            return _context.ModbusTags
                .AsNoTracking()
                .ToList();
        }

        public void Save(ModbusTag modbusTag)
        {
            _context.ModbusTags.Add(modbusTag);
            _context.SaveChanges();
        }
    }
}