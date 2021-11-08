using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.ActiveContext.Commands
{
    public class CreateRackCommand : ICommand
    {
        public int Size { get; set; }
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