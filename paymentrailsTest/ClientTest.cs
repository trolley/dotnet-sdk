using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using paymentrails;
using paymentrails.Exceptions;
using paymentrails.Types;

namespace paymentrailsTest
{
    [TestClass]
    public class ClientTest
    {
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            PaymentRails_Client.HttpMessageHandler = new MockHttpHandlerForClientTests();
        }

        [TestMethod]
        public void TestValidGetRequest()
        {
            PaymentRails_Configuration.ApiKey = "pk_GOODAPIKEY";
            String validResponse = PaymentRails_Client.ClientInstance.get("/validEndpointTest");
            Assert.AreEqual(MockResponseContent.VALID_POST, validResponse);
        }

        [TestMethod]
        public void TestValidPostRequest()
        {
            PaymentRails_Configuration.ApiKey = "pk_GOODAPIKEY";
            String validResponse = PaymentRails_Client.ClientInstance.post("/validEndpointTest", new MockMappable());
            Assert.AreEqual(MockResponseContent.VALID_POST, validResponse);
        }

        [TestMethod]
        public void TestValidPatchRequest()
        {
            PaymentRails_Configuration.ApiKey = "pk_GOODAPIKEY";
            String validResponse = PaymentRails_Client.ClientInstance.patch("/validEndpointTest", new MockMappable());
            Assert.AreEqual(MockResponseContent.VALID_POST, validResponse);
        }

        [TestMethod]
        public void TestValidDeleteRequest()
        {
            PaymentRails_Configuration.ApiKey = "pk_GOODAPIKEY";
            String validResponse = PaymentRails_Client.ClientInstance.delete("/validEndpointTest");
            Assert.AreEqual(MockResponseContent.VALID_POST, validResponse);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStatusCodeException), "A different exception was thrown")]
        public void TestUnauthorisedRequestGet()
        {
            PaymentRails_Configuration.ApiKey = "BADAPIKEY";
            try
            {
                PaymentRails_Client.ClientInstance.get("/invalidapikey");
            }
            catch (InvalidStatusCodeException e)
            {
                Assert.AreEqual(MockResponseContent.INVALID_UNAUTHORISED, e.Message);
                throw e;
            }

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStatusCodeException), "A different exception was thrown")]
        public void TestUnauthorisedRequestPost()
        {
            PaymentRails_Configuration.ApiKey = "BADAPIKEY";
            try
            {
                PaymentRails_Client.ClientInstance.post("/invalidapikey", new MockMappable());
            }
            catch (InvalidStatusCodeException e)
            {
                Assert.AreEqual(MockResponseContent.INVALID_UNAUTHORISED, e.Message);
                throw e;
            }

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStatusCodeException), "A different exception was thrown")]
        public void TestUnauthorisedRequestPatch()
        {
            PaymentRails_Configuration.ApiKey = "BADAPIKEY";
            try
            {
                PaymentRails_Client.ClientInstance.patch("/invalidapikey", new MockMappable());
            }
            catch (InvalidStatusCodeException e)
            {
                Assert.AreEqual(MockResponseContent.INVALID_UNAUTHORISED, e.Message);
                throw e;
            }

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStatusCodeException), "A different exception was thrown")]
        public void TestUnauthorisedRequestDelete()
        {
            PaymentRails_Configuration.ApiKey = "BADAPIKEY";
            try
            {
                PaymentRails_Client.ClientInstance.post("/invalidapikey", new MockMappable());
            }
            catch (InvalidStatusCodeException e)
            {
                Assert.AreEqual(MockResponseContent.INVALID_UNAUTHORISED, e.Message);
                throw e;
            }

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStatusCodeException), "A different exception was thrown")]
        public void TestBadRequestPost()
        {
            PaymentRails_Configuration.ApiKey = "PK_GOOD";
            try
            {
                PaymentRails_Client.ClientInstance.post("/invalid", new MockMappable());
            }
            catch (InvalidStatusCodeException e)
            {
                Assert.AreEqual(MockResponseContent.INVALID_BAD_DATA, e.Message);
                throw e;
            }

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStatusCodeException), "A different exception was thrown")]
        public void TestBadRequestPatch()
        {
            PaymentRails_Configuration.ApiKey = "PK_GOOD";
            try
            {
                PaymentRails_Client.ClientInstance.patch("/invalid", new MockMappable());
            }
            catch (InvalidStatusCodeException e)
            {
                Assert.AreEqual(MockResponseContent.INVALID_BAD_DATA, e.Message);
                throw e;
            }

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStatusCodeException), "A different exception was thrown")]
        public void TestBadRequestDelete()
        {
            PaymentRails_Configuration.ApiKey = "PK_GOOD";
            try
            {
                PaymentRails_Client.ClientInstance.delete("/invalid");
            }
            catch (InvalidStatusCodeException e)
            {
                Assert.AreEqual(MockResponseContent.INVALID_BAD_DATA, e.Message);
                throw e;
            }

        }

        private class MockMappable : paymentrails.Types.IPaymentRailsMappable
        {
            public bool IsMappable()
            {
                return true;
            }

            public string ToJson()
            {
                return "";
            }
        }
    }
}
