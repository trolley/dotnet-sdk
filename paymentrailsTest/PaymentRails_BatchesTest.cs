using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentRails;
using PaymentRails.Exceptions;
using PaymentRails.Types;

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
            Assert.AreEqual(ValidResponseData.VALID_BATCH, response);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        public void TestRetrieveBatchNotFound()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            try
            {
                Batch response = PaymentRails_Batch.get("ssdsd");
            }
            catch(InvalidStatusCodeException e)
            {
                Assert.AreEqual(MockResponseContent.INVALID_NOT_FOUND, e.Message);
                throw e;
            }
            

        }
        [TestMethod]
        public void TestUpdateBatch()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            Batch b = new Batch("VALID", null, "CAD", 0, 0, null, null, null, null, null, "B-VALIDBATCH");
            string result = PaymentRails_Batch.patch(b); // change to use batch that is returned
            Assert.AreEqual(MockResponseContent.VALID_POST, result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        public void TestUpdateBatchNotFound()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            Batch b = new Batch("VALID", null, "CAD", 0, 0, null, null, null, null, null, null);
            b.Id = "NOTVALID";
            try
            {
                string response = PaymentRails_Batch.patch(b);
            }
            catch (InvalidStatusCodeException e)
            {
                Assert.AreEqual(MockResponseContent.INVALID_NOT_FOUND, e.Message);
                throw e;
            }
        }

        [TestMethod]
        public void TestDeleteBatch()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            String response = PaymentRails_Batch.delete("B-91XPR9A29NMMC");
            String message = response.Substring(6, 4);
            Assert.AreEqual("true", message);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        public void TestDeleteBatchNotFound()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            Batch b = new Batch("INVALID", null, "CAD", 0, 0, null, null, null, null, null, "INVALID ID");
            try
            {
                string response = PaymentRails_Batch.delete(b);
            }
            catch (InvalidStatusCodeException e)
            {
                Assert.AreEqual(MockResponseContent.INVALID_NOT_FOUND, e.Message);
                throw e;
            }
        }
        //        [TestMethod]
        //        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        //        public void TestDeleteBatchInvalidBatchStatus()
        //        {
        //            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
        //            String response = PaymentRails_Batch.delete("B-912Q011VA8V2C");
        //        }

        [TestMethod]
        public void TestListAllBatches()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            List<Batch> response = PaymentRails_Batch.get(1,1);
            Assert.IsTrue(ValidResponseData.VALID_BATCH_LIST.SequenceEqual(response));
        }
        [TestMethod]
        public void TestListAllBatchesWithQueries()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            List<Batch> response = PaymentRails_Batch.query("",1,1);
            Assert.IsTrue(ValidResponseData.VALID_BATCH_LIST.SequenceEqual(response));
        }

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

        [TestMethod]
        public void TestCreateBatch()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            Batch batch = new Batch("VALID", null, "CAD", 0, 0, null, null, null, null, null, null);
            Batch result = PaymentRails_Batch.post(batch);
            Assert.AreEqual(ValidResponseData.VALID_BATCH, result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStatusCodeException), "Status code must be 200.")]
        public void testCreateBatchBadData()
        {
            PaymentRails_Configuration.ApiKey = "pk_live_91XNJFBD19ZQ6";
            Batch batch = new Batch("INVALID", null, "CAD", 0, 0, null, null, null, null, null, null);
            try
            {
                Batch response = PaymentRails_Batch.post(batch);
            }
            catch(InvalidStatusCodeException e)
            {
                Assert.AreEqual(MockResponseContent.INVALID_BAD_DATA, e.Message);
                throw e;
            }
        }
    }
}
