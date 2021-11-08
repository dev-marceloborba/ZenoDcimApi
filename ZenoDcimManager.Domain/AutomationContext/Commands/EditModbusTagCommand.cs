using System;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.AutomationContext.Commands
{
    public class EditModbusTagCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Address { get; set; }
        public int Size { get; set; }
        public void Validate()
        {

        }
    }
}