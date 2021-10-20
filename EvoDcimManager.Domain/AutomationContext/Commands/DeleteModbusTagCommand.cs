using System;
using EvoDcimManager.Shared.Commands;

namespace EvoDcimManager.Domain.AutomationContext.Commands
{
    public class DeleteModbusTagCommand : ICommand
    {
        public Guid Id { get; set; }

        public void Validate()
        {

        }
    }
}