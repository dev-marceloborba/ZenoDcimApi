using EvoDcimManager.Domain.ActiveContext.ValueObjects;

namespace EvoDcimManager.Domain.ActiveContext.Entities
{
    public class Server : RackEquipment
    {
        public Server()
        {

        }

        public Server(BaseEquipment baseEquipment, int initialPosition, int finalPosition, string cpu, int memory, int storage) : base(baseEquipment, initialPosition, finalPosition)
        {
            Cpu = cpu;
            Memory = memory;
            Storage = storage;
        }
        public string Cpu { get; private set; }
        public int Memory { get; private set; }
        public int Storage { get; private set; }
    }
}