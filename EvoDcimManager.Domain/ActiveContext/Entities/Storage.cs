using EvoDcimManager.Domain.ActiveContext.ValueObjects;

namespace EvoDcimManager.Domain.ActiveContext.Entities
{
    public class Storage : RackEquipment
    {
        public Storage()
        {

        }
        public Storage(BaseEquipment baseEquipment, Capacity capacity) : base(baseEquipment)
        {
            Capacity = capacity;
        }

        public Capacity Capacity { get; private set; }

    }
}