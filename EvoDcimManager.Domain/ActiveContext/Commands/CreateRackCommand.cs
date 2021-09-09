using EvoDcimManager.Shared.Commands;

namespace EvoDcimManager.Domain.ActiveContext.Commands
{
    public class CreateRackCommand : ICommand
    {
        public CreateRackCommand()
        {

        }
        public CreateRackCommand(int size, string localization)
        {
            Size = size;
            Localization = localization;
        }

        public int Size { get; set; }
        public string Localization { get; set; }

        public void Validate()
        {

        }
    }
}