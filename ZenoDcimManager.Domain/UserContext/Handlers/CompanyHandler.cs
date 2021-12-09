using Flunt.Notifications;
using ZenoDcimManager.Domain.UserContext.Commands.Input;
using ZenoDcimManager.Domain.UserContext.Entities;
using ZenoDcimManager.Domain.UserContext.Repositories;
using ZenoDcimManager.Shared.Commands;
using ZenoDcimManager.Shared.Handlers;

namespace ZenoDcimManager.Domain.UserContext.Handlers
{
    public class CompanyHandler : Notifiable, ICommandHandler<CreateCompanyCommand>
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public ICommandResult Handle(CreateCompanyCommand command)
        {
            var company = new Company(command.CompanyName, command.TradingName, command.RegistrationNumber);

            _companyRepository.CreateCompany(company);

            return new CommandResult(true, "Empresa criada com sucesso", company);
        }
    }
}