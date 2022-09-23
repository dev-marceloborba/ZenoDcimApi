using System;

namespace ZenoDcimManager.Domain.AutomationContext.ViewModels
{
    public class AlarmGroupViewModel
    {
        public Guid Id { get; set; }
        public string Site { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }
        public string Room { get; set; }
        public string Equipment { get; set; }
        public string Parameter { get; set; }
        public string Pathname { get; set; }
    }
}