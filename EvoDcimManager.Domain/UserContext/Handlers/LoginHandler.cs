using System;
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