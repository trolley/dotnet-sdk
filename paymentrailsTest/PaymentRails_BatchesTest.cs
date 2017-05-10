﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using paymentrails;
using paymentrails.Exceptions;
using paymentrails.Types;

namespace paymentrailsTest
{
    [TestClass]
    public class PaymentRails_BatchesTest
    {
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            PaymentRails_Client.HttpMessageHandler = new MockHttpHandler();
        }
        [TestMethod]
        public void TestRetrieveBatch()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            Batch response = PaymentRails_Batch.get("B-91XPR9A29NMMC");
            Assert.AreEqual("true", response);
        }
        //        [TestMethod]
        //        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        //        public void TestRetrieveBatchInvalidAPIKey()
        //        {
        //            PaymentRails_Configuration.ApiKey = "wdwd";
        //            String response = PaymentRails_Batch.get("B-91XPR9A29NMMC");

        //        }
        //        [TestMethod]
        //        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        //        public void TestRetrieveBatchInvalidBatchId()
        //        {
        //            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
        //            String response = PaymentRails_Batch.get("B-ssdsd");

        //        }
        //        [TestMethod]
        //        public void TestUpdateBatch()
        //        {
        //            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
        //            String body = @"{""update_payments"":[{""id"":""P-908GUDK2FHQGR"",""sourceAmount"":999}]}";
        //            String response = PaymentRails_Batch.patch("B-91XPR9A29NMMC",body);
        //            String message = response.Substring(6, 4);
        //            Assert.AreEqual("true", message);
        //        }
        //        [TestMethod]
        //        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        //        public void TestUpdateBatchInvalidAPIKey()
        //        {
        //            PaymentRails_Configuration.ApiKey = "wdwddw";
        //            String body = @"{""update_payments"":[{""id"":""P-908GUDK2FHQGR"",""sourceAmount"":999}]}";
        //            String response = PaymentRails_Batch.patch("B-91XPR9A29NMMC", body);
        //        }
        //        [TestMethod]
        //        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        //        public void TestUpdateBatchInvalidBatchId()
        //        {
        //            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
        //            String body = @"{""update_payments"":[{""id"":""P-908GUDK2FHQGR"",""sourceAmount"":999}]}";
        //            String response = PaymentRails_Batch.patch("B-wdwdwd", body);
        //        }
        //        [TestMethod]
        //        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        //        public void TestUpdateBatchInvalidPaymentAmount()
        //        {
        //            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
        //            String body = @"{""update_payments"":[{""id"":""P-908GUDK2FHQGR"",""sourceAmount"":9.9}]}";
        //            String response = PaymentRails_Batch.patch("B-91XPR9A29NMMC", body);
        //        }
        //        [TestMethod]
        //        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        //        public void TestUpdateBatchInvalidFieldName()
        //        {
        //            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
        //            String body = @"{""update_payments"":[{""idss"":""P-908GUDK2FHQGR"",""sourceAmount"":999}]}";
        //            String response = PaymentRails_Batch.patch("B-91XPR9A29NMMC", body);
        //        }

        //        [TestMethod]
        //        [Ignore]
        //        public void TestDeleteBatch()
        //        {
        //            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
        //             String response = PaymentRails_Batch.delete("B-91XPR9A29NMMC");
        //            String message = response.Substring(6, 4);
        //            Assert.AreEqual("true", message);
        //        }
        //        [TestMethod]
        //        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        //        public void TestDeleteBatchInvalidAPIKey()
        //        {
        //            PaymentRails_Configuration.ApiKey = "wdwd";
        //            String response = PaymentRails_Batch.delete("B-91XPR9A29NMMC");
        //        }
        //        [TestMethod]
        //        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        //        public void TestDeleteBatchInvalidBatchId()
        //        {
        //            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
        //            String response = PaymentRails_Batch.delete("B-wd");
        //        }
        //        [TestMethod]
        //        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        //        public void TestDeleteBatchInvalidBatchStatus()
        //        {
        //            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
        //            String response = PaymentRails_Batch.delete("B-912Q011VA8V2C");
        //        }

        //        [TestMethod]
        //        public void TestListAllBatches()
        //        {
        //            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
        //            String response = PaymentRails_Batch.query();
        //            String message = response.Substring(6, 4);
        //            Assert.AreEqual("true", message);
        //        }
        //        [TestMethod]
        //        public void TestListAllBatchesWithQueries()
        //        {
        //            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
        //            String response = PaymentRails_Batch.query();
        //            String message = response.Substring(6, 4);
        //            Assert.AreEqual("true", message);
        //        }
        //        [TestMethod]
        //        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        //        public void TestListAllBatchesInvalidAPIKey()
        //        {
        //            PaymentRails_Configuration.ApiKey = "dwdwwd";
        //            String response = PaymentRails_Batch.query();
        //        }

        //        [TestMethod]
        //        public void TestListAllBatchSummary()
        //        {
        //            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
        //            String response = PaymentRails_Batch.summary("B-91XPR9A29NMMC");
        //            String message = response.Substring(6, 4);
        //            Assert.AreEqual("true", message);
        //        }

        //        [TestMethod]
        //        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        //        public void TestListAllBatchSummaryInvalidBatchId()
        //        {
        //            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
        //            String response = PaymentRails_Batch.summary("B-wddw");
        //        }
        //        [TestMethod]
        //        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        //        public void TestListAllBatchSummaryInvalidAPIKey()
        //        {
        //            PaymentRails_Configuration.ApiKey = "wddwdw";
        //            String response = PaymentRails_Batch.summary("B-91XPR9A29NMMC");
        //        }

        //        [TestMethod]
        //        [Ignore]
        //        public void TestCreateBatch()
        //        {
        //            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
        //            String body = @"{""payments"":[{""recipient"":{""id"":""R-91XPJZTR612MG""},""sourceAmount"":""65"",""memo"":"""",""sourceCurrency"":""CAD""}]}";
        //            String response = PaymentRails_Batch.post(body);
        //            String batch_id = response.Substring(26,15);

        //            response = PaymentRails_Batch.generateQuote(batch_id);

        //            response = PaymentRails_Batch.processBatch(batch_id);

        //            String message = response.Substring(6, 4);
        //            Assert.AreEqual("true", message);

        //        }
        //        [TestMethod]
        //        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        //        public void testCreateBatchInvalidAPIKey()
        //        {
        //            PaymentRails_Configuration.ApiKey = "efeff";
        //            String body = @"{""payments"":[{""recipient"":{""id"":""R-91XPJZTR612MG""},""sourceAmount"":""65"",""memo"":"""",""sourceCurrency"":""CAD""}]}";
        //            String response = PaymentRails_Batch.post(body);
        //        }

        //        [TestMethod]
        //        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        //        public void testCreateBatchInvalilField()
        //        {
        //            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
        //            String body = @"{""payments"":[{""recipient"":{""iwdwdd"":""R-91XPJZTR612MG""},""sourceAmount"":""65"",""memo"":"""",""sourceCurrency"":""CAD""}]}";
        //            String response = PaymentRails_Batch.post(body);
        //        }
        //        [TestMethod]
        //        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        //        public void testCreateBatchInvalidRecipientIdy()
        //        {
        //            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
        //            String body = @"{""payments"":[{""recipient"":{""id"":""R-wdwd""},""sourceAmount"":""65"",""memo"":"""",""sourceCurrency"":""CAD""}]}";
        //            String response = PaymentRails_Batch.post(body);
        //        }
    }
}
