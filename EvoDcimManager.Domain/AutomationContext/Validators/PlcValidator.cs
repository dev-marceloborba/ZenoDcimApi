using EvoDcimManager.Domain.AutomationContext.Entities;
using Flunt.Notifications;
using Flunt.Validations;

namespace EvoDcimManager.Domain.AutomationContext.Validators
{
    public class PlcValidator : Notifiable
    {
        public PlcValidator(Plc plc)
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(plc.Name, 4, "Name", "Name should have at last 4 charateres")
            );
        }
    }
}