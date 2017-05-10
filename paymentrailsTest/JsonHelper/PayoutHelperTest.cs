using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using paymentrails.Types;

namespace paymentrailsTest.JsonHelper
{
    [TestClass]
    public class PayoutHelperTest
    {
        [TestMethod]
        public void testJsonToPayout()
        {
            Payout payout = new Payout(1000,false,1000,false,"bank","USD",null,null);
            String response = @"{""ok"":true,""autoswitch"":{""limit"":1000,""active"":false},""holdup"":{""limit"":1000,""active"":false},""primary"":{""method"":""bank"",""currency"":{""currency"":{""code"":""USD"",""name"":""US Dollar""}}},""method"":""bank"",""accounts"":{}}";
            Payout newPayout = paymentrails.JsonHelpers.PayoutHelper.JsonToPayout(response);

            Assert.AreEqual(payout, newPayout);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "JSON must be provided.")]
        public void JsonToPayoutInvalidJson()
        {
            Payout payout = new Payout(1000, false, 1000, false, "bank", "USD", null, null);
            String response = @"";
            Payout newPayout = paymentrails.JsonHelpers.PayoutHelper.JsonToPayout(response);

            Assert.AreEqual(payout, newPayout);
        }
    }
}
