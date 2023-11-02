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
            gateway = new Trolley.Gateway(Config.TEST_API_KEY, Config.TEST_API_SECRET);
        }

        [TestMethod]
        public void Smoke()
        {
            List<Balance> balances = gateway.balances.all();
            Assert.IsTrue(balances.Count > 0);
        }

        [TestMethod]
        public void testFind()
        {
            List<Balance> allBalances = gateway.balances.find("all");
            Assert.IsTrue(allBalances.Count > 0);

            List<Balance> prBalances = gateway.balances.find("paymentrails");
            Assert.IsTrue(prBalances.Count >= 0);

            List<Balance> paypalBalances = gateway.balances.find("paypal");
            Assert.IsTrue(paypalBalances.Count >= 0);
        }
    }
}
