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
        public void TestInvoiceLifecycle()
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

        [TestMethod]
        public void TestInvoiceLines()
        {
            //Prepare - Create recipient
            string uuid = Guid.NewGuid().ToString();
            Recipient recipient = new Recipient("individual", "test.create" + uuid + "@example.com", null, "Tom", "Jones", null, null, null, null, null, "1990-01-01");
            recipient = gateway.recipient.Create(recipient);
            Assert.IsNotNull(recipient.id);

            //Test - Create an Invoice
            Invoice invoiceRequest = new Invoice();
            InvoiceLine invoiceLine = new InvoiceLine();
            invoiceLine.description = ".Net SDK Integration Test Invoice Line";
            invoiceLine.unitAmount = new Amount("100.00", "USD");
            invoiceRequest.recipientId = recipient.id;
            invoiceRequest.description = ".Net SDK Integration Test";
            invoiceRequest.lines = new List<InvoiceLine>() { invoiceLine };
            Invoice invoice = gateway.invoice.Create(invoiceRequest);
            Assert.IsTrue(invoice.description.Contains(".Net SDK"));

            //Test - Create an Invoice Line
            InvoiceLine invoiceLineRequest = new InvoiceLine();
            invoiceLineRequest.description = ".Net SDK Integration Test Invoice Line";
            invoiceLineRequest.unitAmount = new Amount("120.00", "USD");
            Invoice invoiceWithLines = gateway.invoiceLine.Create(invoice.id, invoiceLineRequest);
            Assert.IsTrue(invoiceWithLines.lines.Count == 2);

            //Test - Update an Invoice Line
            invoiceLineRequest = new InvoiceLine();
            invoiceLineRequest.invoiceLineId = invoiceWithLines.lines[1].id;
            invoiceLineRequest.unitAmount = new Amount("150.00", "USD");
            invoiceWithLines = gateway.invoiceLine.Update(invoiceWithLines.id, invoiceLineRequest);
            Assert.AreEqual("150.00", invoiceWithLines.lines[1].unitAmount.value);

            //Test - Delete Invoice Lines
            invoice = gateway.invoiceLine.Delete(invoiceWithLines.id,
                invoiceWithLines.lines[0].id,
                invoiceWithLines.lines[1].id);
            Assert.AreEqual(0, invoice.lines.Count);

            //Test - Delete an Invoice
            bool delResult = gateway.invoice.Delete(invoice.id);
            Assert.IsTrue(delResult);

            //Cleanup - Delete Recipient
            bool deleteResult = gateway.recipient.Delete(recipient.id);
            Assert.IsTrue(deleteResult);
        }

    }    
}

