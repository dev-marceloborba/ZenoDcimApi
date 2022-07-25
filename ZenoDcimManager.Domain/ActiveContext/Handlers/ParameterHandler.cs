using System.Threading.Tasks;
using Flunt.Notifications;
using ZenoDcimManager.Domain.ZenoContext.Commands.Inputs;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Domain.ZenoContext.Repositories;
using ZenoDcimManager.Shared.Commands;
using ZenoDcimManager.Shared.Handlers;

namespace ZenoDcimManager.Domain.ZenoContext.Handlers
{
    public class ParameterHandler : Notifiable,
        ICommandHandler<CreateParameterCommand>
    {
        private readonly IParameterRepository _parameterRepository;

        public ParameterHandler(IParameterRepository parameterRepository)
        {
            _parameterRepository = parameterRepository;
        }

        public async Task<ICommandResult> Handle(CreateParameterCommand command)
        {
            var parameter = new Parameter
            {
                Name = command.Name,
                Unit = command.Unit,
                LowLimit = command.LowLimit,
                HighLimit = command.HighLimit,
                Scale = command.Scale
            };

            await _parameterRepository.CreateAsync(parameter);
            await _parameterRepository.Commit();

            return new CommandResult(true, "Parâmetro criado com sucesso", parameter);
        }
    }
}