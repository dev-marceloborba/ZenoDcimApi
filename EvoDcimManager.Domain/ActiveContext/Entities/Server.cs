using EvoDcimManager.Domain.ActiveContext.ValueObjects;

namespace EvoDcimManager.Domain.ActiveContext.Entities
{
    public class Server : RackEquipment
    {
        public Server()
        {

        }

        public Server(BaseEquipment baseEquipment, Cpu cpu, Memory memory, Capacity storage) : base(baseEquipment)
        {
            Cpu = cpu;
            Memory = memory;
            Storage = storage;
            AddNotifications(baseEquipment.Notifications);
        }
        public Cpu Cpu { get; private set; }
        public Memory Memory { get; private set; }
        public Capacity Storage { get; private set; }
    }
}