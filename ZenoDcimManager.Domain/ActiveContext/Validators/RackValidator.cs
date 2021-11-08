using System.Linq;
using ZenoDcimManager.Domain.ActiveContext.Entities;
using Flunt.Notifications;
using Flunt.Validations;

namespace ZenoDcimManager.Domain.ActiveContext.Validators
{
    public class RackValidator : Notifiable
    {
        public Rack Rack { get; private set; }
        public RackValidator(Rack rack)
        {
            Rack = rack;
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(rack.Localization, "Localization", "Localization is required")
                .IsGreaterThan(rack.Size, 0, "Size", "Size must be greater than 0")
            );
        }

        public void ValidateRackSize()
        {
            foreach (var item in Rack.RackEquipments)
            {
                if (item.InitialPosition > Rack.Size)
                {
                    AddNotification("Size", "Rack initial position is greater than rack size");
                    break;
                }
            }
        }

        public void ValidatePosition()
        {
            var query = Rack.RackEquipments.GroupBy(x => x.InitialPosition)
              .Where(g => g.Count() > 1)
              .Select(y => y.Key)
              .ToList();

            if (query.Count() > 0)
                AddNotification("Slots", "The specified position is already occuped");
        }
    }
}