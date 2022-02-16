using System;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.ActiveContext.Commands.Inputs
{
    public class CreateRoomCommand : ICommand
    {
        public Guid FloorId { get; set; }
        public string Name { get; set; }
        public void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}