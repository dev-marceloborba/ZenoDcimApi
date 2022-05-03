using ZenoDcimManager.Domain.ServiceOrderContext.Commands;
using ZenoDcimManager.Shared.Commands;
using ZenoDcimManager.Shared.Handlers;
using Flunt.Notifications;
using System.Threading.Tasks;

namespace ZenoDcimManager.Domain.ServiceOrderContext.Handlers
{
    public class OrderHandler : Notifiable, ICommandHandler<OrderCommand>
    {
        public async Task<ICommandResult> Handle(OrderCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}