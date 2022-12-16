using System;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.ActiveContext.Commands.Inputs
{
    public class CreateVirtualParameterCommand : ICommand
    {
        public string Name { get; set; }
        public string Unit { get; set; }
        public int LowLowLimit { get; set; }
        public int LowLimit { get; set; }
        public int HighLimit { get; set; }
        public int HighHighLimit { get; set; }
        public int Scale { get; set; }
        public string Expression { get; set; }

        public CreateVirtualParameterCommand()
        {

        }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}

