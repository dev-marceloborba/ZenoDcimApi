using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZenoDcimManager.Domain.UserContext.Entities;
using ZenoDcimManager.Domain.UserContext.Validators;

namespace ZenoDcimManager.Tests.UserContext.Entities
{
    [TestClass]
    public class CompanyEntityTests
    {
        private readonly Company _validCompany;
        private readonly Company _invalidCompany;

        public CompanyEntityTests()
        {
            _validCompany = new Company("Mindcloud", "Mindcloud", "35843118000166");
            _invalidCompany = new Company("Mindcloud", "Mindcloud", "123465798123");
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldReturnAValidRegistrationNumber()
        {
            var companyValidator = new CompanyValidator(_validCompany);
            Assert.AreEqual(true, companyValidator.Valid);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldReturnAnInvalidRegistrationNumber()
        {
            var companyValidator = new CompanyValidator(_invalidCompany);
            Assert.AreEqual(true, companyValidator.Invalid);
        }
    }
}