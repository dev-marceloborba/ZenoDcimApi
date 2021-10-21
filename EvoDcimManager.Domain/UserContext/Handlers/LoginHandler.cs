using EvoDcimManager.Domain.UserContext.Commands;
using EvoDcimManager.Domain.UserContext.Repositories;
using EvoDcimManager.Domain.UserContext.Services;
using EvoDcimManager.Domain.UserContext.Validators;
using EvoDcimManager.Shared.Commands;
using EvoDcimManager.Shared.Handlers;
using Flunt.Notifications;

namespace EvoDcimManager.Domain.UserContext.Handlers
{
    public class LoginHandler : Notifiable, ICommandHandler<LoginCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptoService _cryptoService;

        public LoginHandler(IUserRepository userRepository, ICryptoService cryptoService)
        {
            _userRepository = userRepository;
            _cryptoService = cryptoService;
        }

        public ICommandResult Handle(LoginCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Error on login", command.Notifications);

            var user = _userRepository.FindUserByEmail(command.Email);
            var hashedPassword = _cryptoService.EncryptPassword(command.Password);

            var loginValidator = new LoginValidator(user.HashedPassword, hashedPassword);
            AddNotifications(loginValidator);

            if (Invalid)
                return new CommandResult(false, "Error on login", command.Notifications);


            return new CommandResult(true, "Logado com sucesso", "");
        }
    }
}