using EvoDcimManager.Domain.ActiveContext.ValueObjects;

namespace EvoDcimManager.Domain.ActiveContext.Entities
{
    public class Storage : RackEquipment
    {
        public Storage()
        {

        }
        public Storage(BaseEquipment baseEquipment, int capacity) : base(baseEquipment)
        {
            Capacity = capacity;
        }

        public int Capacity { get; private set; }

    }
}