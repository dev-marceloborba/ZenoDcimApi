using System;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.ZenoContext.Commands.Inputs
{
    public class CreateRoomCommand : ICommand
    {
        public Guid FloorId { get; set; }
        public Guid? BuildingId { get; set; } = new Guid();
        public string Name { get; set; }
        public void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}