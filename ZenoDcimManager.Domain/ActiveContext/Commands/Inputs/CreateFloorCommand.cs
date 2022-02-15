using System;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.ActiveContext.Commands.Inputs
{
    public class CreateFloorCommand : ICommand
    {
        public Guid BuildingId { get; set; }
        public string Name { get; set; }
        public void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}