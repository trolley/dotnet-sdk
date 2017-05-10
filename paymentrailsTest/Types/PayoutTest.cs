using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using paymentrails.Types;
using paymentrails.Exceptions;

namespace paymentrailsTest.Types
{
    [TestClass]
    public class PayoutTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidFieldException), "Primary Method must be provided.")]
        public void TestPayoutInvaliPrimaryMethod()
        {
            Payout payout = new Payout(0,false,0,false,null,null,null,null);
            Assert.IsTrue(payout.IsMappable());
        }
        [TestMethod]
        public void TestPayout()
        {
            Payout payout = new Payout(0, false, 0, false, "primarymethod", null, null, null);
            Assert.IsTrue(payout.IsMappable());
        }
    }
}
