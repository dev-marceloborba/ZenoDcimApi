using System;

namespace ZenoDcimManager.Domain.AutomationContext.ViewModels
{
    public class AlarmRecognitionIntervalViewModel
    {
        public Guid Id { get; set; }
        public DateTime InDate { get; set; }
        public DateTime OutDate { get; set; }
        public TimeSpan Interval { get; set; }
    }
}