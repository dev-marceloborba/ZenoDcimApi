using System;

namespace ZenoDcimManager.Domain.AutomationContext.ViewModels
{
    public class CreateMeasureViewModel
    {
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public string Name { get; set; }
    }
}