using ZenoDcimManager.Domain.AutomationContext.Entities;
using Flunt.Notifications;
using Flunt.Validations;

namespace ZenoDcimManager.Domain.AutomationContext.Validators
{
    public class AlarmValidator : Notifiable
    {
        public AlarmValidator(Alarm alarm)
        {
            AddNotifications(new Contract()
                .Requires()
            );
        }
    }
}