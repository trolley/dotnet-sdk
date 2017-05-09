using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using paymentrails;
using paymentrails.Exceptions;
using paymentrails.Types;

namespace paymentrailsTest
{
    [TestClass]
    public class PaymentRails_PaymentTest
    { 

        //[ClassInitialize]
        //public void init()
        //{
        //    PaymentRails_Client.ResetClient(new MockHttpHandler());
        //}
        [TestInitialize]
        public void init()
        {
            PaymentRails_Client.HttpMessageHandler = new MockHttpHandler();
        }

        [TestMethod]
        public void TestRetrievePayment()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            Payment response = PaymentRails_Payment.get("P-91XPU88Q5GN2E");
            String message = "";
            Assert.AreEqual("true", message);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        public void TestRetrievePaymentInvalidAPIKey()
        {
            PaymentRails_Configuration.ApiKey = "effe";
            Payment response = PaymentRails_Payment.get("P-91XPU88Q5GN2E");
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        public void TestRetrievePaymentInvalidBatchId()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            Payment response = PaymentRails_Payment.get("P-91XPU88Q5GN2E");
        }
        //[TestMethod]
        //[ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        //public void TestRetrievePaymentInvalidPaymentId()
        //{
        //    PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
        //    PaymentRails_Payment.batchId = "B-91XPU88Q093HW";
        //    String response = PaymentRails_Payment.get("P-wddw");
        //}
        //[TestMethod]
        //[Ignore]
        //public void TestCreatePayment()
        //{
        //    PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
        //    PaymentRails_Payment.batchId = "B-91XPU88Q093HW";
        //    String body = @"{""recipient"":{""id"":""R-91XPJZTR612MG""},""sourceAmount"":""100.10"",""memo"":""Freelance payment""}";
        //    String response = PaymentRails_Payment.post(body);
        //    String message = response.Substring(6, 4);
        //    Assert.AreEqual("true", message);
        //}
        //[TestMethod]
        //[ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        //public void TestCreatePaymentInvalidAPIKey()
        //{
        //    PaymentRails_Configuration.ApiKey = "wddw";
        //    PaymentRails_Payment.batchId = "B-91XPU88Q093HW";
        //    String body = @"{""recipient"":{""id"":""R-91XPJZTR612MG""},""sourceAmount"":""100.10"",""memo"":""Freelance payment""}";
        //    String response = PaymentRails_Payment.post(body);
        //}
        //[TestMethod]
        //[ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        //public void TestCreatePaymentInvalidBatchId()
        //{
        //    PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
        //    PaymentRails_Payment.batchId = "B-wddw";
        //    String body = @"{""recipient"":{""id"":""R-91XPJZTR612MG""},""sourceAmount"":""100.10"",""memo"":""Freelance payment""}";
        //    String response = PaymentRails_Payment.post(body);
        //}
        //[TestMethod]
        //[ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        //public void TestCreatePaymentInvalidRecipientId()
        //{
        //    PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
        //    PaymentRails_Payment.batchId = "B-91XPU88Q093HW";
        //    String body = @"{""recipient"":{""id"":""R-wdwd""},""sourceAmount"":""100.10"",""memo"":""Freelance payment""}";
        //    String response = PaymentRails_Payment.post(body);
        //}
        //[TestMethod]
        //[ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        //public void TestCreatePaymentFieldName()
        //{
        //    PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
        //    PaymentRails_Payment.batchId = "B-91XPU88Q093HW";
        //    String body = @"{""reciwdpient"":{""id"":""R-91XPJZTR612MG""},""sourceAmount"":""100.10"",""memo"":""Freelance payment""}";
        //    String response = PaymentRails_Payment.post(body);
        //}
        //[TestMethod]
        //public void TestUpdatePayment()
        //{
        //    PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
        //    PaymentRails_Payment.batchId = "B-91XPU88Q093HW";
        //    String body = @"{""sourceAmount"":""900.90""}";
        //    String response = PaymentRails_Payment.patch("P-91XPU88Q5GN2E",body);
        //    String message = response.Substring(6, 4);
        //    Assert.AreEqual("true", message);
        //}
        //[TestMethod]
        //[ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        //public void TestUpdatePaymentInvalidAPIKey()
        //{
        //    PaymentRails_Configuration.ApiKey = "wdwd";
        //    PaymentRails_Payment.batchId = "B-91XPU88Q093HW";
        //    String body = @"{""sourceAmount"":""900.90""}";
        //    String response = PaymentRails_Payment.patch("P-91XPU88Q5GN2E", body);
        //}
        //[TestMethod]
        //[ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        //public void TestUpdatePaymentInvalidBatchId()
        //{
        //    PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
        //    PaymentRails_Payment.batchId = "B-wdwd";
        //    String body = @"{""sourceAmount"":""900.90""}";
        //    String response = PaymentRails_Payment.patch("P-91XPU88Q5GN2E", body);
        //}
        //[TestMethod]
        //[ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        //public void TestUpdatePaymentInvalidPaymentId()
        //{
        //    PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
        //    PaymentRails_Payment.batchId = "B-91XPU88Q093HW";
        //    String body = @"{""sourceAmount"":""900.90""}";
        //    String response = PaymentRails_Payment.patch("P-dwdw", body);
        //}
        //[TestMethod]
        //[ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        //public void TestUpdatePaymentInvalidPaymentStatus()
        //{
        //    PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
        //    PaymentRails_Payment.batchId = "B-912Q011VA8V2C";
        //    String body = @"{""sourceAmount"":""900.90""}";
        //    String response = PaymentRails_Payment.patch("P-91XPR9BAA054P", body);
        //}
        //[TestMethod]
        //[ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        //public void TestUpdatePaymentInvalidSourceAmount()
        //{
        //    PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
        //    PaymentRails_Payment.batchId = "B-91XPU88Q093HW";
        //    String body = @"{""sourceAmount"":""9.9""}";
        //    String response = PaymentRails_Payment.patch("P-91XPU88Q5GN2E", body);
        //}
        //[TestMethod]
        //[Ignore]
        //public void TestDeletePayment()
        //{
        //    PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
        //    PaymentRails_Payment.batchId = "B-91XPU88Q093HW";
        //    String response = PaymentRails_Payment.delete("P-91XPU8HZ7N664");
        //    String message = response.Substring(6, 4);
        //    Assert.AreEqual("true", message);
        //}
        //[TestMethod]
        //[ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        //public void TestDeletePaymentInvalidAPIKey()
        //{
        //    PaymentRails_Configuration.ApiKey = "dwd";
        //    PaymentRails_Payment.batchId = "B-91XPU88Q093HW";
        //    String response = PaymentRails_Payment.delete("P-91XPU8HZ7N664");
        //}
        //[TestMethod]
        //[ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        //public void TestDeletePaymentInvalidBatchId()
        //{
        //    PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
        //    PaymentRails_Payment.batchId = "B-wdwd";
        //    String response = PaymentRails_Payment.delete("P-91XPU8HZ7N664");
        //}
        //[TestMethod]
        //[ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        //public void TestDeletePaymentInvalidPaymentId()
        //{
        //    PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
        //    PaymentRails_Payment.batchId = "B-91XPU88Q093HW";
        //    String response = PaymentRails_Payment.delete("P-dd");
        //}

        //[TestMethod]
        //public void TestListAllPayment()
        //{
        //    PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
        //    PaymentRails_Payment.batchId = "B-91XPU88Q093HW";
        //    String response = PaymentRails_Payment.query();
        //    String message = response.Substring(6, 4);
        //    Assert.AreEqual("true", message);
        //}
        //[TestMethod]
        //public void TestListAllPaymentWithQueries()
        //{
        //    PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
        //    PaymentRails_Payment.batchId = "B-91XPU88Q093HW";
        //    String response = PaymentRails_Payment.query("",1,10);
        //    String message = response.Substring(6, 4);
        //    Assert.AreEqual("true", message);
        //}
        //[TestMethod]
        //[ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        //public void TestListAllPaymentInvalidAPIKey()
        //{
        //    PaymentRails_Configuration.ApiKey = "wdw";
        //    PaymentRails_Payment.batchId = "B-91XPU88Q093HW";
        //    String response = PaymentRails_Payment.query();
        //}
        //[TestMethod]
        //[ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        //public void TestListAllPaymentInvalidBatchId()
        //{
        //    PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
        //    PaymentRails_Payment.batchId = "B-wdwd";
        //    String response = PaymentRails_Payment.query();
        //}
    }
}
