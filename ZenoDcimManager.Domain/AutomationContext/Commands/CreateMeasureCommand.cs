using System;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.AutomationContext.Commands
{
    public class CreateMeasureCommand : ICommand
    {
        public string Pathname { get; set; }
        public double Value { get; set; }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}

