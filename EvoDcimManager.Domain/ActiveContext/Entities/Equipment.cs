using EvoDcimManager.Domain.ActiveContext.ValueObjects;
using EvoDcimManager.Shared;

namespace EvoDcimManager.Domain.ActiveContext.Entities
{
    public abstract class Equipment : Entity
    {
        public Equipment(BaseEquipment baseEquipment, Capacity occupation)
        {
            BaseEquipment = baseEquipment;
            Occupation = occupation;

            AddNotifications(baseEquipment.Notifications);
        }

        public BaseEquipment BaseEquipment { get; private set; }
        public int RackPosition { get; private set; }
        public Capacity Occupation { get; private set; }
        public Rack Rack { get; private set; }



        public void AssociateRack(Rack rack)
        {
            if (rack.Valid)
                Rack = rack;
            else
                AddNotification("Rack", "Rack is invalid");
        }
    }
}