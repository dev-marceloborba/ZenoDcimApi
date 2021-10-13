using EvoDcimManager.Domain.ActiveContext.ValueObjects;

namespace EvoDcimManager.Domain.ActiveContext.Entities
{
    public class Server : RackEquipment
    {
        public Server()
        {

        }

        public Server(BaseEquipment baseEquipment, string cpu, int memory, int storage) : base(baseEquipment)
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