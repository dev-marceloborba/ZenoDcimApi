using System.Collections.Generic;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.AutomationContext.Commands
{
    public class CreateMultipleModbusTagCommand : ICommand
    {
        public string ModbusDevice { get; set; }
        public List<CreateModbusTagCommand> ModbusTags { get; set; }

        public void Validate()
        {

        }
    }
}