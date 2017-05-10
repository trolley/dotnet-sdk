using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using paymentrails.Types;
using paymentrails.Exceptions;

namespace paymentrailsTest.Types
{
    [TestClass]
    public class PaymentTest
    {
        [TestMethod]
        public void TestPaymentSourceAmount()
        {
            Recipient recipient = new Recipient(null, "business", null, "email", "name", null, null, null, null, null, null, null, null, null, null);
            Payment payment = new Payment(recipient, 10, null, 0, null, 0, 0, 0, 0, null, null, null, 0, null, null, null, null, null);
            Assert.IsTrue(payment.IsMappable());
        }
        [TestMethod]
        public void TestPaymentTargetAmount()
        {
            Recipient recipient = new Recipient(null, "business", null, "email", "name", null, null, null, null, null, null, null, null, null, null);
            Payment payment = new Payment(recipient, 0, null, 10, "CAD", 0, 0, 0, 0, null, null, null, 0, null, null, null, null, null);
            Assert.IsTrue(payment.IsMappable());
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidFieldException), "Recipient must be provided.")]
        public void TestPaymentInvalidRecipient()
        {
            Payment payment = new Payment(null, 0,null,0,null,0,0,0,0,null,null,null,0,null,null,null,null,null);
            Assert.IsTrue(payment.IsMappable());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidFieldException), "Payment must have a source amount or target amount.")]
        public void TestPaymentInvalidSourceAmount()
        {
            Recipient recipient = new Recipient(null, "business", null, "email", "name", null, null, null, null, null, null, null, null, null, null);
            Payment payment = new Payment(recipient, -10, null, 0, null, 0, 0, 0, 0, null, null, null, 0, null, null, null, null, null);
            Assert.IsTrue(payment.IsMappable());
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidFieldException), "Payment must have a source amount or target amount.")]
        public void TestPaymentInvalidTargetAmount()
        {
            Recipient recipient = new Recipient(null, "business", null, "email", "name", null, null, null, null, null, null, null, null, null, null);
            Payment payment = new Payment(recipient, 0, null, -10, null, 0, 0, 0, 0, null, null, null, 0, null, null, null, null, null);
            Assert.IsTrue(payment.IsMappable());
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidFieldException), "Payment must have a target currency if it has a target amount.")]
        public void TestPaymentInvalidTargetCurrency()
        {
            Recipient recipient = new Recipient(null, "business", null, "email", "name", null, null, null, null, null, null, null, null, null, null);
            Payment payment = new Payment(recipient, 0, null, 10, null, 0, 0, 0, 0, null, null, null, 0, null, null, null, null, null);
            Assert.IsTrue(payment.IsMappable());
        }
    }
}


