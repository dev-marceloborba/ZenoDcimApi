using EvoDcimManager.Shared;

namespace EvoDcimManager.Domain.ActiveContext.Entities
{
    public class RackEquipment : Entity
    {
        public BaseEquipment BaseEquipment { get; private set; }
        public Rack Rack { get; private set; }

        public RackEquipment()
        {

        }
        public RackEquipment(BaseEquipment baseEquipment)
        {
            BaseEquipment = baseEquipment;
        }

        public void AssociateRack(Rack rack)
        {
            Rack = rack;
        }
    }
}