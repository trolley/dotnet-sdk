using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentRails.Types;
using System;
using System.Collections.Generic;

namespace tests
{
    [TestClass]
    public class PaymentTest
    {

        private TestContext testContextInstance;

        PaymentRails.Gateway paymentrails;

        [TestInitialize]
        public void Init()
        {
            paymentrails = new PaymentRails.Gateway(Config.TEST_API_KEY, Config.TEST_API_SECRET);
        }

        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod]
        public void Smoke()
        {
            List<Payment> payments = paymentrails.payment.search();
            Assert.IsTrue(payments.Count > 0);
        }

        [TestMethod]
        public void testFindBatchPayments()
        {
            List<Batch> batches = paymentrails.batch.search();
            
            Batch batch = batches.Find(x => x.totalPayments > 0);
            List<Payment> payments1 = paymentrails.payment.search(batch.id);
            Assert.IsTrue(payments1.Count > 0);

            List<Payment> payments2 = paymentrails.payment.search("", 1, 10, batch.id);
            Assert.IsTrue(payments2.Count > 0);
        }

        [TestMethod]
        public void testCreatePayments()
        {
            //Prepare - Create recipient
            string uuid = System.Guid.NewGuid().ToString();
            Recipient recipient = new Recipient("individual", "test.create" + uuid + "@example.com", null, "Tom", "Jones", null, null, null, null, null, "1990-01-01");
            recipient = paymentrails.recipient.create(recipient);
            Assert.IsNotNull(recipient);

            //Prepare - Create Recipient Account
            RecipientAccount recipientAccount = new RecipientAccount("bank-transfer", "CAD", null, true, "CA");
            recipientAccount.accountNum = "1234567";
            recipientAccount.bankId = "003";
            recipientAccount.branchId = "47261";
            recipientAccount = paymentrails.recipientAccount.create(recipient.id, recipientAccount);
            Assert.IsNotNull(recipientAccount);

            //Prepare - Create batch
            Batch batch = new Batch("Integration Test Create", null, "USD", 0);
            batch = paymentrails.batch.create(batch);
            Assert.IsNotNull(batch);

            //Create Payment
            Payment payment = new Payment(recipient, 1.20, "USD");
            payment.batchId = batch.id;
            payment = paymentrails.payment.create(payment);
            Assert.IsNotNull(payment);

            //Cleanup - Delete Recipient
            Boolean deleteResult = paymentrails.recipient.delete(recipient.id);
            Assert.IsTrue(deleteResult);


            //Cleanup - Delete Batch
            deleteResult = paymentrails.batch.delete(batch.id);
            Assert.IsTrue(deleteResult);
        }

        [TestMethod]
        public void testOldPaymentsSearch()
        {
            List<Payment> payments = paymentrails.payment.search("", 1, 5);
            Assert.AreEqual(5, payments.Count);
        }

        [TestMethod]
        public void testSearchFailed()
        {
            List<string> status = new List<string>();
            status.Add("failed");

            PaymentQueryParams queryParams = new PaymentQueryParams { status = status };
            List<Payment> payments = paymentrails.payment.search(queryParams);

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

    }
}
