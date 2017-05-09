using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using paymentrails.Types;
using System.Collections.Generic;

namespace paymentrailsTest.JsonHelper
{
    [TestClass]
    public class BalanceHelperTest
    {
        [TestMethod]
        public void testJsonToBalanceDictionary()
        {
            Balance balance = new Balance(true, 10000.00,"USD","paymentrails",null);

            String response = @"{""ok"":true,""balances"":{""USD"":{""primary"":true,""amount"":""10000.00"",""currency"":""USD"",""type"":""paymentrails"",""accountNumber"":null}}}";
            Dictionary<String, Balance> balanceDictionary = paymentrails.JsonHelpers.BalanceHelper.JsonToBalanceDictionary(response);

            Assert.AreEqual(balance, balanceDictionary["USD"]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "JSON must be provided.")]
        public void testJsonToBalanceDictionaryInvalidJSON()
        {
            Balance balance = new Balance(true, 10000.00, "USD", "paymentrails", null);

            String response = @"";
            Dictionary<String, Balance> balanceDictionary = paymentrails.JsonHelpers.BalanceHelper.JsonToBalanceDictionary(response);

            Assert.AreEqual(balance, balanceDictionary["USD"]);
        }
    }
}
