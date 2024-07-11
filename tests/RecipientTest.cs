using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trolley.Types;
using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace tests
{
    [TestClass]
    public class RecipientTest
    {

        Trolley.Gateway gateway;
        Config config;

        [TestInitialize]
        public void Init()
        {   
            config = new Config();
            gateway = new Trolley.Gateway(config.ACCESS_KEY, config.SECRET_KEY);
        }

        [TestMethod]
        public void Smoke()
        {
            List<Recipient> recipients = gateway.recipient.ListAllRecipients(null, 1, 20).recipients;
            Assert.IsTrue(recipients.Count > 0);
        }

        [TestMethod]
        public void testCreate()
        {
            string uuid = System.Guid.NewGuid().ToString();

            Recipient recipient = new Recipient("individual", "test.create" + uuid + "@example.com", null, "Tom", "Jones", null, null, null, null, null, "1990-01-01");
            recipient = gateway.recipient.Create(recipient);
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

            Recipient recipient = new Recipient("individual", "test.create" + uuid + "@example.com", null, "Tóm", "Jónes", null, null, null, null, null, "1990-01-01");
            recipient = gateway.recipient.Create(recipient);
            Assert.IsNotNull(recipient);
            Assert.AreEqual("Tóm", recipient.firstName);
            Assert.AreEqual("Jónes", recipient.lastName);
            Assert.IsNotNull(recipient.email.IndexOf(uuid));
            Assert.IsNotNull(recipient.id);
        }

        public static string Serialize(object o, StringEscapeHandling stringEscapeHandling)
        {
            StringWriter wr = new StringWriter();
            var jsonWriter = new JsonTextWriter(wr);
            jsonWriter.StringEscapeHandling = stringEscapeHandling;
            new JsonSerializer().Serialize(jsonWriter, o);
            return wr.ToString();
        }

        [TestMethod]
        public void testLifecycle()
        {
            string uuid = Guid.NewGuid().ToString();
            Recipient recipient = new Recipient();
            recipient.type = "individual";
            recipient.email = "test.create" + uuid + "@example.com";
            recipient.firstName = "Tom";
            recipient.lastName = "Jones";
            recipient.dob = "1990-01-01";

            recipient = gateway.recipient.Create(recipient);
            Assert.IsNotNull(recipient);
            Assert.AreEqual("Tom", recipient.firstName);
            Assert.AreEqual("incomplete", recipient.status);

            recipient.firstName = "Bób";
            recipient.address.Country = "US";
            recipient.status = null;

            bool response = gateway.recipient.Update(recipient.id, recipient);
            Assert.IsNotNull(recipient);
            Assert.IsTrue(response);

            Recipient fetchResult = gateway.recipient.Get(recipient.id);
            Assert.AreEqual("Bób", fetchResult.firstName);

            bool result = gateway.recipient.Delete(fetchResult.id);
            Assert.IsTrue(result);

            Recipient fetchDeletedResult = gateway.recipient.Get(fetchResult.id);
            Assert.AreEqual("archived", fetchDeletedResult.status);
        }

        [TestMethod]
        public void testAddress()
        {
            string uuid = Guid.NewGuid().ToString();
            Recipient recipient = new Recipient();
            recipient.type = "individual";
            recipient.email = "test.create" + uuid + "@example.com";
            recipient.firstName = "Tom";
            recipient.lastName = "Jones";
            recipient.dob = "1990-01-01";
            recipient.address = new Address("street1", "city", "US", "AL", "12345");
            Recipient createdRecipient = gateway.recipient.Create(recipient);

            Assert.AreEqual("US", createdRecipient.address.Country);
        }

        [TestMethod]
        public void testAccount()
        {
            string uuid = Guid.NewGuid().ToString();

            Address address = new Address("123 Wolfstrasse", "Berlin", "DE", "123123");
            Recipient recipient = new Recipient();
            recipient.type = "individual";
            recipient.email = "test.create" + uuid + "@example.com";
            recipient.firstName = "Tom";
            recipient.lastName = "Jones";
            recipient.dob = "1990-01-01";
            recipient.address = address;

            recipient = gateway.recipient.Create(recipient);

            Assert.IsNotNull(recipient);
            Assert.AreEqual("Tom", recipient.firstName);
            Assert.AreEqual("Jones", recipient.lastName);
            Assert.IsNotNull(recipient.email.IndexOf(uuid));
            Assert.IsNotNull(recipient.id);

            RecipientAccount recipientAccount = new RecipientAccount("bank-transfer", "CAD", null, true, "CA");
            recipientAccount.accountNum = "1234567";
            recipientAccount.bankId = "003";
            recipientAccount.branchId = "47261";
            recipientAccount.bankAccountType = "savings";
            recipientAccount = gateway.recipientAccount.create(recipient.id, recipientAccount);
            Assert.IsNotNull(recipientAccount);

            recipientAccount = new RecipientAccount("bank-transfer", "CAD", null, true, "CA");
            recipientAccount.accountNum = "1234578";
            recipientAccount.bankId = "003";
            recipientAccount.branchId = "47261";
            recipientAccount = gateway.recipientAccount.create(recipient.id, recipientAccount);
            Assert.IsNotNull(recipientAccount);

            Recipient usRecipient = new Recipient();
            usRecipient.type = "individual";
            usRecipient.email = "test.accountCheck" + uuid + "@example.com";
            usRecipient.firstName = "Tom";
            usRecipient.lastName = "Jones Check";
            usRecipient.dob = "1990-01-01";
            usRecipient.address = new Address("719 anderson dr", "Los Altos", "US", "CA", "94024");

            usRecipient = gateway.recipient.Create(usRecipient);
            RecipientAccount recipientCheckAccount = new RecipientAccount
            {
                type = "check",
                mailing = new MailingAddress("Tom Jones", "719 anderson dr", "Los Altos", "US", "CA", "94024")
            };

            recipientCheckAccount = gateway.recipientAccount.create(usRecipient.id, recipientCheckAccount);
            Assert.IsNotNull(recipientCheckAccount);

            RecipientAccount findAccount = gateway.recipientAccount.find(recipient.id, recipientAccount.id);
            Assert.AreEqual(recipientAccount.iban, findAccount.iban);

            List<RecipientAccount> recipientAccounts = gateway.recipientAccount.findAll(recipient.id);
            Assert.AreEqual(2, recipientAccounts.Count);
            Assert.AreEqual(recipientAccounts[0].currency, "CAD");

            bool response = gateway.recipientAccount.delete(recipient.id, recipientAccount.id);
            Assert.IsTrue(response);

            recipientAccounts = gateway.recipientAccount.findAll(recipient.id);
            Assert.AreEqual(1, recipientAccounts.Count);
        }

        [TestMethod]
        public void TestMultipleDelete()
        {
            string uuid = Guid.NewGuid().ToString();
            Recipient recipient = new Recipient();
            recipient.type = "individual";
            recipient.email = "test.create.netsdk" + uuid + "@example.com";
            recipient.firstName = "Tom";
            recipient.lastName = "Jones";
            recipient.dob = "1990-01-01";
            recipient.address = new Address("street1", "city", "US", "AL", "12345");
            Recipient createdRecipient1 = gateway.recipient.Create(recipient);

            Assert.AreEqual("Tom", createdRecipient1.firstName);

            uuid = Guid.NewGuid().ToString();
            recipient.email = "test.create.netsdk" + uuid + "@example.com";
            recipient.firstName = "John";
            recipient.lastName = "Smith";
            Recipient createdRecipient2 = gateway.recipient.Create(recipient);

            Assert.AreEqual("John", createdRecipient2.firstName);

            bool delResult = gateway.recipient.Delete(createdRecipient1.id, createdRecipient2.id);

            Assert.IsTrue(delResult);
        }

        [TestMethod]
        public void TestListAllRecipients()
        {
            List<Recipient> recipients = gateway.recipient.ListAllRecipients("", 1, 10).recipients;
            Assert.IsTrue(recipients.Count > 0);

            var allRecipients = gateway.recipient.ListAllRecipients("");
            int itemCount = 0;
            foreach (Recipient r in allRecipients)
            {
                Assert.IsNotNull(r.id);
                itemCount++;
            }
            Assert.IsTrue(itemCount > 0);
        }

        [TestMethod]
        public void TestRecipientLogs()
        {
            string recipientId = config.RECIPIENT_ID;

            List<Log> logs = gateway.recipient.GetAllLogs(recipientId, 1, 10).logs;
            Assert.IsTrue(logs.Count > 0);

            var logsEnumerable = gateway.recipient.GetAllLogs(recipientId);
            int itemCount = 0;
            foreach (Log l in logsEnumerable)
            {
                Assert.IsNotNull(l.createdAt);
                itemCount++;
            }
            Assert.IsTrue(itemCount > 0);
        }

        [TestMethod]
        public void TestRecipientPayments()
        {
            string recipientId = config.RECIPIENT_ID;

            List<Payment> payments = gateway.recipient.GetAllPayments(recipientId, 1, 10).payments;
            Assert.IsTrue(payments.Count > 0);


            var paymentsEnumerable = gateway.recipient.GetAllPayments(recipientId);
            int itemCount = 0;
            foreach (Payment p in paymentsEnumerable)
            {
                Assert.IsNotNull(p.id);
                itemCount++;
            }
            Assert.IsTrue(itemCount > 0);
        }

        [TestMethod]
        public void TestRecipientOfflinePayments()
        {
            string recipientId = config.RECIPIENT_ID;

            List<OfflinePayment> offlinePayments = gateway.recipient.GetAllOfflinePayments(recipientId, null, 1, 10).offlinePayments;
            Assert.IsTrue(offlinePayments.Count > 0);

            var op = gateway.recipient.GetAllOfflinePayments(recipientId, null);
            int itemCount = 0;
            foreach(OfflinePayment offlinePayment in op)
            {
                Assert.IsNotNull(offlinePayment.id);
                itemCount++;
            }
            Assert.IsTrue(itemCount > 0);
        }
    }
}
