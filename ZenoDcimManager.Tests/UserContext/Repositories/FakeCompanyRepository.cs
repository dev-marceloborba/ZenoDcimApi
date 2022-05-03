using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenoDcimManager.Domain.UserContext.Entities;
using ZenoDcimManager.Domain.UserContext.Repositories;

namespace ZenoDcimManager.Tests.UserContext.Repositories
{
    public class FakeCompanyRepository : ICompanyRepository
    {
        private readonly List<Company> _companies = new List<Company>();

        public FakeCompanyRepository()
        {
            _companies.Add(new Company("Mindcloud", "Mindcloud", "35843118000166"));
        }

        public async Task Commit()
        {

        }

        public async Task CreateCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public async Task CreateContract(Contract contract)
        {
            throw new NotImplementedException();
        }

        public void DeleteCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public async Task<Company> FindCompanyById(Guid id)
        {
            var firstCompany = _companies.FirstOrDefault();
            return firstCompany;
        }

        public async Task<Company> FindCompanyByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Company>> ListCompanies()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Company>> ListCompaniesWithContract()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Contract>> ListContracts()
        {
            throw new NotImplementedException();
        }

        public void UpdateCompany(Company company)
        {
            throw new NotImplementedException();
        }
    }
}