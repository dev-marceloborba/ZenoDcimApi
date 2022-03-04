using System;
using System.Collections.Generic;
using ZenoDcimManager.Domain.UserContext.Entities;
using ZenoDcimManager.Shared.UnitOfWork;

namespace ZenoDcimManager.Domain.UserContext.Repositories
{
    public interface ICompanyRepository : IUnitOfWork
    {
        void CreateCompany(Company company);
        void UpdateCompany(Company company);
        void DeleteCompany(Company company);
        IEnumerable<Company> ListCompanies();
        IEnumerable<Company> ListCompaniesWithContract();
        Company FindCompanyById(Guid id);
        Company FindCompanyByName(string name);
        void CreateContract(Company company);
        IEnumerable<Contract> ListContracts();
    }
}