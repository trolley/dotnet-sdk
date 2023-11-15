using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trolley.Types;
using System;
using System.Collections.Generic;

namespace tests
{
    [TestClass]
    public class BalanceTest
    {

        Trolley.Gateway gateway;

        [TestInitialize]
        public void Init()
        {
            Config config = new Config();
            gateway = new Trolley.Gateway(config.ACCESS_KEY, config.SECRET_KEY);
        }

        [TestMethod]
        public void Smoke()
        {
            List<Balance> balances = gateway.balances.GetAllBalances();
            Assert.IsTrue(balances.Count > 0);
        }

        [TestMethod]
        public void testGetAllBalances()
        {
            List<Balance> prBalances = gateway.balances.GetTrolleyBalances();
            Assert.IsTrue(prBalances.Count >= 0);

            List<Balance> paypalBalances = gateway.balances.GetPaypalBalances();
            Assert.IsTrue(paypalBalances.Count >= 0);
        }
    }
}
