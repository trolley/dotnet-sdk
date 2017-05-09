using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using paymentrails;
using paymentrails.Exceptions;
using paymentrails.Types;

namespace paymentrailsTest
{
    [TestClass]
    public class PaymentRails_BalancesTest
    {
        public static string apiKey = "pk_test_91XPUY8D8GAGA";
        public Balance sampleBalance = new paymentrails.Types.Balance(true, 10000, "USD", "paymentrails", null);
        [TestMethod]
        public void TestRetrieveBalances()
        {
            PaymentRails_Configuration.ApiKey = apiKey;
            Dictionary<String, Balance> response = PaymentRails_Balances.get();
            Assert.IsTrue(response.ContainsKey("USD"));
            Assert.AreEqual(this.sampleBalance, response["USD"]);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        public void TestRetrieveBalancesInvalidAPIKey()
        {
            PaymentRails_Configuration.ApiKey = "wdwd";
            var response = PaymentRails_Balances.get();
        }

        [TestMethod]
        [Ignore]
        public void TestRetrievePaypal()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            var response = PaymentRails_Balances.get("paypal");
            //String message = response.Substring(6, 4);
            //Assert.AreEqual("true", message);
        }

        [TestMethod]
        [Ignore]
        public void TestRetrievePaymentrails()
        {
            //PaymentRails_Configuration.apiKey = "pk_live_91XNJFBD19ZQ6";
            //String response = PaymentRails_Balances.get("paymentrails");
            //String message = response.Substring(6, 4);
            //Assert.AreEqual("true", message);
        }
    }
}
