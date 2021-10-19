using EvoDcimManager.Shared.Commands;

namespace EvoDcimManager.Domain.ActiveContext.Commands
{
    public class CreateStorageCommand : ICommand
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Manufactor { get; set; }
        public string SerialNumber { get; set; }
        public int InitialPosition { get; set; }
        public int FinalPosition { get; set; }
        public int Capacity { get; set; }
        public string RackLocalization { get; set; }

        public void Validate()
        {

        }
    }
}