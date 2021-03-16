using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentRails.Types;
using System.Collections.Generic;
using System;

namespace tests
{
    [TestClass]
    public class BatchTest
    {
        PaymentRails.Gateway gateway;

        [TestInitialize]
        public void Init()
        {
            gateway = new PaymentRails.Gateway(Config.TEST_API_KEY, Config.TEST_API_SECRET);
        }

        private Recipient createRecipient()
        {
            string uuid = Guid.NewGuid().ToString();
            Address address = new Address("123 Wolfstrasse", "Berlin", "DE", null, "123123");
            Recipient recipient = new Recipient("individual", "test.create" + uuid + "@example.com", null, "Tom", "Jones", null, null, null, null, null, "1990-01-01", null, null, null, address);
            recipient = gateway.recipient.create(recipient);

            RecipientAccount recipientAccount = new RecipientAccount("bank-transfer", "EUR", null, true, "DE", "DE89 3704 0044 0532 0130 00", "123456");
            recipientAccount = gateway.recipientAccount.create(recipient.id, recipientAccount);

            return recipient;
        }
        [TestMethod]
        public void testAll_smokeTest()
        {
            List<Batch> batches = gateway.batch.search();
            Assert.IsNotNull(batches);
        }
        [TestMethod]
        public void testCreate()
        {
            Batch batch = new Batch("Integration Test Create", null, Config.TEST_BALANCE_CURRENCY, 0);
            batch = gateway.batch.create(batch);
            Assert.IsNotNull(batch);
            Assert.IsNotNull(batch.id);

            List<Batch> batches = gateway.batch.search();
            Assert.IsTrue(batches.Count > 0);
        }
        [TestMethod]
        public void testUpdate()
        {
            Batch batch = new Batch("Integration Test Create", null, Config.TEST_BALANCE_CURRENCY, 0);
            batch = gateway.batch.create(batch);
            Assert.IsNotNull(batch);
            Assert.IsNotNull(batch.id);

            List<Batch> batches = gateway.batch.search();
            Assert.IsTrue(batches.Count > 0);

            Batch newBatch = new Batch("Integration Update", null, null, 0, 0, null, null, null, null, null, batch.id);
            bool response = gateway.batch.update(newBatch);
            Assert.IsTrue(response);

            Batch findBatch = gateway.batch.find(batch.id);

            Assert.AreEqual("Integration Update", findBatch.description);
            Assert.AreEqual("open", findBatch.status);

            response = gateway.batch.delete(batch.id);
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
            batch = gateway.batch.create(batch);


            Assert.IsNotNull(batch);
            Assert.IsNotNull(batch.id);

            Batch findBatch = gateway.batch.find(batch.id);
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
            batch = gateway.batch.create(batch);
            Assert.IsNotNull(batch);
            Assert.IsNotNull(batch.id);

            Recipient recipient = createRecipient();
            Payment payment = new Payment(recipient, 10.00, "EUR", 0, null, null);
            payment.batchId = batch.id;
            payment = gateway.payment.create(payment);

            Assert.IsNotNull(payment);
            Assert.IsNotNull(payment.id);

            payment.sourceAmount = 20.00;
            payment.batchId = batch.id;

            bool response = gateway.payment.update(payment);
            Assert.IsTrue(response);

            response = gateway.payment.delete(payment);
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
            batch = gateway.batch.create(batch);

            Batch quote = gateway.batch.generateQuote(batch.id);
            Assert.IsNotNull(quote);

            Batch start = gateway.batch.processBatch(batch.id);
            Assert.IsNotNull(start);
        }

        [TestMethod]
        public void testFailure()
        {
            try
            {
                Batch batch = new Batch("Integration Test Payments", null, "MVR", 0);
                batch = gateway.batch.create(batch);
            }
            catch (Exception e)
            {
                Assert.IsNotNull(e);
            }



        }
    }
}
