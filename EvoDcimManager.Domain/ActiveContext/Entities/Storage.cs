using EvoDcimManager.Domain.ActiveContext.ValueObjects;

namespace EvoDcimManager.Domain.ActiveContext.Entities
{
    public class Storage : Equipment
    {
        public Storage(BaseEquipment baseEquipment, Capacity occupation, Capacity capacity) : base(baseEquipment, occupation)
        {
            Capacity = capacity;
        }

        public Capacity Capacity { get; private set; }

    }
}