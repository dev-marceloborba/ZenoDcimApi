using ZenoDcimManager.Domain.AutomationContext.Entities;
using Flunt.Notifications;
using Flunt.Validations;

namespace ZenoDcimManager.Domain.AutomationContext.Validators
{
    public class ModbusTagValidator : Notifiable
    {
        public ModbusTagValidator(ModbusTag modbusTag)
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(modbusTag.Name, 4, "Name", "Name should have at last 4 charateres")
            );
        }
    }
}