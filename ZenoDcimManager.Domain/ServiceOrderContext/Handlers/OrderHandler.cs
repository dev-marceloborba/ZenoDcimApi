using ZenoDcimManager.Domain.ServiceOrderContext.Commands;
using ZenoDcimManager.Shared.Commands;
using ZenoDcimManager.Shared.Handlers;
using Flunt.Notifications;

namespace ZenoDcimManager.Domain.ServiceOrderContext.Handlers
{
    public class OrderHandler : Notifiable, ICommandHandler<OrderCommand>
    {
        public ICommandResult Handle(OrderCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}