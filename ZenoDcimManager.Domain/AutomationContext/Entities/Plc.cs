using System.Collections.Generic;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.AutomationContext.Entities
{
    public class Plc : Entity
    {
        public string Name { get; private set; }
        public string Manufactor { get; private set; }
        public string Model { get; private set; }
        public string IpAddress { get; private set; }
        public int TcpPort { get; private set; }
        public List<ModbusTag> ModbusTags { get; private set; }

        public Plc(string name, string manufactor, string model, string ipAddress, int tcpPort)
        {
            Name = name;
            Manufactor = manufactor;
            Model = model;
            IpAddress = ipAddress;
            TcpPort = tcpPort;
            ModbusTags = new List<ModbusTag>();
        }

        public void ChangeName(string name) => Name = name;
        public void ChangeManufactor(string manufactor) => Manufactor = manufactor;
        public void ChangeModel(string model) => Model = model;
        public void ChangeIpAddress(string ipAddress) => IpAddress = ipAddress;
        public void ChangeTcpPort(int tcpPort) => TcpPort = tcpPort;
        public void AddModbusTag(ModbusTag modbusTag)
        {
            ModbusTags.Add(modbusTag);
        }

        public Plc CopyWith(Plc plc)
        {
            Name = plc.Name;
            Manufactor = plc.Manufactor;
            Model = plc.Model;
            IpAddress = plc.IpAddress;
            TcpPort = plc.TcpPort;
            return this;
        }

    }
}