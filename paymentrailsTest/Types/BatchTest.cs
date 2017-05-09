using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using paymentrails.Types;
using paymentrails.Exceptions;
using System.Collections.Generic;
using System.Collections;

namespace paymentrailsTest.Types
{
    [TestClass]
    public class BatchTest
    {
        
        [TestMethod]
        public void TestBatchWithCurrency()
        {
            Recipient recipient = new Recipient(null, "business", null, "email", "name", null, null, null, null, null, null, null, null, null, null);
            Payment payment = new Payment(recipient, 10, null, 0, null, 0, 0, 0, 0, null, null, null, 0, null, null, null, null, null);
            List<Payment> payments = new List<Payment>();
            payments.Add(payment);
            Batch batch = new Batch(null,payments, "currency", 0, 0, null, null, null, null, null, null);
        }
        [TestMethod]
        public void TestBatchWithoutCurrency()
        {
            Recipient recipient = new Recipient(null, "business", null, "email", "name", null, null, null, null, null, null, null, null, null, null);
            Payment payment = new Payment(recipient, 10, null, 0, null, 0, 0, 0, 0, null, null, null, 0, "CAD", null, null, null, null);
            List<Payment> payments = new List<Payment>();
            payments.Add(payment);
            Batch batch = new Batch(null, payments,null, 0, 0, null, null, null, null, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidFieldException), "Payment must be provided")]
        public void TestBatchInvalidPayment()
        {
            Recipient recipient = new Recipient(null, "business", null, "email", "name", null, null, null, null, null, null, null, null, null, null);
            Batch batch = new Batch(null, null, "currency", 0, 0, null, null, null, null, null, null);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidFieldException), "Payment must be provided")]
        public void TestBatchInvalidPaymentsCurrency()
        {
            Recipient recipient = new Recipient(null, "business", null, "email", "name", null, null, null, null, null, null, null, null, null, null);
            Payment payment = new Payment(recipient, 10, null, 0, null, 0, 0, 0, 0, null, null, null, 0, null, null, null, null, null);
            List<Payment> payments = new List<Payment>();
            payments.Add(payment);
            Batch batch = new Batch(null, payments, null, 0, 0, null, null, null, null, null, null);
        }



    }
}
