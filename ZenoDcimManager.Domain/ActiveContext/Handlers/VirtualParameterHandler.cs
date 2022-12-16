using System;
using System.Threading.Tasks;
using Flunt.Notifications;
using ZenoDcimManager.Domain.ActiveContext.Commands.Inputs;
using ZenoDcimManager.Domain.ActiveContext.Repositories;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Shared.Commands;
using ZenoDcimManager.Shared.Handlers;

namespace ZenoDcimManager.Domain.ActiveContext.Handlers
{
    public class VirtualParameterHandler : Notifiable, ICommandHandler<CreateVirtualParameterCommand>
    {
        private readonly IVirtualParameterRepository _repository;

        public VirtualParameterHandler(IVirtualParameterRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(CreateVirtualParameterCommand command)
        {
            var virtualParameter = new VirtualParameter
            {
                Name = command.Name,
                Unit = command.Unit,
                LowLowLimit = command.LowLowLimit,
                LowLimit = command.LowLimit,
                HighLimit = command.HighLimit,
                HighHighLimit = command.HighHighLimit,
                Scale = command.Scale,
                Expression = command.Expression
            };

            await _repository.CreateAsync(virtualParameter);
            await _repository.Commit();

            return new CommandResult(true, "Parametro virtual criado com sucesso", virtualParameter);
        }
    }
}

