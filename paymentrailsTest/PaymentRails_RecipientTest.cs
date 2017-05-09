//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using paymentrails;
//using paymentrails.Exceptions;


//namespace paymentrailsTest
//{
//    [TestClass]
//    public class PaymentRails_RecipientTest
//    {
//        [TestMethod]
//        public void TestRetrieveRecipient()
//        {
//            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
//            String response = PaymentRails_Recipient.get("R-91XPU407CRNGR");
//            String message = response.Substring(6, 4);
//            Assert.AreEqual("true", message);
//        }
//        [TestMethod]
//        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
//        public void TestRetrieveRecipientInvalidAPIKey()
//        {
//            PaymentRails_Configuration.ApiKey = "wdwd";
//            String response = PaymentRails_Recipient.get("R-91XPMEHZ44RMP");
//        }

//        [TestMethod]
//        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
//        public void TestRetrieveRecipientInvalidRecipientId()
//        {
//            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
//            String response = PaymentRails_Recipient.get("R-efef");
//        }

//        [TestMethod]
//        [Ignore]
//        public void TestCreateRecipient()
//        {
//            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
//            String body = @"{ ""type"": ""individual"", ""firstName"": ""John"", ""lastName"": ""Jones"", ""email"": ""martian@manhunter.com""}";
//            String response = PaymentRails_Recipient.post(body);
//            String message = response.Substring(6, 4);
//            Assert.AreEqual("true", message);
//        }
//        [TestMethod]
//        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
//        public void TestCreateRecipientEmailInUse()
//        {
//            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
//            String body = @"{ ""type"": ""individual"", ""firstName"": ""John"", ""lastName"": ""Jones"", ""email"": ""martian@manhunter.com""}";
//            String response = PaymentRails_Recipient.post(body);
//        }
//        [TestMethod]
//        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]

//        public void TestCreateRecipientInvalidAPIKey()
//        {
//            PaymentRails_Configuration.ApiKey = "wdw";
//            String body = @"{ ""type"": ""individual"", ""firstName"": ""John"", ""lastName"": ""Jones"", ""email"": ""martian@manhunter.com""}";
//            String response = PaymentRails_Recipient.post(body);
//        }
//        [TestMethod]
//        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
//        public void TestCreateRecipientMissingField()
//        {
//            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
//            String body = @"{""firstName"": ""John"", ""lastName"": ""Jones"", ""email"": ""martian@manhunter.com""}";
//            String response = PaymentRails_Recipient.post(body);
//        }
//        [TestMethod]
//        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
//        public void TestCreateRecipientInvalidField()
//        {
//            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
//            String body = @"{ ""type"": ""individual"", ""firstName"": ""John"", ""lastName"": ""Jones"", ""email"": ""martianmanhunter.com""}";
//            String response = PaymentRails_Recipient.post(body);
//        }

//        [TestMethod]
//        public void TestUpdateRecipient()
//        {
//            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
//            String body = @"{""firstName"": ""Bart""}";
//            String response = PaymentRails_Recipient.patch("R-91XPU407CRNGR", body);
//            String message = response.Substring(6, 4);
//            Assert.AreEqual("true", message);
//        }
//        [TestMethod]
//        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
//        public void TestUpdateRecipientInvalidAPIKey()
//        {
//            PaymentRails_Configuration.ApiKey = "wddw";
//            String body = @"{""firstName"": ""Bart""}";
//            String response = PaymentRails_Recipient.patch("R-91XPU407CRNGR", body);
//        }
//        [TestMethod]
//        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
//        public void TestUpdateRecipientInvalidRecipientId()
//        {
//            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
//            String body = @"{""firstName"": ""Bart""}";
//            String response = PaymentRails_Recipient.patch("R-wdwd", body);
//        }
//        [TestMethod]
//        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
//        public void TestUpdateRecipientInvalidField()
//        {
//            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
//            String body = @"{""email"": ""Bart""}";
//            String response = PaymentRails_Recipient.patch("R-91XPU407CRNGR", body);
//        }

//        [TestMethod]
//        [Ignore]
//        public void TestDeleteRecipient()
//        {
//            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
//            String response = PaymentRails_Recipient.delete("R-91XPMEHZ44RMP");
//            String message = response.Substring(6, 4);
//            Assert.AreEqual("true", message);
//        }
//        [TestMethod]
//        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
//        public void TestDeleteRecipientInvalidAPIKey()
//        {
//            PaymentRails_Configuration.ApiKey = "wd";
//            String response = PaymentRails_Recipient.delete("R-91XPU407CRNGR");
//            String message = response.Substring(6, 4);
//            Assert.AreEqual("true", message);
//        }
//        [TestMethod]
//        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
//        public void TestDeleteRecipientInvalidRecipientId()
//        {
//            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
//            String response = PaymentRails_Recipient.delete("R-wdwdwwd");
//            String message = response.Substring(6, 4);
//            Assert.AreEqual("true", message);
//        }
//        [TestMethod]
//        public void TestListAllRecipients()
//        {
//            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
//            String response = PaymentRails_Recipient.query();
//            String message = response.Substring(6, 4);
//            Assert.AreEqual("true", message);
//        }
//        [TestMethod]
//        public void TestListAllRecipientsWithQueries()
//        {
//            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
//            String response = PaymentRails_Recipient.query("", 1, 10);
//            String message = response.Substring(6, 4);
//            Assert.AreEqual("true", message);
//        }
//        [TestMethod]
//        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
//        public void TestListAllRecipientsInvalidAPIKey()
//        {
//            PaymentRails_Configuration.ApiKey = "dwwd";
//            String response = PaymentRails_Recipient.query();

//        }

//        [TestMethod]
//        [Ignore]
//        public void TestRetrieveAllLogs()
//        {
//            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
//            String response = PaymentRails_Recipient.get("R-91XPU407CRNGR", "logs");
//            String message = response.Substring(6, 4);
//            Assert.AreEqual("true", message);
//        }
//        [TestMethod]
//        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
//        public void TestRetrieveAllLogsInvalidAPIKey()
//        {
//            PaymentRails_Configuration.ApiKey = "wdwd";
//            String response = PaymentRails_Recipient.get("R-91XPU407CRNGR", "logs");
//        }
//        [TestMethod]
//        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
//        public void TestRetrieveAllLogsInvalidRecipientId()
//        {
//            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
//            String response = PaymentRails_Recipient.get("R-wdwd", "logs");
//        }

//        [TestMethod]
//        public void TestRetrieveAllPayments()
//        {
//            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
//            String response = PaymentRails_Recipient.get("R-91XPU407CRNGR", "payments");
//            String message = response.Substring(6, 4);
//            Assert.AreEqual("true", message);
//        }
//        [TestMethod]
//        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
//        public void TestRetrieveAllPaymentsInvalidAPIKey()
//        {
//            PaymentRails_Configuration.ApiKey = "wdwd";
//            String response = PaymentRails_Recipient.get("R-91XPU407CRNGR", "payments");
//        }
//        [TestMethod]
//        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
//        public void TestRetrieveAllPaymentsInvalidRecipientId()
//        {
//            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
//            String response = PaymentRails_Recipient.get("R-wdwd", "payments");
//        }

//    }
//}