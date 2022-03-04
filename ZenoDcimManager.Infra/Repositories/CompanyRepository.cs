using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ZenoDcimManager.Domain.UserContext.Entities;
using ZenoDcimManager.Domain.UserContext.Repositories;
using ZenoDcimManager.Infra.Contexts;

namespace ZenoDcimManager.Infra.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly UserContext _context;

        public CompanyRepository(UserContext context)
        {
            _context = context;
        }

        public void CreateCompany(Company company)
        {
            _context.Companies.Add(company);
        }

        public void UpdateCompany(Company company)
        {
            _context.Entry(company).State = EntityState.Modified;
        }

        public void DeleteCompany(Company company)
        {
            _context.Companies.Remove(company);
        }

        public IEnumerable<Company> ListCompanies()
        {
            return _context.Companies.ToList();
        }

        public IEnumerable<Company> ListCompaniesWithContract()
        {
            return _context.Companies.Include(x => x.Contracts).ToList();
        }

        public Company FindCompanyById(Guid id)
        {
            return _context.Companies.Find(id);
        }

        public Company FindCompanyByName(string name)
        {
            return _context.Companies.Where(x => x.CompanyName == name).FirstOrDefault();
        }

        public void CreateContract(Company company)
        {
            var count = company.Contracts.Count();
            _context.Contracts.Add(company.Contracts.ElementAt(count - 1));
        }

        public IEnumerable<Contract> ListContracts()
        {
            return _context.Contracts.ToList();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}