using System;
using ZenoDcimManager.Domain.UserContext.Commands;
using ZenoDcimManager.Domain.UserContext.Repositories;
using ZenoDcimManager.Domain.UserContext.Services;
using ZenoDcimManager.Domain.UserContext.Validators;
using ZenoDcimManager.Shared.Commands;
using ZenoDcimManager.Shared.Handlers;
using Flunt.Notifications;

namespace ZenoDcimManager.Domain.UserContext.Handlers
{
    public class LoginHandler : Notifiable, ICommandHandler<LoginCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptoService _cryptoService;
        private readonly ITokenService _tokenService;

        public LoginHandler(IUserRepository userRepository, ICryptoService cryptoService, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _cryptoService = cryptoService;
            _tokenService = tokenService;
        }

        public ICommandResult Handle(LoginCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Error on login", command.Notifications);

            var user = _userRepository.FindUserByEmail(command.Email);

            if (user == null)
            {
                AddNotification("E-mail", "E-mail doesn't exists");
                return new CommandResult(false, "Error on login", Notifications);
            }

            var isAuthenticated = _cryptoService.ValidatePassword(command.Password, user.HashedPassword);

            if (isAuthenticated)
            {
                AddNotification("Password", "Invalid password");
                return new CommandResult(false, "Error on login", Notifications);
            }

            var token = _tokenService.GenerateToken(user);

            return new CommandResult(true, "Logado com sucesso", new { token = token });
        }
    }
}