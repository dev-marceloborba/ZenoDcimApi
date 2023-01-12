using System;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.ZenoContext.Commands
{
    public class EditRackCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public int Capacity { get; set; }
        public double Power { get; set; }
        public double Weight { get; set; }
        public string Description { get; set; }
        public string Localization { get; set; }
        public void Validate()
        {

        }
    }
}