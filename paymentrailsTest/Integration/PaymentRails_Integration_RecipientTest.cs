using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentRails;
using PaymentRails.Types;
using System.Collections.Generic;


namespace paymentrailsTest
{

    [TestClass]
    public class PaymentRails_Integration_RecipientTest
    {
        PaymentRails_Gateway gateway;


        [TestInitialize]
        public void Init()
        {
           gateway = new PaymentRails_Gateway("YOUR-API-KEY", "YOUR-API-SECRET", "production");
        }

        [TestMethod]
        public void testAll_smokeTest()
        {
            List<Recipient> recipients = gateway.recipient.all();
            Assert.IsNotNull(recipients);
        }
        [TestMethod]
        public void testCreate()
        {
            string uuid = Guid.NewGuid().ToString();
           
            Recipient recipient = new Recipient("individual","test.create"+uuid+"@example.com",null,"Tom","Jones",null,null,null,null,null,"1990-01-01");
            recipient = gateway.recipient.create(recipient);
            Assert.IsNotNull(recipient);
            Assert.AreEqual("Tom", recipient.FirstName);
            Assert.AreEqual("Jones", recipient.LastName);
            Assert.IsNotNull(recipient.Email.IndexOf(uuid));
            Assert.IsNotNull(recipient.Id);
        }
        [TestMethod]
        public void testLifecycle()
        {
            string uuid = Guid.NewGuid().ToString();
            Recipient recipient = new Recipient("individual", "test.create" + uuid + "@example.com", null, "Tom", "Jones", null, null, null, null, null, "1990-01-01", null, null, null, null);
            recipient = gateway.recipient.create(recipient);
            Assert.IsNotNull(recipient);
            Assert.AreEqual("Tom", recipient.FirstName);
            Assert.AreEqual("incomplete", recipient.Status);

            recipient.FirstName = "Bob";
            recipient.Address.Country = "US";
            recipient.Status = null;
            bool response = gateway.recipient.update(recipient);
            Assert.IsNotNull(recipient);
            Assert.IsTrue(response);

            Recipient fetchResult = gateway.recipient.find(recipient.Id);
            Assert.AreEqual("Bob", fetchResult.FirstName);

            bool result = gateway.recipient.delete(fetchResult);
            Assert.IsTrue(result);

            Recipient fetchDeletedResult = gateway.recipient.find(fetchResult.Id);
            Assert.AreEqual("archived", fetchDeletedResult.Status);
        }

        [TestMethod]
        public void testAccount()
        {
            string uuid = Guid.NewGuid().ToString();
            
            Address address = new Address("123 Wolfstrasse","Berlin","DE","123123");
            Recipient recipient = new Recipient("individual", "test.create" + uuid + "@example.com", null, "Tom", "Jones", null, null, null, null, null, "1990-01-01", null, null, null, address);
            recipient = gateway.recipient.create(recipient);

            Assert.IsNotNull(recipient);
            Assert.AreEqual("Tom", recipient.FirstName);
            Assert.AreEqual("Jones", recipient.LastName);
            Assert.IsNotNull(recipient.Email.IndexOf(uuid));
            Assert.IsNotNull(recipient.Id);

           RecipientAccount recipientAccount = new RecipientAccount("bank-transfer","EUR", null, null,"FR", "FR14 2004 1010 0505 0001 3M02 606", "123456");
            recipientAccount = gateway.recipientAccount.create(recipient.Id,recipientAccount);
            Assert.IsNotNull(recipientAccount);

            recipientAccount = new RecipientAccount("bank-transfer", "EUR", null, null, "DE", "DE89 3704 0044 0532 0130 00", "123456");
            recipientAccount = gateway.recipientAccount.create(recipient.Id, recipientAccount);
            Assert.IsNotNull(recipientAccount);


            RecipientAccount findAccount = gateway.recipientAccount.find(recipient.Id, recipientAccount.Id);
            Assert.AreEqual(recipientAccount.Iban, findAccount.Iban);

            List<RecipientAccount> recipientAccounts = gateway.recipientAccount.findAll(recipient.Id);
            Assert.AreEqual(2, recipientAccounts.Count);
            Assert.AreEqual(recipientAccounts[0].Currency, "EUR");

            bool response = gateway.recipientAccount.delete(recipient.Id,recipientAccount.Id);
            Assert.IsTrue(response);

            recipientAccounts = gateway.recipientAccount.findAll(recipient.Id);
            Assert.AreEqual(1, recipientAccounts.Count);
        }
    }
       
}