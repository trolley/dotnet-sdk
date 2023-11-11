using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trolley.Types;
using System;
using System.Collections.Generic;

namespace tests
{
    [TestClass]
    public class OfflinePaymentTest
    {

        private TestContext testContextInstance;

        Trolley.Gateway gateway;

        [TestInitialize]
        public void Init()
        {
            Config config = new Config();
            gateway = new Trolley.Gateway(config.ACCESS_KEY, config.SECRET_KEY);
        }

        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod]
        public void TestLifecycle()
        {
            //Prepare - Create recipient
            string uuid = System.Guid.NewGuid().ToString();
            Recipient recipient = new Recipient("individual", "test.create" + uuid + "@example.com", null, "Tom", "Jones", null, null, null, null, null, "1990-01-01");
            recipient = gateway.recipient.Create(recipient);
            Assert.IsNotNull(recipient.id);

            //Test - Create Offline Payment
            OfflinePayment opRequest = new OfflinePayment();
            opRequest.amount = 20;
            opRequest.currency = "CAD";
            opRequest.memo = ".Net SDK Integration Test";
            OfflinePayment opResponse = gateway.offlinePayment.Create(recipient.id, opRequest);
            Assert.IsNotNull(opResponse.id);

            //Test - Update an offline payment
            opRequest.amount = 50;
            bool updateResult = gateway.offlinePayment.Update(recipient.id, opResponse.id, opRequest);
            Assert.IsTrue(updateResult);

            //Test - Delete an offline payment
            bool delResult = gateway.offlinePayment.Delete(recipient.id, opResponse.id);
            Assert.IsTrue(delResult);

            //Test - List all offline payments
            List<OfflinePayment> offlinePayments = gateway.offlinePayment.ListAllOfflinePayments(null, 1, 10).offlinePayments;
            Assert.IsTrue(offlinePayments.Count > 0);

            var op = gateway.offlinePayment.ListAllOfflinePayments(null);
            int itemCount = 0;
            foreach (OfflinePayment offlinePayment in op)
            {
                Assert.IsNotNull(offlinePayment.id);
                itemCount++;
            }
            Assert.IsTrue(itemCount > 0);

            //Cleanup - Delete Recipient
            Boolean deleteResult = gateway.recipient.Delete(recipient.id);
            Assert.IsTrue(deleteResult);
        }
    }
}
