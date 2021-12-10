using System;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.UserContext.Entities
{
    public class Contract : Entity
    {
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public double PowerConsumptionDailyLimit { get; private set; }
        public int IntervalEndingNotification { get; private set; } = 30;
        public Contract(DateTime startDate, DateTime endDate, double powerConsumptionDailyLimit)
        {
            StartDate = startDate;
            EndDate = endDate;
            PowerConsumptionDailyLimit = powerConsumptionDailyLimit;
        }

        public bool IsContractEnding()
        {
            return IntervalEndingNotification > DaysLeft();
        }

        public bool DailyPowerConsumptionExceeded(double dailyPowerConsumption)
        {
            return (dailyPowerConsumption > PowerConsumptionDailyLimit);
        }

        public double TotalDays()
        {
            return (EndDate - StartDate).TotalDays;
        }

        public double DaysLeft()
        {
            return (EndDate - DateTime.Now).TotalDays;
        }

        public void ChangeIntervalEndingNofification(int intervalEndingNotification)
        {
            IntervalEndingNotification = intervalEndingNotification;
        }
    }
}