using ZenoDcimManager.Domain.UserContext.ValueObjects;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.UserContext.Commands.Input
{
    public class CreateGroupCommand : ICommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ActionPermissions Actions { get; set; }
        public RegisterPermissions Registers { get; set; }
        public ViewPermissions Views { get; set; }

        public void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}