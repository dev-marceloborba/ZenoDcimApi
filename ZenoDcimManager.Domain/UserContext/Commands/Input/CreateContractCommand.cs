using System;
using Flunt.Notifications;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.UserContext.Commands.Input
{
    public class CreateContractCommand : Notifiable, ICommand
    {
        public Guid CompanyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double PowerConsumptionDailyLimit { get; set; }
        public int IntervalEndingNotification { get; set; } = 30;

        public void Validate()
        {

        }
    }
}