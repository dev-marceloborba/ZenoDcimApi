using EvoDcimManager.Domain.ActiveContext.Entities;
using Flunt.Notifications;
using Flunt.Validations;

namespace EvoDcimManager.Domain.ActiveContext.Validators
{
    public class StorageValidator : Notifiable
    {
        public StorageValidator(Storage storage)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(storage.Capacity, 0, "Capacity", "Capacity should be greater than zero")
            );
        }
    }
}