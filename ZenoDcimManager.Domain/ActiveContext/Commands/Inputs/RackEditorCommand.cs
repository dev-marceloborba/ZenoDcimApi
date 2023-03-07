using System;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.ActiveContext.Commands.Inputs
{
    public class RackEditorCommand : ICommand
    {
        public Guid? Id { get; set; }
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
        public void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}