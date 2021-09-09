using EvoDcimManager.Domain.UserContext.Commands;
using EvoDcimManager.Domain.UserContext.Entities;
using EvoDcimManager.Domain.UserContext.Enums;
using EvoDcimManager.Domain.UserContext.Repositories;
using EvoDcimManager.Domain.UserContext.ValueObjects;
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

            // VO's
            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.Email);
            var password = new Password(command.Password, command.PasswordConfirmation);
            var role = (EUserRole)command.Role;

            var user = new User(name, email, password, role);

            // Grouping notifications
            AddNotifications(name, email, password);

            if (Invalid)
                return new CommandResult(false, "Nao foi possivel criar o usuario", "");

            // save informations
            _userRepository.Save(user);

            // send e-mail
            _emailService.Send(name.ToString(), email.Address, "Welcome to EVO DCIM", "Your account was created");

            return new CommandResult(true, "Usuario criado com sucesso", user);

        }
    }
}