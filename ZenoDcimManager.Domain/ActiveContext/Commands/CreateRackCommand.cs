using ZenoDcimManager.Shared.Commands;
using System;

namespace ZenoDcimManager.Domain.ZenoContext.Commands
{
    public class CreateRackCommand : ICommand
    {
        public int Size { get; set; }
        public int Weight { get; set; }
        public Guid SiteId { get; set; }
        public Guid BuildingId { get; set; }
        public Guid FloorId { get; set; }
        public Guid RoomId { get; set; }
        public string Localization { get; set; }
        public CreateRackCommand()
        {

        }
        public CreateRackCommand(int size, string localization)
        {
            Size = size;
            Localization = localization;
        }
        public void Validate()
        {

        }
    }
}