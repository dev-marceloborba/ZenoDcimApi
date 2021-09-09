using EvoDcimManager.Domain.UserContext.Commands;
using EvoDcimManager.Domain.UserContext.Repositories;
using EvoDcimManager.Shared.Commands;
using EvoDcimManager.Shared.Handlers;

namespace EvoDcimManager.Domain.UserContext.Handlers
{
    public class LoginHandler : ICommandHandler<LoginCommand>
    {
        private readonly IUserRepository _userRepository;

        public LoginHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ICommandResult Handle(LoginCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Error on login", "");

            return new CommandResult(true, "Logado com sucesso", "");
        }
    }
}