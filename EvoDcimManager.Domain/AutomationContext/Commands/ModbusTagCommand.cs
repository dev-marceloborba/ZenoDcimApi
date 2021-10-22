using EvoDcimManager.Shared.Commands;

namespace EvoDcimManager.Domain.AutomationContext.Commands
{
    public class ModbusTagCommand : ICommand
    {
        public string Name { get; set; }
        public int Address { get; set; }
        public int Size { get; set; }
        public double Deadband { get; set; }
        public void Validate()
        {

        }
    }
}