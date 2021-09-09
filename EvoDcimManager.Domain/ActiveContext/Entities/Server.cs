using EvoDcimManager.Domain.ActiveContext.ValueObjects;

namespace EvoDcimManager.Domain.ActiveContext.Entities
{
    public class Server : Equipment
    {
        public Server(BaseEquipment baseEquipment, Capacity occupation, Cpu cpu, Memory memory, Capacity storage) : base(baseEquipment, occupation)
        {
            Cpu = cpu;
            Memory = memory;
            Storage = storage;
        }

        public Cpu Cpu { get; private set; }
        public Memory Memory { get; private set; }
        public Capacity Storage { get; private set; }

    }
}