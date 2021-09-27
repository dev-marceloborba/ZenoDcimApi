using EvoDcimManager.Domain.ActiveContext.Entities;
using EvoDcimManager.Shared.Entities;
using Flunt.Validations;

namespace EvoDcimManager.Domain.ActiveContext.ValueObjects
{
    public abstract class RackEquipment : ValueObject
    {
        public RackEquipment(BaseEquipment baseEquipment, RackSlot slot)
        {
            BaseEquipment = baseEquipment;
            Slot = slot;

            AddNotifications(new Contract()
                .Requires()
            // .IsTrue(ValidateSlotOccupation(), "Slot", "Slot occupation cannot be greater than rack size")

            );
        }

        public BaseEquipment BaseEquipment { get; private set; }
        public RackSlot Slot { get; private set; }
        public Rack Rack { get; private set; }

        public void AssociateRack(Rack rack)
        {
            if (rack.Valid)
                Rack = rack;
            else
                AddNotification("Rack", "Rack is invalid");
        }

        private bool ValidateSlotOccupation()
        {
            return (Slot.Occupation > Rack.Size);
        }
    }
}