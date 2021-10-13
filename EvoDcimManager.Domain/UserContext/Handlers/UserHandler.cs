using EvoDcimManager.Domain.UserContext.Commands;
using EvoDcimManager.Domain.UserContext.Entities;
using EvoDcimManager.Domain.UserContext.Enums;
using EvoDcimManager.Domain.UserContext.Repositories;
using EvoDcimManager.Domain.UserContext.Validators;
using EvoDcimManager.Shared.Commands;
using EvoDcimManager.Shared.Handlers;
using EvoDcimManager.Shared.Services;
using Flunt.Notifications;

namespace EvoDcimManager.Domain.UserContext.Handlers
{
    public class UserHandler : Notifiable, ICommandHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;

        public UserHandler(IUserRepository userRepository, IEmailService emailService)
        {
            _userRepository = userRepository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateUserCommand command)
        {
            // Fail fast validations
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Nao foi possivel criar o usuario", command.Notifications);
            }

            var role = (EUserRole)command.Role;
            var user = new User(command.FirstName, command.LastName, command.Email, command.Password, command.Password, role);

            var userValidator = new UserValidator(user);

            // Grouping notifications
            AddNotifications(userValidator);

            if (Invalid)
                return new CommandResult(false, "Nao foi possivel criar o usuario", "");

            // save informations
            _userRepository.Save(user);

            // send e-mail
            _emailService.Send(user.ToString(), user.Email, "Welcome to EVO DCIM", "Your account was created");

            return new CommandResult(true, "Usuario criado com sucesso", user);

        }
    }
}