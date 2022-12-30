using System;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.ZenoContext.Commands.Inputs
{
    public class CreateEquipmentParameterCommand : ICommand
    {
        public Guid EquipmentId { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public double LowLowLimit { get; set; }
        public double LowLimit { get; set; }
        public double HighLimit { get; set; }
        public double HighHighLimit { get; set; }
        public int Scale { get; set; }
        public string DataSource { get; set; }
        public string Address { get; set; }
        public string Expression { get; set; }
        public void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}