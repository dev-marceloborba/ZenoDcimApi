using System.Collections.Generic;
using System.Threading.Tasks;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Domain.AutomationContext.ViewModels;
using ZenoDcimManager.Shared.UnitOfWork;

namespace ZenoDcimManager.Domain.AutomationContext.Repositories
{
    public interface IMeasureRepository : IUnitOfWork
    {
        Task CreateAsync(Measure measure);
        Task CreateMultipleAsync(IEnumerable<Measure> measures);
        Task<IEnumerable<Measure>> FindAllAsync(HistoryFiltersViewModel filters);
        Task<IEnumerable<Measure>> FindByParameterAsync(string parameter, HistoryFiltersViewModel filters);
        Task<MeasureStatistics> GetMeasureStatistics(CreateMeasureViewModel filters);
    }
}