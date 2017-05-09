using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using paymentrails.Types;
using System.Collections.Generic;

namespace paymentrailsTest.JsonHelper
{
    [TestClass]
    public class BachHelperTest
    {
        [TestMethod]
        public void TestJsonToBatch()
        {
            String response = @"{""ok"":true,""batch"":{""id"":""B-91XQ40VXECQJM"",""status"":""open"",""amount"":""65.00"",""totalPayments"":1,""currency"":""USD"",""description"":""Weekly Payouts on 2017-4-8"",""sentAt"":null,""completedAt"":null,""createdAt"":""2017-05-08T18:31:00.682Z"",""updatedAt"":""2017-05-08T18:31:00.767Z"",
                                ""payments"":{""payments"":[{""id"":""P-912Q8KVY19D2Y"",""recipient"":{""id"":""R-91XQ0PJH39U54"",""referenceId"":""U345678912"",""email"":""Johnny@test.com"",""name"":""mark Test"",""status"":""active"",""countryCode"":null},""method"":""paypal"",""methodDisplay"":""PayPal"",""status"":""pending"",
                                ""sourceAmount"":""65.00"",""targetAmount"":""65.00"",""isSupplyPayment"":false,""memo"":"""",""fees"":""0.00"",""recipientFees"":""0.00"",""exchangeRate"":""1.000000"",""processedAt"":null,""merchantFees"":""0.00"",""sourceCurrency"":""USD"",""sourceCurrencyName"":""US Dollar"",""targetCurrency"":""USD"",
                                ""targetCurrencyName"":""US Dollar"",""compliance"":{""status"":""pending"",""checkedAt"":null}}],""meta"":{""page"":1,""pages"":1,""records"":1}}}}";

            Batch newBatch = paymentrails.JsonHelpers.BatchHelper.JsonToBatch(response);


            Recipient recipient = new Recipient("R-91XQ0PJH39U54", "individual", "U345678912", "Johnny@test.com", "mark Test", null, null, null, null, null, null, null, null, null, null);
            Payment payment = new Payment(recipient, 65.00, "", 65.00, "USD", 1.000000, 0.00, 0.00, 0, null, null, null, 0, "USD", "B-91XQ40VXECQJM", "P-912Q8KVY19D2Y", "pending", null);
            List<Payment> payments = new List<Payment>();
            payments.Add(payment);
            Batch batch = new Batch("Weekly Payouts on 2017-4-8", payments, "USD", 65.00, 1, "open", null, null, "2017-05-08T18:31:00.682Z", "2017-05-08T18:31:00.767Z", "B-91XQ40VXECQJM");

            Assert.AreEqual(batch,newBatch);
        }
    }
}
