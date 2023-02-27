using System;

namespace ZenoDcimManager.Domain.AutomationContext.Commands
{
    public class MeasureHistoryOutput
    {
        public string Site { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }
        public string Room { get; set; }
        public string Equipment { get; set; }
        public string Parameter { get; set; }
        public double Value { get; set; }
        public DateTime Timestamp { get; set; }
    }
}