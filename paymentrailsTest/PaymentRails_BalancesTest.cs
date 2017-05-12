using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentRails;
using PaymentRails.Exceptions;
using PaymentRails.Types;

namespace paymentrailsTest
{
    [TestClass]
    public class PaymentRails_BalancesTest
    {
        public static string apiKey = "pk_live_GOODAPIKEY";

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
            PaymentRails_Configuration.ApiKey = "pk_live_GOODAPIKEY";
            var response = PaymentRails_Balances.get("paypal");
            Assert.AreEqual(ValidResponseData.VALID_BALANCE_PAYPAL, response["paypal"]);
        }

        [TestMethod]
        public void TestRetrievePaymentrails()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_GOODAPIKEY";
            var response = PaymentRails_Balances.get("paymentrails");
            Assert.AreEqual(ValidResponseData.VALID_BALANCE, response["USD"]);
            Assert.AreEqual(response.Count, 4);
        }
    }
}
