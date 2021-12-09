using System;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.UserContext.Entities
{
    public class Contract : Entity
    {
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public double PowerConsumptionDailyLimit { get; private set; }
        public Contract(DateTime startDate, DateTime endDate, double powerConsumptionDailyLimit)
        {
            StartDate = startDate;
            EndDate = endDate;
            PowerConsumptionDailyLimit = powerConsumptionDailyLimit;
        }

        public bool IsContractEnding()
        {
            return (EndDate - StartDate).TotalDays > 30;
        }

        public bool DailyPowerConsumptionExceeded(double dailyPowerConsumption)
        {
            return (dailyPowerConsumption > PowerConsumptionDailyLimit);
        }
    }
}