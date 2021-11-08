using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.AutomationContext.Commands
{
    public class CreatePlcCommand : ICommand
    {
        public string Name { get; set; }
        public string Manufactor { get; set; }
        public string Model { get; set; }
        public string IpAddress { get; set; }
        public string NetworkMask { get; set; }
        public string Gateway { get; set; }
        public int TcpPort { get; set; }
        public int Scan { get; set; }

        public void Validate()
        {

        }
    }
}