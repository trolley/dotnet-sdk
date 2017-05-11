using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentRails.Types;

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
            Payout newPayout = PaymentRails.JsonHelpers.PayoutHelper.JsonToPayout(response);

            Assert.AreEqual(payout, newPayout);
        }

        [TestMethod]
        public void testJsonToPayoutWithBankAccount()
        {
            BankAccount bank = new BankAccount("BR", null, null, null, "USD", "Yupg", null, "*************************93P1", null, "EMPTY", new Address("123 StreetPlace", null, "Sao Paulo", null, null, "BR", "Brazilia"));
            Payout payout = new Payout(1000, false, 1000, false, "bank", "USD", bank, null);
            String response = @"{""ok"":true,""autoswitch"":{""limit"":1000,""active"":false},""holdup"":{""limit"":1000,""active"":false},""primary"":{""method"":""bank"",""currency"":{""currency"":{""code"":""USD"",""name"":""US Dollar""}}},""method"":""bank"",""accounts"":{""bank"":{""currency"":""USD"",""country"":""BR"",""name"":""Yupg"",""iban"":""*************************93P1"",""bankRegion"":""Brazilia"",""bankCity"":""Sao Paulo"",""bankAddress"":""123 StreetPlace"",""governmentId"":""EMPTY""}}}";
            Payout newPayout = PaymentRails.JsonHelpers.PayoutHelper.JsonToPayout(response);

            Assert.AreEqual(payout, newPayout);
        }

        [TestMethod]
        public void testJsonToPayoutWithPaypalAccount()
        {
            PaypalAccount paypal = new PaypalAccount("sample32@email.com");
            Payout payout = new Payout(1000, false, 1000, false, "paypal", "USD", null, paypal);
            string response = @"{""ok"":true,""autoswitch"":{""limit"":1000,""active"":false},""holdup"":{""limit"":1000,""active"":false},""primary"":{""method"":""paypal"",""currency"":{""currency"":{""code"":""USD"",""name"":""US Dollar""}}},""method"":""paypal"",""accounts"":{""paypal"":{""address"":""sample32@email.com""}}}";
            Payout responsePayout = PaymentRails.JsonHelpers.PayoutHelper.JsonToPayout(response);
            Assert.AreEqual(payout, responsePayout);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "JSON must be provided.")]
        public void JsonToPayoutInvalidJson()
        {
            Payout payout = new Payout(1000, false, 1000, false, "bank", "USD", null, null);
            String response = @"";
            Payout newPayout = PaymentRails.JsonHelpers.PayoutHelper.JsonToPayout(response);

            Assert.AreEqual(payout, newPayout);
        }
    }
}
