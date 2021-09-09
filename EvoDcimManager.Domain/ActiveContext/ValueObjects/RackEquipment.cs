using EvoDcimManager.Domain.ActiveContext.Entities;
using EvoDcimManager.Shared.Entities;

namespace EvoDcimManager.Domain.ActiveContext.ValueObjects
{
    public abstract class RackEquipment : ValueObject
    {
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

        public void PlaceEquipment()
        {

        }
    }
}