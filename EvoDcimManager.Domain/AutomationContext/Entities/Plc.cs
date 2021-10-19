using EvoDcimManager.Shared;

namespace EvoDcimManager.Domain.AutomationContext.Entities
{
    public class Plc : Entity
    {
        public string Name { get; private set; }
        public string Manufactor { get; private set; }
        public string Model { get; private set; }
        public string IpAddress { get; private set; }
        public string NetworkMask { get; private set; }
        public string Gateway { get; private set; }

        public Plc(string name, string manufactor, string model, string ipAddress, string networkMask, string gateway)
        {
            Name = name;
            Manufactor = manufactor;
            Model = model;
            IpAddress = ipAddress;
            NetworkMask = networkMask;
            Gateway = gateway;
        }

        public void ChangeName(string name) => Name = name;
        public void ChangeManufactor(string manufactor) => Manufactor = manufactor;
        public void ChangeModel(string model) => Model = model;
        public void ChangeIpAddress(string ipAddress) => IpAddress = ipAddress;
        public void ChangeNetworkMask(string networkMask) => NetworkMask = networkMask;
        public void ChangeGateway(string gateway) => Gateway = gateway;

    }
}