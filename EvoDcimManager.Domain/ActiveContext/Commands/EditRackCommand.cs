using System;
using EvoDcimManager.Shared.Commands;

namespace EvoDcimManager.Domain.ActiveContext.Commands
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