using ZenoDcimManager.Shared.Commands;
using System;

namespace ZenoDcimManager.Domain.ZenoContext.Commands
{
    public class CreateRackCommand : ICommand
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public int Capacity { get; set; }
        public double Power { get; set; }
        public double Weight { get; set; }
        public string Description { get; set; }
        public Guid SiteId { get; set; }
        public Guid BuildingId { get; set; }
        public Guid FloorId { get; set; }
        public Guid RoomId { get; set; }
        public string Localization { get; set; }
        public CreateRackCommand()
        {

        }
        public CreateRackCommand(string size, string localization)
        {
            Size = size;
            Localization = localization;
        }
        public void Validate()
        {

        }
    }
}