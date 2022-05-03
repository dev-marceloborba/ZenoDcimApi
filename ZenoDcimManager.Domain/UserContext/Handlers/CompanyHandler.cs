using System.Threading.Tasks;
using Flunt.Notifications;
using ZenoDcimManager.Domain.UserContext.Commands.Input;
using ZenoDcimManager.Domain.UserContext.Entities;
using ZenoDcimManager.Domain.UserContext.Repositories;
using ZenoDcimManager.Shared.Commands;
using ZenoDcimManager.Shared.Handlers;

namespace ZenoDcimManager.Domain.UserContext.Handlers
{
    public class CompanyHandler :
        Notifiable,
        ICommandHandler<CreateCompanyCommand>,
        ICommandHandler<CreateContractCommand>
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<ICommandResult> Handle(CreateCompanyCommand command)
        {
            var company = new Company(command.CompanyName, command.TradingName, command.RegistrationNumber);

            await _companyRepository.CreateCompany(company);
            await _companyRepository.Commit();

            return new CommandResult(true, "Empresa criada com sucesso", company);
        }

        public async Task<ICommandResult> Handle(CreateContractCommand command)
        {
            var company = await _companyRepository.FindCompanyById(command.CompanyId);

            var contract = new Contract(command.StartDate, command.EndDate, command.PowerConsumptionDailyLimit);

            company.AddContract(contract);

            await _companyRepository.CreateContract(contract);
            await _companyRepository.Commit();

            return new CommandResult(true, "Contrato criado com sucesso", company);
        }
    }
}