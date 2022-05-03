﻿using ZenoDcimManager.Domain.UserContext.Commands;
using ZenoDcimManager.Domain.UserContext.Entities;
using ZenoDcimManager.Domain.UserContext.Enums;
using ZenoDcimManager.Domain.UserContext.Repositories;
using ZenoDcimManager.Domain.UserContext.Services;
using ZenoDcimManager.Domain.UserContext.Validators;
using ZenoDcimManager.Shared.Commands;
using ZenoDcimManager.Shared.Handlers;
using ZenoDcimManager.Shared.Services;
using Flunt.Notifications;
using ZenoDcimManager.Domain.UserContext.Commands.Output;
using System.Threading.Tasks;

namespace ZenoDcimManager.Domain.UserContext.Handlers
{
    public class UserHandler :
        Notifiable,
        ICommandHandler<CreateUserCommand>,
        ICommandHandler<EditUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IEmailService _emailService;
        private readonly ICryptoService _cryptoService;

        public UserHandler(IUserRepository userRepository, IEmailService emailService, ICryptoService cryptoService, ICompanyRepository companyRepository)
        {
            _userRepository = userRepository;
            _emailService = emailService;
            _cryptoService = cryptoService;
            _companyRepository = companyRepository;
        }

        public async Task<ICommandResult> Handle(CreateUserCommand command)
        {
            // Fail fast validations
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Nao foi possivel criar o usuario", command.Notifications);
            }

            // find company
            var company = await _companyRepository.FindCompanyById(command.CompanyId);

            if (company == null)
            {
                AddNotification("Company", "Empresa não encontrada");
                return new CommandResult(false, "Não foi possível criar o usuário", Notifications);
            }

            var role = (EUserRole)command.Role;
            var hashedPassword = _cryptoService.EncryptPassword(command.Password);
            var user = new User(command.FirstName, command.LastName, command.Email, hashedPassword, role, company);

            var userValidator = new UserValidator(user);

            // Grouping notifications
            AddNotifications(userValidator);

            if (Invalid)
                return new CommandResult(false, "Nao foi possivel criar o usuario", "");

            // save informations
            await _userRepository.Save(user);
            await _userRepository.Commit();

            // send e-mail
            _emailService.Send(user.ToString(), user.Email, "Welcome to Zeno DCIM", "Your account was created");

            return new CommandResult(true, "Usuario criado com sucesso", new UserOutputCommand(user.Id, user.FirstName, user.LastName, user.Email, user.Role, user.Active));

        }

        public async Task<ICommandResult> Handle(EditUserCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Nao foi possivel editar o usuario", Notifications);
            }

            // find company
            var company = await _companyRepository.FindCompanyById(command.CompanyId);

            if (company == null)
            {
                AddNotification("Company", "Empresa não encontrada");
                return new CommandResult(false, "Não foi possível criar o usuário", Notifications);
            }

            var user = await _userRepository.Find(command.Id);

            if (user == null)
            {
                AddNotification("User", "User not found");
                return new CommandResult(false, "Nao foi possivel editar o usuario", Notifications);
            }

            var role = (EUserRole)command.Role;
            var editedUser = new User(command.FirstName, command.LastName, command.Email, role, company);

            user.CopyWith(editedUser);

            _userRepository.Update(user);
            await _userRepository.Commit();

            return new CommandResult(true, "Usuario alterado com sucesso", new UserOutputCommand(user.Id, user.FirstName, user.LastName, user.Email, user.Role, user.Active));
        }
    }
}