using System.Collections.Generic;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.UserContext.Entities
{
    public class Company : Entity
    {
        public string CompanyName { get; private set; } // razao social
        public string TradingName { get; private set; } // nome fantasia
        public string RegistrationNumber { get; private set; } // cnpj
        public List<Contract> Contracts { get; private set; }

        public Company(string companyName, string tradingName, string registrationNumber)
        {
            CompanyName = companyName;
            TradingName = tradingName;
            RegistrationNumber = registrationNumber;
            Contracts = new List<Contract>();
        }

        public void AddContract(Contract contract)
        {
            Contracts.Add(contract);
        }

        public void RemoveContract(Contract contract)
        {
            Contracts.Remove(contract);
        }

        public void RemoveAllContracts()
        {
            Contracts.Clear();
        }
    }
}