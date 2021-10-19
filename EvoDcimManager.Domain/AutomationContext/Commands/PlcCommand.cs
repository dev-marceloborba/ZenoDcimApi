using EvoDcimManager.Shared.Commands;

namespace EvoDcimManager.Domain.AutomationContext.Commands
{
    public class PlcCommand : ICommand
    {
        public string Name { get; set; }
        public string Manufactor { get; set; }
        public string Model { get; set; }
        public string IpAddress { get; set; }
        public string NetworkMask { get; set; }
        public string Gateway { get; set; }

        public void Validate()
        {

        }
    }
}