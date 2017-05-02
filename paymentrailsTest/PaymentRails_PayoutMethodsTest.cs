using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using paymentrails;
using paymentrails.Exceptions;

namespace paymentrailsTest
{
    [TestClass]
    public class PaymentRails_PayoutMethodsTest
    {
        [TestMethod]
        public void TestRetrievePayoutMethod()
        {
            PaymentRails_Configuration.apiKey = "pk_live_91XNJFBD19ZQ6";
            String response = PaymentRails_PayoutMethods.get("R-91XPU407CRNGR");
            String message = response.Substring(6, 4);
            Assert.AreEqual("true", message);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        public void TestRetrievePayoutMethodInvalidAPIKey()
        {
            PaymentRails_Configuration.apiKey = "wdwd";
            String response = PaymentRails_PayoutMethods.get("R-91XPU407CRNGR");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        public void TestRetrievePayoutMethodInvalidRecipientId()
        {
            PaymentRails_Configuration.apiKey = "pk_live_91XNJFBD19ZQ6";
            String response = PaymentRails_PayoutMethods.get("R-wdwd");
        }

        [TestMethod]
        [Ignore]
        public void TestCreatePayoutMethod()
        {
            PaymentRails_Configuration.apiKey = "pk_live_91XNJFBD19ZQ6";
            String body = @"{""primary"": {""method"":""bank"", ""currency"": ""CAD""}, ""accounts"":{""bank"":{""country"":""CA"", ""accountNum"": ""6022847"", ""institution"": ""123"", ""branchNum"": ""47261"", ""currency"": ""CAD"", ""name"":""TD""}}}";
            String response = PaymentRails_PayoutMethods.post("R-91XPU407CRNGR",body);
            String message = response.Substring(6, 4);
            Assert.AreEqual("true", message);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        public void TestCreatePayoutMethodInvalidAPIKey()
        {
            PaymentRails_Configuration.apiKey = "wwddw";
            String body = @"{""primary"": {""method"":""bank"", ""currency"": ""CAD""}, ""accounts"":{""bank"":{""country"":""CA"", ""accountNum"": ""6022847"", ""institution"": ""123"", ""branchNum"": ""47261"", ""currency"": ""CAD"", ""name"":""TD""}}}";
            String response = PaymentRails_PayoutMethods.post("R-91XPU407CRNGR", body);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        public void TestCreatePayoutMethodRecipientId()
        {
            PaymentRails_Configuration.apiKey = "pk_live_91XNJFBD19ZQ6";
            String body = @"{""primary"": {""method"":""bank"", ""currency"": ""CAD""}, ""accounts"":{""bank"":{""country"":""CA"", ""accountNum"": ""6022847"", ""institution"": ""123"", ""branchNum"": ""47261"", ""currency"": ""CAD"", ""name"":""TD""}}}";
            String response = PaymentRails_PayoutMethods.post("R-wdwd", body);
        }
        [TestMethod]
        public void TestUpdatePayoutMethod()
        {
            PaymentRails_Configuration.apiKey = "pk_live_91XNJFBD19ZQ6";
            String body = @"{""primary"": {""method"":""paypal"", ""currency"": ""CAD""}, ""accounts"":{""paypal"": {""address"": ""testpaypal@example.com""}}}";
            String response = PaymentRails_PayoutMethods.patch("R-91XPU407CRNGR", body);
            String message = response.Substring(6, 4);
            Assert.AreEqual("true", message);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        public void TestUpdatePayoutMethodInvalidAPIKey()
        {
            PaymentRails_Configuration.apiKey = "wdwd";
            String body = @"{""primary"": {""method"":""paypal"", ""currency"": ""CAD""}, ""accounts"":{""paypal"": {""address"": ""testpaypal@example.com""}}}";
            String response = PaymentRails_PayoutMethods.patch("R-91XPU407CRNGR", body);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        public void TestUpdatePayoutMethodInvalidRecipientId()
        {
            PaymentRails_Configuration.apiKey = "pk_live_91XNJFBD19ZQ6";
            String body = @"{""primary"": {""method"":""paypal"", ""currency"": ""CAD""}, ""accounts"":{""paypal"": {""address"": ""testpaypal@example.com""}}}";
            String response = PaymentRails_PayoutMethods.patch("R-wdddw", body);
        }
    }
}