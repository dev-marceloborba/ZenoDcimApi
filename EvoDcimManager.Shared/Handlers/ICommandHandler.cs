using EvoDcimManager.Shared.Commands;

namespace EvoDcimManager.Shared.Handlers
{
    public interface ICommandHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}