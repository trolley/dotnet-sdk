using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentRails.Types;
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
            Batch newBatch = PaymentRails.JsonHelpers.BatchHelper.JsonToBatch(response);


            Compliance compliance = new Compliance("pending",null);
            Recipient recipient = new Recipient("R-91XQ0PJH39U54", null, "U345678912", "Johnny@test.com", "mark Test", null, null, "active", null, null, null, null, null, null, null);
            Payment payment = new Payment(recipient, 65.00, "", 65.00, "USD", 1.000000, 0.00, 0.00, 0, null, null, null, 0, "USD", "B-91XQ40VXECQJM", "P-912Q8KVY19D2Y", "pending", compliance);
            List<Payment> payments = new List<Payment>();
            payments.Add(payment);
            Batch batch = new Batch("Weekly Payouts on 2017-4-8", payments, "USD", 65.00, 1, "open", null, null, "2017-05-08T18:31:00.682Z", "2017-05-08T18:31:00.767Z", "B-91XQ40VXECQJM");

            Assert.AreEqual(batch,newBatch);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "JSON must be provided.")]
        public void TestJsonToBatchInvalidJSON()
        {
            String response = @"";
            Batch newBatch = PaymentRails.JsonHelpers.BatchHelper.JsonToBatch(response);


            Compliance compliance = new Compliance("pending", null);
            Recipient recipient = new Recipient("R-91XQ0PJH39U54", null, "U345678912", "Johnny@test.com", "mark Test", null, null, "active", null, null, null, null, null, null, null);
            Payment payment = new Payment(recipient, 65.00, "", 65.00, "USD", 1.000000, 0.00, 0.00, 0, null, null, null, 0, "USD", "B-91XQ40VXECQJM", "P-912Q8KVY19D2Y", "pending", compliance);
            List<Payment> payments = new List<Payment>();
            payments.Add(payment);
            Batch batch = new Batch("Weekly Payouts on 2017-4-8", payments, "USD", 65.00, 1, "open", null, null, "2017-05-08T18:31:00.682Z", "2017-05-08T18:31:00.767Z", "B-91XQ40VXECQJM");

            Assert.AreEqual(batch, newBatch);
        }


        [TestMethod]
        public void TestJsonToBatchList()
        {
            String response = @"{""ok"":true,""batches"":[{""id"":""B-91XQ40VXECQJM"",""status"":""open"",""amount"":""65.00"",""totalPayments"":1,""currency"":""USD"",""description"":
                                ""Weekly Payouts on 2017-4-8"",""sentAt"":null,""completedAt"":null,""createdAt"":""2017-05-08T18:31:00.682Z"",""updatedAt"":""2017-05-08T18:31:00.767Z""},{""id"":""B-91XQ40VT5HF18"",
                                ""status"":""open"",""amount"":""65.00"",""totalPayments"":1,""currency"":""USD"",""description"":""Weekly Payouts on 2017-4-8"",""sentAt"":null,""completedAt"":null,""createdAt"":""2017-05-08T18:30:44.905Z"",
                                ""updatedAt"":""2017-05-08T18:30:45.125Z""},{""id"":""B-91XQ2ZHXARPJE"",""status"":""open"",""amount"":""65.00"",""totalPayments"":1,""currency"":""USD"",""description"":""Weekly Payouts on 2017-4-8"",""sentAt"":null,
                                ""completedAt"":null,""createdAt"":""2017-05-08T17:18:16.893Z"",""updatedAt"":""2017-05-08T17:18:17.018Z""},{""id"":""B-91XQ2ZH4BXXHR"",""status"":""open"",""amount"":""65.00"",""totalPayments"":1,""currency"":""USD"",
                                ""description"":""Weekly Payouts on 2017-4-8"",""sentAt"":null,""completedAt"":null,""createdAt"":""2017-05-08T17:16:55.807Z"",""updatedAt"":""2017-05-08T17:16:55.985Z""},{""id"":""B-912Q8JRQ1R16U"",""status"":""open"",
                                ""amount"":""65.00"",""totalPayments"":1,""currency"":""USD"",""description"":""Weekly Payouts on 2017-4-8"",""sentAt"":null,""completedAt"":null,""createdAt"":""2017-05-08T17:14:49.885Z"",""updatedAt"":""2017-05-08T17:14:50.070Z""},
                                {""id"":""B-91XQ2ZKCA9B0R"",""status"":""open"",""amount"":""65.00"",""totalPayments"":1,""currency"":""USD"",""description"":""Weekly Payouts on 2017-4-8"",""sentAt"":null,""completedAt"":null,""createdAt"":""2017-05-08T17:13:55.165Z"",
                                ""updatedAt"":""2017-05-08T17:13:55.366Z""},{""id"":""B-912Q8JU55CP0C"",""status"":""open"",""amount"":""65.00"",""totalPayments"":1,""currency"":""USD"",""description"":""Weekly Payouts on 2017-4-8"",""sentAt"":null,""completedAt"":null,
                                ""createdAt"":""2017-05-08T17:09:17.854Z"",""updatedAt"":""2017-05-08T17:09:18.059Z""},{""id"":""B-91XQ2ZGK7DKMJ"",""status"":""open"",""amount"":""65.00"",""totalPayments"":1,""currency"":""USD"",
                                ""description"":""Weekly Payouts on 2017-4-8"",""sentAt"":null,""completedAt"":null,""createdAt"":""2017-05-08T17:09:04.889Z"",""updatedAt"":""2017-05-08T17:09:05.789Z""},{""id"":""B-91XQ2Y39CN3G2"",""status"":""processing"",
                                ""amount"":""65.00"",""totalPayments"":1,""currency"":""CAD"",""description"":""Weekly Payouts on 2017-4-8"",""sentAt"":""2017-05-08T15:50:39.272Z"",""completedAt"":null,""createdAt"":""2017-05-08T15:50:39.051Z"",
                                ""updatedAt"":""2017-05-08T15:50:39.273Z""},{""id"":""B-91XQ2Y353T0N8"",""status"":""open"",""amount"":""65.00"",""totalPayments"":1,""currency"":""USD"",""description"":""Weekly Payouts on 2017-4-8"",""sentAt"":null,
                                ""completedAt"":null,""createdAt"":""2017-05-08T15:50:27.208Z"",""updatedAt"":""2017-05-08T15:50:27.324Z""},{""id"":""B-91XQ0H33EX05G"",""status"":""processing"",""amount"":""65.00"",""totalPayments"":1,""currency"":""CAD"",
                                ""description"":""Weekly Payouts on 2017-4-5"",""sentAt"":""2017-05-05T17:02:36.486Z"",""completedAt"":null,""createdAt"":""2017-05-05T16:45:45.493Z"",""updatedAt"":""2017-05-05T17:02:36.487Z""},{""id"":""B-912Q61G0BRVGC"",
                                ""status"":""open"",""amount"":""900.90"",""totalPayments"":1,""currency"":""USD"",""description"":""Weekly Payouts on 2017-4-4"",""sentAt"":null,""completedAt"":null,""createdAt"":""2017-05-04T19:19:38.049Z"",
                                ""updatedAt"":""2017-05-08T16:51:56.423Z""}],""meta"":{""page"":1,""pages"":1,""records"":12}}";
            List<Batch> batches = PaymentRails.JsonHelpers.BatchHelper.JsonToBatchList(response);

            Batch batch = new Batch("Weekly Payouts on 2017-4-8", null, "USD", 65.00, 1, "open", null, null, "2017-05-08T18:31:00.682Z", "2017-05-08T18:31:00.767Z", "B-91XQ40VXECQJM");

            Assert.AreEqual(batch, batches[0]);
        }
    }
}

