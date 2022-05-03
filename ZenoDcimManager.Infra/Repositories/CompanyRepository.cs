using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task CreateCompany(Company company)
        {
            await _context.Companies.AddAsync(company);
        }

        public void UpdateCompany(Company company)
        {
            _context.Entry(company).State = EntityState.Modified;
        }

        public void DeleteCompany(Company company)
        {
            _context.Entry(company).State = EntityState.Deleted;
        }

        public async Task<IEnumerable<Company>> ListCompanies()
        {
            return await _context.Companies
                .ToListAsync();
        }

        public async Task<IEnumerable<Company>> ListCompaniesWithContract()
        {
            return await _context.Companies
                .Include(x => x.Contracts)
                .ToListAsync();
        }

        public async Task<Company> FindCompanyById(Guid id)
        {
            return await _context.Companies
                .FindAsync(id);
        }

        public async Task<Company> FindCompanyByName(string name)
        {
            return await _context.Companies
                .Where(x => x.CompanyName == name)
                .FirstOrDefaultAsync();
        }

        public async Task CreateContract(Contract contract)
        {
            await _context.Contracts.AddAsync(contract);
        }

        public async Task<IEnumerable<Contract>> ListContracts()
        {
            return await _context.Contracts.ToListAsync();
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}