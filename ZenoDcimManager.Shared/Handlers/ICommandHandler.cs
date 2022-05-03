using System.Threading.Tasks;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Shared.Handlers
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task<ICommandResult> Handle(T command);
    }
}