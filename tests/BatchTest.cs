using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trolley.Types;
using System.Collections.Generic;
using System;

namespace tests
{
    [TestClass]
    public class BatchTest
    {
        Trolley.Gateway gateway;

        [TestInitialize]
        public void Init()
        {
            Config config = new Config();
            gateway = new Trolley.Gateway(config.ACCESS_KEY, config.SECRET_KEY);
        }

        private Recipient createRecipient()
        {
            string uuid = Guid.NewGuid().ToString();
            Address address = new Address("123 Wolfstrasse", "Berlin", "DE", null, "123123");
            Recipient recipient = new Recipient();
            recipient.type = "individual";
            recipient.email = "test.create" + uuid + "@example.com";
            recipient.firstName = "Tom";
            recipient.lastName = "Jones";
            recipient.dob = "1990-01-01";
            recipient.address = address;
            recipient = gateway.recipient.Create(recipient);

            RecipientAccount recipientAccount = new RecipientAccount("bank-transfer", "CAD", null, true, "CA");
            recipientAccount.accountNum = "1234567";
            recipientAccount.bankId = "003";
            recipientAccount.branchId = "47261";
            recipientAccount = gateway.recipientAccount.create(recipient.id, recipientAccount);
            Assert.IsNotNull(recipientAccount);

            return recipient;
        }
        [TestMethod]
        public void testAll_smokeTest()
        {
            List<Batch> batches = gateway.batch.Search().batches;
            Assert.IsNotNull(batches);
        }
        [TestMethod]
        public void testCreate()
        {
            Batch batch = new Batch("Integration Test Create", null, Config.TEST_BALANCE_CURRENCY, 0);
            batch = gateway.batch.Create(batch);
            Assert.IsNotNull(batch);
            Assert.IsNotNull(batch.id);

            List<Batch> batches = gateway.batch.Search().batches;
            Assert.IsTrue(batches.Count > 0);
        }
        [TestMethod]
        public void testUpdate()
        {
            Batch batch = new Batch("Integration Test Create", null, Config.TEST_BALANCE_CURRENCY, 0);
            batch = gateway.batch.Create(batch);
            Assert.IsNotNull(batch);
            Assert.IsNotNull(batch.id);

            List<Batch> batches = gateway.batch.Search().batches;
            Assert.IsTrue(batches.Count > 0);

            Batch newBatch = new Batch("Integration Update", null, null, 0, 0, null, null, null, null, null, batch.id);
            bool response = gateway.batch.Update(newBatch);
            Assert.IsTrue(response);

            Batch findBatch = gateway.batch.Get(batch.id);

            Assert.AreEqual("Integration Update", findBatch.description);
            Assert.AreEqual("open", findBatch.status);

            response = gateway.batch.Delete(batch.id);
            Assert.IsTrue(response);

        }

        [TestMethod]
        public void testCreateWithPayments()
        {
            Recipient recipientAlpha = createRecipient();
            Recipient recipientBeta = createRecipient();
            Payment paymentAlpha = new Payment(recipientAlpha, 10.00, "EUR", 0, null, null);

            Payment paymentBeta = new Payment(recipientBeta, 10.00, "EUR", 0, null, null);
            List<Payment> payments = new List<Payment>();
            payments.Add(paymentAlpha);
            payments.Add(paymentBeta);

            Batch batch = new Batch("Integration Test Payments", payments, Config.TEST_BALANCE_CURRENCY, 0);
            batch = gateway.batch.Create(batch);

            Assert.IsNotNull(batch);
            Assert.IsNotNull(batch.id);

            Batch findBatch = gateway.batch.Get(batch.id);
            Assert.IsNotNull(findBatch);
            Assert.AreEqual(2, findBatch.payments.Count);

            List<Payment> findPayments = findBatch.payments;
            foreach (Payment payment in findPayments)
            {
                Assert.AreEqual("pending", payment.status);
            }
        }

        [TestMethod]
        public void testPayments()
        {

            Batch batch = new Batch("Integration Test Payments", null, Config.TEST_BALANCE_CURRENCY, 0);
            batch = gateway.batch.Create(batch);
            Assert.IsNotNull(batch);
            Assert.IsNotNull(batch.id);

            Recipient recipient = createRecipient();
            Payment payment = new Payment(recipient, 10.92, "EUR");
            payment.batchId = batch.id;
            payment = gateway.payment.Create(payment);

            Assert.IsNotNull(payment);
            Assert.IsNotNull(payment.id);
            Assert.AreEqual(payment.amount, 10.92);

            payment.sourceAmount = 20.00;
            payment.batchId = batch.id;

            bool response = gateway.payment.Update(payment);
            Assert.IsTrue(response);

            response = gateway.payment.Delete(payment);
            Assert.IsTrue(response);
        }

        [TestMethod]
        public void testProcessing()
        {
            Recipient recipientAlpha = createRecipient();
            Recipient recipientBeta = createRecipient();

            Payment paymentAlpha = new Payment(recipientAlpha, 10.00, "EUR", 0, null, null);
            Payment paymentBeta = new Payment(recipientBeta, 10.00, "EUR", 0, null, null);
            List<Payment> payments = new List<Payment>();
            payments.Add(paymentAlpha);
            payments.Add(paymentBeta);

            Batch batch = new Batch("Integration Test Payments", payments, Config.TEST_BALANCE_CURRENCY, 0);
            batch = gateway.batch.Create(batch);

            Batch quote = gateway.batch.GenerateQuote(batch.id);
            Assert.IsNotNull(quote);

            Batch start = gateway.batch.ProcessBatch(batch.id);
            Assert.IsNotNull(start);
        }

        [TestMethod]
        public void testFailure()
        {
            try
            {
                Batch batch = new Batch("Integration Test Payments", null, "MVR", 0);
                batch = gateway.batch.Create(batch);
            }
            catch (Exception e)
            {
                Assert.IsNotNull(e);
            }
        }

        [TestMethod]
        public void testGetAllPayments()
        {
            List<Payment> payments = gateway.payment.Search(new PaymentQueryParams()).payments;
            int itemCount = 0;
            foreach (Payment p in payments)
            {
                Assert.IsNotNull(p.id);
                itemCount++;
            }
            Assert.IsTrue(itemCount > 0);

        }

        [TestMethod]
        public void TestGetAllBatches()
        {
            List<Batch> batches = gateway.batch.ListAllBatches(null, 1, 10).batches;
            Assert.IsTrue(batches.Count > 0);

            var allBatches = gateway.batch.ListAllBatches(null);
            int itemCount = 0;
            foreach (Batch b in allBatches)
            {
                Assert.IsNotNull(b.id);
                itemCount++;
            }
            Assert.IsTrue(itemCount > 0);
        }

        [TestMethod]
        public void TestDeleteMultipleBatches()
        {
            Batch b1 = new Batch();
            b1.currency = "CAD";
            b1.description = "Batch 1 for .Net SDK Test : Delete Multiple";
            Batch batch1 = gateway.batch.Create(b1);
            Assert.IsNotNull(batch1.id);

            Batch b2 = new Batch();
            b2.currency = "CAD";
            b2.description = "Batch 2 for .Net SDK Test : Delete Multiple";
            Batch batch2 = gateway.batch.Create(b1);
            Assert.IsNotNull(batch2.id);

            bool deleteResult = gateway.batch.Delete(batch1.id, batch2.id);
            Assert.IsTrue(deleteResult);
            
        }
    }
}
