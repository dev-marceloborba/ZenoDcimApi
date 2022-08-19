using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Domain.AutomationContext.Repositories;
using ZenoDcimManager.Domain.AutomationContext.ViewModels;
using ZenoDcimManager.Infra.Contexts;

namespace ZenoDcimManager.Infra.Repositories
{
    public class MeasureRepository : IMeasureRepository
    {
        private readonly ZenoContext _context;

        public MeasureRepository(ZenoContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(Measure measure)
        {
            await _context.Measures.AddAsync(measure);
        }

        public async Task CreateMultipleAsync(IEnumerable<Measure> measures)
        {
            await _context.Measures.AddRangeAsync(measures);
        }

        public async Task<IEnumerable<Measure>> FindAllAsync(HistoryFiltersViewModel filter)
        {
            return await _context.Measures
                .AsNoTracking()
                .Where(x => x.Timestamp >= filter.InitialDate && x.Timestamp <= filter.FinalDate)
                .OrderByDescending(x => x.Timestamp)
                .ToListAsync();
        }

        public async Task<IEnumerable<Measure>> FindByParameterAsync(string parameter, HistoryFiltersViewModel filter)
        {
            return await _context.Measures
                .AsNoTracking()
                .Where(x => x.Timestamp >= filter.InitialDate && x.Timestamp <= filter.FinalDate && x.Name.Contains(parameter))
                .OrderByDescending(x => x.Timestamp)
                .ToListAsync();
        }
    }
}