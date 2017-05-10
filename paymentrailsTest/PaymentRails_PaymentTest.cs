using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using paymentrails;
using paymentrails.Exceptions;
using paymentrails.Types;
using System.Collections.Generic;
using System.Linq;

namespace paymentrailsTest
{
    [TestClass]
    public class PaymentRails_PaymentTest
    {
        private Recipient PaymentRecipient;

        private Payout PaymentPayout;
        private Address PaymentAddress;

        [TestInitialize]
        public void Init()
        {
            this.PaymentPayout = new Payout();
            this.PaymentAddress = new Address();
            this.PaymentRecipient = new Recipient("R-DUMMYRECIPIENT", "individual", "dummyReference", "user@test.email", "Jim Testerson", "Jim", "Testerson", null, null, "en", null, null, null, PaymentPayout, PaymentAddress);
            PaymentRails_Client.HttpMessageHandler = new MockHttpHandler();
        }

        [TestMethod]
        public void TestRetrievePayment()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            Payment response = PaymentRails_Payment.get("P-91XPU88Q5GN2E");
            response.Equals(ValidResponseData.VALID_PAYMENT);
            Assert.AreEqual(ValidResponseData.VALID_PAYMENT, response);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        public void TestRetrievePaymentInvalidAPIKey() // @TODO: move to test on client class
        {
            PaymentRails_Configuration.ApiKey = "effe";
            Payment response = PaymentRails_Payment.get("P-91XPU88Q5GN2E");
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        public void TestRetrievePaymentNotFound()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            Payment response = PaymentRails_Payment.get("91XPU88Q5GN2E");
        }
        
        [TestMethod]
        public void TestCreatePayment()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            Payment p = new Payment(PaymentRecipient, 10, "VALID", 0, "CAD", 0,0,0,0,null,null,null,0,null,"B-VALIDBATCHID" ,null,null,null);
            String response = PaymentRails_Payment.post(p);
            String message = response.Substring(6, 4);
            Assert.AreEqual("true", message);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStatusCodeException), "The wrong exception was thrown")]
        public void TestCreatePaymentInvalidData()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            Payment p = new Payment(PaymentRecipient, 10, "INVALID", 0, "CAD", 0, 0, 0, 0, null, null, null, 0, null, "B-INVALIDBATCHID", "INVALIDID", null, null);
            try
            {
                string response = PaymentRails_Payment.post(p);
            }
            catch (InvalidStatusCodeException e)
            {
                Assert.AreEqual(MockResponseContent.INVALID_BAD_DATA, e.Message);
                throw (e);
            }
        }

        [TestMethod]
        public void TestUpdatePayment()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            Payment p = new Payment(PaymentRecipient, 10, "VALID", 0, "CAD", 0, 0, 0, 0, null, null, null, 0, null, "B-VALIDBATCHID", "P-VALIDID", null, null);
            String response = PaymentRails_Payment.patch(p);
            String message = response.Substring(6, 4);
            Assert.AreEqual("true", message);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        public void TestUpdatePaymentNotFound()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            Payment p = new Payment(PaymentRecipient, 10, "VALID", 0, "CAD", 0, 0, 0, 0, null, null, null, 0, null, "VALIDBATCHID", "P-VALIDID", null, null);
            String response = PaymentRails_Payment.patch(p);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        public void TestUpdatePaymentInvalidData()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            Payment p = new Payment(PaymentRecipient, 10, "INVALID", 0, "CAD", 0, 0, 0, 0, null, null, null, 0, null, "B-VALIDBATCHID", "P-VALIDID", null, null);
            try
            {
                String response = PaymentRails_Payment.patch(p);
            }
            catch (InvalidStatusCodeException e)
            {
                Assert.AreEqual(MockResponseContent.INVALID_BAD_DATA, e.Message);
                throw e;
            }
        }

        [TestMethod]
        public void TestDeletePayment()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            Payment p = new Payment(PaymentRecipient, 10, "INVALID", 0, "CAD", 0, 0, 0, 0, null, null, null, 0, null, "B-VALIDBATCHID", "P-VALIDID", null, null);
            String response = PaymentRails_Payment.delete(p);
            Assert.AreEqual(MockResponseContent.VALID_POST, response);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStatusCodeException), "Wrong exception was thrown")]
        public void TestDeletePaymentInvalidNotFound()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            Payment p = new Payment(PaymentRecipient, 10, "VALID", 0, "CAD", 0, 0, 0, 0, null, null, null, 0, null, "B-VALIDBATCHID", "VALIDID", null, null);
            try
            {
                String response = PaymentRails_Payment.delete(p);
            }
            catch (InvalidStatusCodeException e)
            {
                Assert.AreEqual(MockResponseContent.INVALID_NOT_FOUND, e.Message);
                throw e;
            }
        }

        [TestMethod]
        public void TestListAllPayment()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            List<Payment> payments = PaymentRails_Payment.get(1,2);
            Assert.IsTrue(ValidResponseData.VALID_PAYMENTS.SequenceEqual(payments));
        }
        [TestMethod]
        public void TestListAllPaymentWithQueries()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            List<Payment> payments = PaymentRails_Payment.query("WOWOWEEEE", 1, 2);
            Assert.IsTrue(ValidResponseData.VALID_PAYMENTS.SequenceEqual(payments));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        public void TestListAllPaymentInvalidBatchId()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            try
            {
                List<Payment> response = PaymentRails_Payment.query("WOWOWEEEE", 1, 2, "INVALIDBATCH");
            }
            catch(InvalidStatusCodeException e)
            {
                Assert.AreEqual(MockResponseContent.INVALID_NOT_FOUND, e.Message);
                throw e;
            }
            
        }
    }
}
