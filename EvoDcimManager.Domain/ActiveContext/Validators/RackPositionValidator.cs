using EvoDcimManager.Domain.ActiveContext.Entities;
using Flunt.Notifications;
using Flunt.Validations;

namespace EvoDcimManager.Domain.ActiveContext.Validators
{
    public class RackPositionValidator : Notifiable
    {
        public RackPositionValidator(RackPosition rackPosition)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsTrue(rackPosition.FinalPosition >= rackPosition.InitialPosition, "InitialPosition", "Initial position should be equal or lower than final position")
            );
        }
    }
}