using System;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.AutomationContext.Commands
{
    public class DeleteModbusTagCommand : ICommand
    {
        public Guid Id { get; set; }

        public void Validate()
        {

        }
    }
}