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

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            PaymentRails_Client.HttpMessageHandler = new MockHttpHandler();
        }

        [TestMethod]
        public void TestRetrieveBalances()
        {
            PaymentRails_Configuration.ApiKey = apiKey;
            Dictionary<String, Balance> response = PaymentRails_Balances.get();
            Assert.IsTrue(response.ContainsKey("USD"));
            Assert.AreEqual(ValidResponseData.VALID_BALANCE, response["USD"]);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        public void TestRetrieveBalancesInvalidAPIKey()
        {
            PaymentRails_Configuration.ApiKey = "wdwd";
            var response = PaymentRails_Balances.get();
        }

        [TestMethod]
        public void TestRetrievePaypal()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            var response = PaymentRails_Balances.get("paypal");
            Assert.AreEqual(ValidResponseData.VALID_BALANCE_PAYPAL, response["paypal"]);
        }

        [TestMethod]
        public void TestRetrievePaymentrails()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            var response = PaymentRails_Balances.get("paymentrails");
            Assert.AreEqual(ValidResponseData.VALID_BALANCE, response["USD"]);
            Assert.AreEqual(response.Count, 4);
        }
    }
}
