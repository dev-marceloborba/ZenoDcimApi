using System;
using System.Collections.Generic;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.ZenoContext.Commands.Inputs
{
    public class CreateMultipleParametersCommand : ICommand
    {
        public IEnumerable<MultipleParametersCommand> Parameters { get; set; }
        public CreateMultipleParametersCommand()
        {
        }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }

    public class MultipleParametersCommand
    {
        public Guid EquipmentId { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public double LowLimit { get; set; }
        public double HighLimit { get; set; }
        public int Scale { get; set; }
        public string DataSource { get; set; }
        public string Address { get; set; }
    }
}

