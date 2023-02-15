using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Domain.AutomationContext.Repositories;
using ZenoDcimManager.Domain.AutomationContext.ViewModels;

namespace ZenoDcimManager.Api.Pages.Reports
{
    public class HistoryModel : PageModel
    {
        private readonly IMeasureRepository _repository;

        public HistoryModel(IMeasureRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Measure> Measures { get; set; }

        public async Task OnGetAsync()
        {
            var filters = new HistoryFiltersViewModel();
            filters.InitialDate = DateTime.Parse("2023-01-01");
            filters.FinalDate = DateTime.Parse("2023-02-01");
            Measures = await _repository.FindAllAsync(filters);
            // Measures = (List<Measure>)await _repository.FindAllAsync(filters);
        }
    }
}