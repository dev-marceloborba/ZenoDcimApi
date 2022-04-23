using System;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.ActiveContext.Commands.Inputs
{
    public class CreateBuildingCommand : ICommand
    {
        public string Campus { get; set; }
        public string Name { get; set; }
        public Guid SiteId { get; set; }

        public void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}