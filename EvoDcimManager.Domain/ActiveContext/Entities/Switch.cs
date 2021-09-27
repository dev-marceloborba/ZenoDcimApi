using EvoDcimManager.Domain.ActiveContext.ValueObjects;
using Flunt.Validations;

namespace EvoDcimManager.Domain.ActiveContext.Entities
{
    public class Switch : RackEquipment
    {
        public Switch(BaseEquipment baseEquipment, RackSlot slot, int ethPorts) : base(baseEquipment, slot)
        {
            EthPorts = ethPorts;
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(EthPorts, 0, "EthPorts", "Ethernet ports should be greater then zero")
            );
        }

        public int EthPorts { get; private set; }

    }
}