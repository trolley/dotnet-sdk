using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentRails.Types;
using System;
using System.Collections.Generic;

namespace tests
{
    [TestClass]
    public class RecipientTest
    {

        PaymentRails.Gateway gateway;

        [TestInitialize]
        public void Init()
        {
            gateway = new PaymentRails.Gateway(Config.TEST_API_KEY, Config.TEST_API_SECRET);
        }

        [TestMethod]
        public void Smoke()
        {
            List<Recipient> recipients = gateway.recipient.all();
            Assert.IsTrue(recipients.Count > 0);
        }

        [TestMethod]
        public void testCreate()
        {
            string uuid = System.Guid.NewGuid().ToString();

            Recipient recipient = new Recipient("individual", "test.create" + uuid + "@example.com", null, "Tom", "Jones", null, null, null, null, null, "1990-01-01");
            recipient = gateway.recipient.create(recipient);
            Assert.IsNotNull(recipient);
            Assert.AreEqual("Tom", recipient.firstName);
            Assert.AreEqual("Jones", recipient.lastName);
            Assert.IsNotNull(recipient.email.IndexOf(uuid));
            Assert.IsNotNull(recipient.id);
        }
        [TestMethod]
        public void testCreateASCII()
        {
            string uuid = System.Guid.NewGuid().ToString();

            Recipient recipient = new Recipient("individual", "test.create" + uuid + "@example.com", null, "Tóm", "Jánes", null, null, null, null, null, "1990-01-01");
            recipient = gateway.recipient.create(recipient);
            Assert.IsNotNull(recipient);
            Assert.AreEqual("Tóm", recipient.firstName);
            Assert.AreEqual("Jánes", recipient.lastName);
            Assert.IsNotNull(recipient.email.IndexOf(uuid));
            Assert.IsNotNull(recipient.id);
        }
        [TestMethod]
        public void testLifecycle()
        {
            string uuid = Guid.NewGuid().ToString();
            Recipient recipient = new Recipient("individual", "test.create" + uuid + "@example.com", null, "Tom", "Jones", null, null, null, null, null, "1990-01-01", null, null, null, null);
            recipient = gateway.recipient.create(recipient);
            Assert.IsNotNull(recipient);
            Assert.AreEqual("Tom", recipient.firstName);
            Assert.AreEqual("incomplete", recipient.status);

            recipient.firstName = "Bób";
            recipient.address.Country = "US";
            recipient.status = null;
            bool response = gateway.recipient.update(recipient);
            Assert.IsNotNull(recipient);
            Assert.IsTrue(response);

            Recipient fetchResult = gateway.recipient.find(recipient.id);
            Assert.AreEqual("Bób", fetchResult.firstName);

            bool result = gateway.recipient.delete(fetchResult);
            Assert.IsTrue(result);

            Recipient fetchDeletedResult = gateway.recipient.find(fetchResult.id);
            Assert.AreEqual("archived", fetchDeletedResult.status);
        }

        [TestMethod]
        public void testAddress()
        {
            string uuid = Guid.NewGuid().ToString();
            Recipient recipient = new Recipient("individual", "test.create" + uuid + "@example.com", null, "Tom", "Jones", null, null, null, null, null, "1990-01-01", null, null, null, null);
            recipient.address = new Address("street1", "city", "US", "AL", "12345");
            Recipient createdRecipient = gateway.recipient.create(recipient);

            Assert.AreEqual("US", createdRecipient.address.Country);
/*
            bool response = gateway.recipient.update(recipient);

            Recipient fetchResult = gateway.recipient.find(recipient.id);
            Assert.AreEqual("Bób", fetchResult.firstName);

            bool result = gateway.recipient.delete(fetchResult);
            Assert.IsTrue(result);

            Recipient fetchDeletedResult = gateway.recipient.find(fetchResult.id);
            Assert.AreEqual("archived", fetchDeletedResult.status);*/
        }

        [TestMethod]
        public void testAccount()
        {
            string uuid = Guid.NewGuid().ToString();

            Address address = new Address("123 Wolfstrasse", "Berlin", "DE", "123123");
            Recipient recipient = new Recipient("individual", "test.create" + uuid + "@example.com", null, "Tom", "Jones", null, null, null, null, null, "1990-01-01", null, null, null, address);
            recipient = gateway.recipient.create(recipient);

            Assert.IsNotNull(recipient);
            Assert.AreEqual("Tom", recipient.firstName);
            Assert.AreEqual("Jones", recipient.lastName);
            Assert.IsNotNull(recipient.email.IndexOf(uuid));
            Assert.IsNotNull(recipient.id);

            RecipientAccount recipientAccount = new RecipientAccount("bank-transfer", "EUR", null, true, "FR", "FR14 2004 1010 0505 0001 3M02 606", "123456");
            recipientAccount = gateway.recipientAccount.create(recipient.id, recipientAccount);
            Assert.IsNotNull(recipientAccount);

            recipientAccount = new RecipientAccount("bank-transfer", "EUR", null, true, "DE", "DE89 3704 0044 0532 0130 00", "123456");
            recipientAccount = gateway.recipientAccount.create(recipient.id, recipientAccount);
            Assert.IsNotNull(recipientAccount);


            RecipientAccount findAccount = gateway.recipientAccount.find(recipient.id, recipientAccount.id);
            Assert.AreEqual(recipientAccount.iban, findAccount.iban);

            List<RecipientAccount> recipientAccounts = gateway.recipientAccount.findAll(recipient.id);
            Assert.AreEqual(2, recipientAccounts.Count);
            Assert.AreEqual(recipientAccounts[0].currency, "EUR");

            bool response = gateway.recipientAccount.delete(recipient.id, recipientAccount.id);
            Assert.IsTrue(response);

            recipientAccounts = gateway.recipientAccount.findAll(recipient.id);
            Assert.AreEqual(1, recipientAccounts.Count);
        }
    }
}
