using ZenoDcimManager.Domain.ZenoContext.Entities;
using Flunt.Notifications;
using Flunt.Validations;

namespace ZenoDcimManager.Domain.ZenoContext.Validators
{
    public class RackEquipmentValidator : Notifiable
    {
        public RackEquipmentValidator(RackEquipment rackEquipment)
        {
            AddNotifications(new Contract()
                .Requires()
                // .IsTrue(rackEquipment.FinalPosition <= 0, "FinalPosition", "Final position should be greater than zero")
                .IsGreaterThan(rackEquipment.InitialPosition, 0, "InitialPosition", "Initial position should be greater than 0")
                .IsGreaterThan(rackEquipment.FinalPosition, 0, "FinalPosition", "Final position should be greater than 0")
                .AreNotEquals(rackEquipment.InitialPosition, rackEquipment.FinalPosition, "Position", "Initial and final positions should be different")
            );
        }
    }
}