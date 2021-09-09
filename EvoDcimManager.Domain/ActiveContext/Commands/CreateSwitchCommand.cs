using EvoDcimManager.Shared.Commands;

namespace EvoDcimManager.Domain.ActiveContext.Commands
{
    public class CreateSwitchCommand : ICommand
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Manufactor { get; set; }
        public string SerialNumber { get; set; }
        public int Occupation { get; set; }
        public int RackPosition { get; set; }
        public int EthPorts { get; set; }

        public void Validate()
        {

        }
    }
}