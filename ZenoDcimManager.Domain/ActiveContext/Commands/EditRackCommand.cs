using System;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.ZenoContext.Commands
{
    public class EditRackCommand : ICommand
    {
        public Guid Id { get; set; }
        public int Size { get; set; }
        public string Localization { get; set; }
        public void Validate()
        {

        }
    }
}