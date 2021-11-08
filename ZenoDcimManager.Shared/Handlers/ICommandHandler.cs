using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Shared.Handlers
{
    public interface ICommandHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}