using EvoDcimManager.Domain.ActiveContext.Entities;
using EvoDcimManager.Shared;
using Flunt.Validations;

namespace EvoDcimManager.Domain.ActiveContext.ValueObjects
{
    public abstract class RackEquipmentv2 : Entity
    {
        public BaseEquipment BaseEquipment { get; private set; }
        public Rack Rack { get; private set; }

        public RackEquipmentv2()
        {

        }
        public RackEquipmentv2(BaseEquipment baseEquipment)
        {
            BaseEquipment = baseEquipment;
        }

        public void AssociateRack(Rack rack)
        {
            if (rack.Valid)
                Rack = rack;
            else
                AddNotification("Rack", "Rack is invalid");
        }
    }
}