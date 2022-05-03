using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZenoDcimManager.Domain.UserContext.Entities;
using ZenoDcimManager.Shared.UnitOfWork;

namespace ZenoDcimManager.Domain.UserContext.Repositories
{
    public interface ICompanyRepository : IUnitOfWork
    {
        Task CreateCompany(Company company);
        void UpdateCompany(Company company);
        void DeleteCompany(Company company);
        Task<IEnumerable<Company>> ListCompanies();
        Task<IEnumerable<Company>> ListCompaniesWithContract();
        Task<Company> FindCompanyById(Guid id);
        Task<Company> FindCompanyByName(string name);
        Task CreateContract(Contract contract);
        Task<IEnumerable<Contract>> ListContracts();
    }
}