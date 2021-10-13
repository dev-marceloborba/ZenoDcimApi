using EvoDcimManager.Domain.ActiveContext.Entities;
using Flunt.Notifications;
using Flunt.Validations;

namespace EvoDcimManager.Domain.ActiveContext.Validators
{
    public class BaseEquipmentValidator : Notifiable
    {
        public BaseEquipmentValidator(BaseEquipment baseEquipment)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(baseEquipment.Name, "Name", "Name is required")
                .IsNotNullOrEmpty(baseEquipment.Model, "Model", "Model is required")
                .IsNotNullOrEmpty(baseEquipment.Manufactor, "Manufactor", "Manufactor is required")
                .IsNotNullOrEmpty(baseEquipment.SerialNumber, "SerialNumber", "SerialNumber is required")
            );
        }
    }
}