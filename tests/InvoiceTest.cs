using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trolley.Types;
using System;
using System.Collections.Generic;
using Trolley.Types.Supporting;

namespace tests
{
    [TestClass]
    public class InvoiceTest
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
            string uuid = Guid.NewGuid().ToString();
            Recipient recipient = new Recipient("individual", "test.create" + uuid + "@example.com", null, "Tom", "Jones", null, null, null, null, null, "1990-01-01");
            recipient = gateway.recipient.Create(recipient);
            Assert.IsNotNull(recipient.id);

            //Test - Create an Invoice
            Invoice invoiceRequest = new Invoice();
            invoiceRequest.recipientId = recipient.id;
            invoiceRequest.description = ".Net SDK Integration Test";
            Invoice invoice = gateway.invoice.Create(invoiceRequest);
            Assert.IsTrue(invoice.description.Contains(".Net SDK"));

            //Test - Update an Invoice
            invoiceRequest.invoiceId = invoice.id;
            invoiceRequest.description = ".Net SDK Integration Test : Updated Descripton";
            invoice = gateway.invoice.Update(invoiceRequest);
            Assert.IsTrue(invoice.description.Contains("Updated Descripton"));

            //Test - Get an Invoice
            Invoice invoiceGet = gateway.invoice.Get(invoice.id);
            Assert.AreEqual(invoiceGet.id, invoice.id);

            //Test - Search for an Invoice
            Invoices invoices = gateway.invoice.Search(SearchBy.RecipientId, 1, 10, null, recipient.id);
            Assert.IsTrue(invoices.invoices.Count == 1);

            //Test - Search for an Invoice (auto pagination)
            var i = gateway.invoice.Search(SearchBy.RecipientId, null, recipient.id);
            int itemCount = 0;
            foreach (Invoice inv in i)
            {
                Assert.IsNotNull(inv.id);
                itemCount++;
            }
            Assert.IsTrue(itemCount > 0);

            //Test - Delete an Invoice
            bool delResult = gateway.invoice.Delete(invoice.id);
            Assert.IsTrue(delResult);

            //Cleanup - Delete Recipient
            bool deleteResult = gateway.recipient.Delete(recipient.id);
            Assert.IsTrue(deleteResult);
        }
    }
}
