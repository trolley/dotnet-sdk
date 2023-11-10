using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trolley.Types;
using System;
using System.Collections.Generic;

namespace tests
{
    [TestClass]
    public class PaymentTest
    {

        private TestContext testContextInstance;

        Trolley.Gateway trolley;

        [TestInitialize]
        public void Init()
        {
            Config config = new Config();
            trolley = new Trolley.Gateway(config.ACCESS_KEY, config.SECRET_KEY);
        }

        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod]
        public void Smoke()
        {
            List<Payment> payments = trolley.payment.Search().payments;
            Assert.IsTrue(payments.Count > 0);
        }

        [TestMethod]
        public void testFindBatchPayments()
        {
            List<Batch> batches = trolley.batch.Search().batches;
            
            Batch batch = batches.Find(x => x.totalPayments > 0);
            List<Payment> payments1 = trolley.payment.Search(batch.id).payments;
            Assert.IsTrue(payments1.Count > 0);

            List<Payment> payments2 = trolley.payment.Search("", 1, 10, batch.id).payments;
            Assert.IsTrue(payments2.Count > 0);
        }

        [TestMethod]
        public void testCreatePayments()
        {
            //Prepare - Create recipient
            string uuid = System.Guid.NewGuid().ToString();
            Recipient recipient = new Recipient("individual", "test.create" + uuid + "@example.com", null, "Tom", "Jones", null, null, null, null, null, "1990-01-01");
            recipient = trolley.recipient.Create(recipient);
            Assert.IsNotNull(recipient);

            //Prepare - Create Recipient Account
            RecipientAccount recipientAccount = new RecipientAccount("bank-transfer", "CAD", null, true, "CA");
            recipientAccount.accountNum = "1234567";
            recipientAccount.bankId = "003";
            recipientAccount.branchId = "47261";
            recipientAccount = trolley.recipientAccount.create(recipient.id, recipientAccount);
            Assert.IsNotNull(recipientAccount);

            //Prepare - Create batch
            Batch batch = new Batch("Integration Test Create", null, "USD", 0);
            batch = trolley.batch.Create(batch);
            Assert.IsNotNull(batch);

            //Create Payment
            Payment payment = new Payment(recipient, 1.20, "USD");
            payment.batchId = batch.id;
            payment = trolley.payment.Create(payment);
            Assert.IsNotNull(payment);

            //Cleanup - Delete Recipient
            Boolean deleteResult = trolley.recipient.Delete(recipient.id);
            Assert.IsTrue(deleteResult);


            //Cleanup - Delete Batch
            deleteResult = trolley.batch.Delete(batch.id);
            Assert.IsTrue(deleteResult);
        }

        [TestMethod]
        public void testOldPaymentsSearch()
        {
            List<Payment> payments = trolley.payment.Search("", 1, 5).payments;
            Assert.AreEqual(5, payments.Count);
        }

        [TestMethod]
        public void testSearchFailed()
        {
            List<string> status = new List<string>();
            status.Add("failed");

            PaymentQueryParams queryParams = new PaymentQueryParams { status = status };
            List<Payment> payments = trolley.payment.Search(queryParams).payments;

            Assert.IsTrue(payments.Count > 0);
            Assert.IsFalse(payments.Exists(x => x.status != "failed"));
        }

        [TestMethod]
        public void testBuildQueryString()
        {
            List<string> status = new List<string>();
            status.Add("failed");
            status.Add("returned");


            PaymentQueryParams queryParams1 = new PaymentQueryParams { page = 1, pageSize = 10 };
            Assert.AreEqual("page=1&pageSize=10", queryParams1.buildQueryString());

            PaymentQueryParams queryParams2 = new PaymentQueryParams { page = 1, pageSize = 10, term = "yo" };
            Assert.AreEqual("page=1&pageSize=10&term=yo", queryParams2.buildQueryString());

            PaymentQueryParams queryParams3 = new PaymentQueryParams { term = "yo" };
            Assert.AreEqual("page=1&pageSize=10&term=yo", queryParams3.buildQueryString());

            PaymentQueryParams queryParams4 = new PaymentQueryParams { status = status };
            Assert.AreEqual("page=1&pageSize=10&status=failed,returned", queryParams4.buildQueryString());

        }

        [TestMethod]
        public void testFetchAllPayments()
        {
            var allPayments = trolley.payment.ListAllPayments();
            int itemCount = 0;
            foreach (Payment payment in allPayments)
            {
                Assert.IsNotNull(payment.id);
                itemCount++;
            }
            Assert.IsTrue(itemCount > 0);
        }

    }
}
