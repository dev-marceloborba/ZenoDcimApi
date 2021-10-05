using System;
using EvoDcimManager.Shared.Commands;

namespace EvoDcimManager.Domain.ActiveContext.Commands
{
    public class CreateServerCommand : ICommand
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Manufactor { get; set; }
        public string SerialNumber { get; set; }
        public int InitialPosition { get; set; }
        public int FinalPosition { get; set; }
        public string Cpu { get; set; }
        public int Memory { get; set; }
        public int Storage { get; set; }
        public Guid RackId { get; set; }
        public void Validate()
        {

        }
    }
}