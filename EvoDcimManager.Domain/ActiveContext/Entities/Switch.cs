using EvoDcimManager.Domain.ActiveContext.ValueObjects;
using Flunt.Validations;

namespace EvoDcimManager.Domain.ActiveContext.Entities
{
    public class Switch : RackEquipment
    {
        public Switch()
        {

        }
        public Switch(BaseEquipment baseEquipment, int initialPosition, int finalPosition, int ethPorts) : base(baseEquipment, initialPosition, finalPosition)
        {
            EthPorts = ethPorts;
            // AddNotifications(new Contract()
            //     .Requires()
            //     .IsGreaterThan(EthPorts, 0, "EthPorts", "Ethernet ports should be greater then zero")
            // );
        }

        public int EthPorts { get; private set; }

    }
}