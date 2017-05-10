using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentRails;
using PaymentRails.Exceptions;
using PaymentRails.Types;

namespace paymentrailsTest
{
    [TestClass]
    public class PaymentRails_PayoutMethodsTest
    {
        [TestInitialize]
        public void Init()
        {
            PaymentRails_Client.HttpMessageHandler = new MockHttpHandler();
        }
        [TestMethod]
        public void TestRetrievePayoutMethod()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            Payout response = PaymentRails_PayoutMethods.get("R-91XQ4QBJ65W1U");
            Assert.AreEqual(ValidResponseData.VALID_PAYOUT, response);

        }



        [TestMethod]
        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        public void TestRetrievePayoutMethodInvalidRecipientId()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            try {
                Payout response = PaymentRails_PayoutMethods.get("91XQ4QBJ65W1U");
            }
             catch (InvalidStatusCodeException e)
            {
                Assert.AreEqual(MockResponseContent.INVALID_NOT_FOUND, e.Message);
                throw (e);
            }

        }

        [TestMethod]
        public void TestCreatePayoutMethod()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            Payout payout = new Payout(1000, false, 1000, false, "bank", "USD", null, null);
            Payout response = PaymentRails_PayoutMethods.post("R-91XQ4QBJ65W1U",payout);
            Assert.AreEqual(payout, response);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        public void TestCreatePayoutMethodRecipientId()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            Payout payout = new Payout(1000, false, 1000, false, "bank", "USD", null, null);

            try
            {
                 Payout response = PaymentRails_PayoutMethods.post("91XQ4QBJ65W1U", payout);
            }
            catch (InvalidStatusCodeException e)
            {
                Assert.AreEqual(MockResponseContent.INVALID_BAD_DATA, e.Message);
                throw (e);
            }
        }



        [TestMethod]
        public void TestUpdatePayoutMethod()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            Payout payout = new Payout(1000, false, 1000, false, "bank", "USD", null, null);
            String response = PaymentRails_PayoutMethods.patch("R-91XQ4QBJ65W1U", payout);
            String message = response.Substring(6, 4);
            Assert.AreEqual("true", message);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        public void TestUpdatePayoutMethodInvalidRecipientId()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            Payout payout = new Payout(1000, false, 1000, false, "bank", "USD", null, null);
            try
            {
                String response = PaymentRails_PayoutMethods.patch("91XQ4QBJ65W1U", payout);
            }
            catch (InvalidStatusCodeException e)
            {
                Assert.AreEqual(MockResponseContent.INVALID_BAD_DATA, e.Message);
                throw (e);
            }

        }
    }
}