using System;
using System.Collections.Generic;
using ZenoDcimManager.Domain.UserContext.Entities;

namespace ZenoDcimManager.Domain.UserContext.Repositories
{
    public interface ICompanyRepository
    {
        void CreateCompany(Company company);
        void UpdateCompany(Company company);
        void DeleteCompany(Company company);
        IEnumerable<Company> ListCompanies();
        IEnumerable<Company> ListCompaniesWithContract();
        Company FindCompanyById(Guid id);
        Company FindCompanyByName(string name);
    }
}