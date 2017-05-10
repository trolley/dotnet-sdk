using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentRails;
using PaymentRails.Exceptions;
using PaymentRails.Types;
using System.Collections.Generic;

namespace paymentrailsTest
{

    [TestClass]
    public class PaymentRails_RecipientTest
    {

        private Payout PaymentPayout;
        private Address Address;
        private Compliance Compliance;

        [TestInitialize]
        public void Init()
        {
            this.PaymentPayout = new Payout();
            this.Address = new Address(null, null, null, null, null, null, null);
            this.Compliance = new Compliance("pending", null);

        PaymentRails_Client.HttpMessageHandler = new MockHttpHandler();
        }

        [TestMethod]
        public void TestRetrieveRecipient()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            Recipient response = PaymentRails_Recipient.get("R-91XPU407CRNGR");
            Assert.AreEqual(ValidResponseData.VALID_RECIPIENT, response);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        public void TestRetrieveRecipientNotFound()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            Recipient response = PaymentRails_Recipient.get("efef");
        }

        [TestMethod]
        public void TestCreateRecipient()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            Recipient recipient = new Recipient("R-91XQ4VKD39C3P", "individual", "tess@example.com", "tess@example.com", "John Smith", "John", "Smith", "incomplete", null, "en", null, "https://s3.amazonaws.com/static.api.paymentrails.com/icon_user.svg", Compliance, null, Address);

            Recipient newRecipient = PaymentRails_Recipient.post(recipient);

            Assert.AreEqual(recipient, newRecipient);
         }
        [TestMethod]
        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        public void TestCreateRecipientInvalid()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            Recipient recipient = new Recipient("R-91XQ4VKD39C3P", "individual", "INVALID", "tess@example.com", "John Smith", "John", "Smith", "incomplete", null, "en", null, "https://s3.amazonaws.com/static.api.paymentrails.com/icon_user.svg", Compliance, null, Address);
            try
            {
                PaymentRails_Recipient.post(recipient);
            }

            catch (InvalidStatusCodeException e)
            {
                Assert.AreEqual(MockResponseContent.INVALID_BAD_DATA, e.Message);
                throw (e);
            }
        }

        [TestMethod]
        public void TestUpdateRecipient()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            Recipient recipient = new Recipient("R-91XQ4VKD39C3P", "individual", "tess@example.com", "tess@example.com", "John Smith", "John", "Smith", "incomplete", null, "en", null, "https://s3.amazonaws.com/static.api.paymentrails.com/icon_user.svg", Compliance, null, Address);
            String response = PaymentRails_Recipient.patch(recipient);

            String message = response.Substring(6, 4);
            Assert.AreEqual("true", message);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        public void TestUpdateRecipientInvalidRecipientId()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            Recipient recipient = new Recipient("R-91XQ4VKD39C3P", "individual", "INVALID", "tess@example.com", "John Smith", "John", "Smith", "incomplete", null, "en", null, "https://s3.amazonaws.com/static.api.paymentrails.com/icon_user.svg", Compliance, null, Address);
            String response = PaymentRails_Recipient.patch(recipient);
        }




        [TestMethod]
        public void TestDeleteRecipient()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            Recipient recipient = new Recipient("R-91XQ4VKD39C3P", "individual", "tess@example.com", "tess@example.com", "John Smith", "John", "Smith", "incomplete", null, "en", null, "https://s3.amazonaws.com/static.api.paymentrails.com/icon_user.svg", Compliance, null, Address);
            String response = PaymentRails_Recipient.delete(recipient);
            Assert.AreEqual(MockResponseContent.VALID_POST, response);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        public void TestDeleteRecipientInvalidRecipientId()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            Recipient recipient = new Recipient("91XQ4VKD39C3P", "individual", "tess@example.com", "tess@example.com", "John Smith", "John", "Smith", "incomplete", null, "en", null, "https://s3.amazonaws.com/static.api.paymentrails.com/icon_user.svg", Compliance, null, Address);
            try
            {
                String response = PaymentRails_Recipient.delete(recipient);
            }
            catch (InvalidStatusCodeException e)
            {
                Assert.AreEqual(MockResponseContent.INVALID_NOT_FOUND, e.Message);
                throw e;
            }
        }

        [TestMethod]
        public void TestListAllRecipients()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            List<Recipient> response = PaymentRails_Recipient.query();

            Assert.AreEqual(ValidResponseData.VALID_RECIPIENT, response[0]);

        }

        [TestMethod]
        public void TestListAllRecipientsWithQueries()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            List<Recipient> response = PaymentRails_Recipient.query("j",1,10);

            Assert.AreEqual(ValidResponseData.VALID_RECIPIENT, response[0]);
        }


        [TestMethod]
        public void TestRetrieveAllLogs()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            String response = PaymentRails_Recipient.get("R-91XPU407CRNGR", "logs");
            Assert.AreEqual(MockResponseContent.VALID_POST, response);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        public void TestRetrieveAllLogsInvalidRecipientId()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            try
            {
                String response = PaymentRails_Recipient.get("INVALID", "logs");
            }
            catch (InvalidStatusCodeException e)
            {
                Assert.AreEqual(MockResponseContent.INVALID_NOT_FOUND, e.Message);
                throw e;
            }
        }

        [TestMethod]
        public void TestRetrieveAllpayments()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            String response = PaymentRails_Recipient.get("R-91XPU407CRNGR", "payments");
            Assert.AreEqual(MockResponseContent.VALID_POST, response);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        public void TestRetrieveAllPaymentsInvalidRecipientId()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";

            try
            {
                String response = PaymentRails_Recipient.get("INVALID", "payments");
            }
            catch (InvalidStatusCodeException e)
            {
                Assert.AreEqual(MockResponseContent.INVALID_NOT_FOUND, e.Message);
                throw e;
            }
        }


    }
}