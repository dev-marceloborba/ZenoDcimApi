namespace ZenoDcimManager.Domain.AutomationContext.ViewModels
{
    public class AlarmStatisticsViewModel
    {
        public double AverageAckTime { get; set; } = 0;
        public double MaxAckTime { get; set; } = 0;
        public double MinAckTime { get; set; } = 0;
        public int AlarmsNotAcked { get; set; } = 0;
    }
}