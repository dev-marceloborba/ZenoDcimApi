using EvoDcimManager.Domain.ActiveContext.ValueObjects;

namespace EvoDcimManager.Domain.ActiveContext.Entities
{
    public class Switch : Equipment
    {
        public Switch(BaseEquipment baseEquipment, Capacity occupation, int ethPorts) : base(baseEquipment, occupation)
        {
            EthPorts = ethPorts;
        }

        public int EthPorts { get; private set; }

    }
}