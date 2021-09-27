using EvoDcimManager.Domain.ActiveContext.ValueObjects;

namespace EvoDcimManager.Domain.ActiveContext.Entities
{
    public class Storage : RackEquipment
    {
        public Storage(BaseEquipment baseEquipment, RackSlot slot, Capacity capacity) : base(baseEquipment, slot)
        {
            Capacity = capacity;
        }

        public Capacity Capacity { get; private set; }

    }
}