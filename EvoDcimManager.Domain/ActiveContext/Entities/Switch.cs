using EvoDcimManager.Domain.ActiveContext.ValueObjects;
using Flunt.Validations;

namespace EvoDcimManager.Domain.ActiveContext.Entities
{
    public class Switch : RackEquipment
    {
        public Switch()
        {

        }
        public Switch(BaseEquipment baseEquipment, int ethPorts) : base(baseEquipment)
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