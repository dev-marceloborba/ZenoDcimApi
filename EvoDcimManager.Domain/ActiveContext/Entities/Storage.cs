using EvoDcimManager.Domain.ActiveContext.ValueObjects;

namespace EvoDcimManager.Domain.ActiveContext.Entities
{
    public class Storage : RackEquipment
    {
        public Storage()
        {

        }
        public Storage(BaseEquipment baseEquipment, int initialPosition, int finalPosition, int capacity) : base(baseEquipment, initialPosition, finalPosition)
        {
            Capacity = capacity;
        }

        public int Capacity { get; private set; }

    }
}