using EvoDcimManager.Domain.ServiceOrderContext.Commands;
using EvoDcimManager.Shared.Commands;
using EvoDcimManager.Shared.Handlers;
using Flunt.Notifications;

namespace EvoDcimManager.Domain.ServiceOrderContext.Handlers
{
    public class OrderHandler : Notifiable, ICommandHandler<OrderCommand>
    {
        public ICommandResult Handle(OrderCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}