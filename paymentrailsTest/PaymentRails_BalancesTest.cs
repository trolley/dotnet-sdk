using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using paymentrails;
using paymentrails.Exceptions;

namespace paymentrailsTest
{
    [TestClass]
    public class PaymentRails_BalancesTest
    {
        [TestMethod]
        public void TestRetrieveBalances()
        {
            PaymentRails_Configuration.apiKey = "pk_live_91XNJFBD19ZQ6";
            String response = PaymentRails_Balances.get();
            String message = response.Substring(6, 4);
            Assert.AreEqual("true", message);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        public void TestRetrieveBalancesInvalidAPIKey()
        {
            PaymentRails_Configuration.apiKey = "wdwd";
            String response = PaymentRails_Balances.get();
        }

        [TestMethod]
        [Ignore]
        public void TestRetrievePaypal()
        {
            PaymentRails_Configuration.apiKey = "pk_live_91XNJFBD19ZQ6";
            String response = PaymentRails_Balances.get("paypal");
            String message = response.Substring(6, 4);
            Assert.AreEqual("true", message);
        }

        [TestMethod]
        [Ignore]
        public void TestRetrievePaymentrails()
        {
            PaymentRails_Configuration.apiKey = "pk_live_91XNJFBD19ZQ6";
            String response = PaymentRails_Balances.get("paymentrails");
            String message = response.Substring(6, 4);
            Assert.AreEqual("true", message);
        }
    }
}
