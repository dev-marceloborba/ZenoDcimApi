using EvoDcimManager.Domain.ActiveContext.Enums;
using EvoDcimManager.Shared.Commands;

namespace EvoDcimManager.Domain.ActiveContext.Commands
{
    public class CreateRackEquipmentCommand : ICommand
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Manufactor { get; set; }
        public string SerialNumber { get; set; }
        public int InitialPosition { get; set; }
        public int FinalPosition { get; set; }
        public ERackEquipmentType RackEquipmentType { get; set; }
        public string RackLocalization { get; set; }
        public void Validate()
        {

        }
    }
}