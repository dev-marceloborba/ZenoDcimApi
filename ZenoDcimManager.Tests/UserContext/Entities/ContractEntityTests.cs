using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZenoDcimManager.Domain.UserContext.Entities;

namespace ZenoDcimManager.Tests.UserContext.Entities
{
    [TestClass]
    public class ContractEntityTests
    {
        private DateTime _initialDate = DateTime.Parse("2021-11-01", CultureInfo.InvariantCulture);
        private DateTime _finalDate = DateTime.Parse("2021-12-28", CultureInfo.InvariantCulture);
        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldReturnTrueWhenContractIsEnding()
        {
            var contract = new Contract(_initialDate, _finalDate, 100);
            Assert.AreEqual(true, contract.IsContractEnding());
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldReturnFalseWhenContractIsNotEnding()
        {
            var contract = new Contract(_initialDate, _finalDate.AddMonths(1), 100);
            Assert.AreEqual(false, contract.IsContractEnding());
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldReturnTrueWhenDailyPowerConsumptionIsReached()
        {
            var contract = new Contract(DateTime.Now, DateTime.Now.AddDays(40), 1000);
            var isPowerExcedeed = contract.DailyPowerConsumptionExceeded(2000);
            Assert.AreEqual(true, isPowerExcedeed);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void ShouldReturnFalseWhenDailyPowerConsumptionIsNotReached()
        {
            var contract = new Contract(DateTime.Now, DateTime.Now.AddDays(40), 1000);
            var isPowerExcedeed = contract.DailyPowerConsumptionExceeded(100);
            Assert.AreEqual(false, isPowerExcedeed);
        }
    }
}