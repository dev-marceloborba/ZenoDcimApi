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

        public async Task<MeasureStatistics> GetMeasureStatistics(CreateMeasureViewModel filters)
        {
            // var query = from p in _context.Measures
            //     group p by p.Id
            //     into g
            //     select new { g.Key, Count = g.Count() };

            // var result = _context.Measures
            //     .Where(x => x.Timestamp >= filters.InitialDate && x.Timestamp <= filters.FinalDate )
            //     .Average(x => x.Value)

            // var result = await _context.Measures
            //     .FromSqlRaw(@"
            //         SELECT MAX(M.[Value]) as [Maximum], 
            //         MIN(M.[Value]) as [Minimum], 
            //         AVG(M.[Value]) as [Average]
            //         FROM [dbo].[Measure] M 
            //         WHERE M.Name=@name 
            //             AND m.Timestamp >= @initialDate 
            //             AND m.Timestamp <= @finalDate", name, filters.InitialDate, filters.FinalDate)
            //     .ToListAsync();

            return await _context.Measures
               .Where(x => x.Timestamp >= filters.InitialDate && x.Timestamp <= filters.FinalDate && x.Name == filters.Name)
               .GroupBy(_ => 1, (_, records) => new MeasureStatistics
               {
                   Maximum = records.Max(r => r.Value),
                   Minimum = records.Min(r => r.Value),
                   Average = records.Average(r => r.Value)
               })
               .FirstOrDefaultAsync();

            // return await _context.Measures
            //     .GroupBy(x => new {})
            //     .Select(group => new MeasureStatistics {
            //         Average = group.Average(),
            //         Minimum = group.Min(),
            //         Maximum = group.Max()
            //     })
            //     .ToListAsync();
        }
    }
}