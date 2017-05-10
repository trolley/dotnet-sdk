using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentRails.Types;
using System.Collections.Generic;

namespace paymentrailsTest.JsonHelper
{
    [TestClass]
    public class PaymentHelperTest
    {
        [TestMethod]
        public void TestJsonToPayment()
        {
            Compliance compliance = new Compliance("pending", null);
            Address address = new Address();
            PaypalAccount paypal = new PaypalAccount("testpaypal@example.com");
            Payout payout = new Payout(1000,false,1000,false,"paypal",null,null,paypal);
            Recipient recipient = new Recipient("R-91XQ0PJH39U54", "individual", "U345678912", "Johnny@test.com", "mark Test", "mark", "Test", "active", null, "en", null, "https://s3.amazonaws.com/static.api.paymentrails.com/icon_user.svg",compliance, payout, address);
            Payment payment = new Payment(recipient, 65.00, "", 65.00, "USD", 1.000000, 0.00, 0.00, 2.000000, null, "2017-05-08T18:31:00.736Z", "2017-05-08T18:31:00.736Z", 0, "USD", "B-91XQ40VXECQJM", "P-912Q8KVY19D2Y", "pending", compliance);

            String response = @"{""ok"":true,""payment"":{""id"":""P-912Q8KVY19D2Y"",""recipient"":{""id"":""R-91XQ0PJH39U54"",""referenceId"":""U345678912"",""email"":""Johnny@test.com"",
                                ""name"":""mark Test"",""lastName"":""Test"",""firstName"":""mark"",""type"":""individual"",""status"":""active"",""language"":""en"",""complianceStatus"":""pending"",
                                ""dob"":null,""payoutMethod"":""paypal"",""updatedAt"":""2017-05-08T14:49:12.512Z"",""createdAt"":""2017-05-04T16:17:04.378Z"",
                                ""gravatarUrl"":""https://s3.amazonaws.com/static.api.paymentrails.com/icon_user.svg"",""compliance"":{""status"":""pending"",""checkedAt"":null},""payout"":{""autoswitch"":{""limit"":1000,""active"":false},
                                ""holdup"":{""limit"":1000,""active"":false},""primary"":{""method"":""paypal"",""currency"":{""currency"":{}}},""method"":""paypal"",""accounts"":{""paypal"":{""address"":""testpaypal@example.com""}},
                                ""methodDisplay"":""PayPal""},""address"":{""street1"":null,""street2"":null,""city"":null,""postalCode"":null,""country"":null,""region"":null,""phone"":null}},""status"":""pending"",""sourceAmount"":""65.00"",
                                ""exchangeRate"":""1.000000"",""fees"":""0.00"",""recipientFees"":""0.00"",""targetAmount"":""65.00"",""fxRate"":""2.000000"",""memo"":"""",""processedAt"":null,""createdAt"":""2017-05-08T18:31:00.736Z"",
                                ""updatedAt"":""2017-05-08T18:31:00.736Z"",""merchantFees"":""0.00"",""compliance"":{""status"":""pending"",""checkedAt"":null},""sourceCurrency"":""USD"",""sourceCurrencyName"":""US Dollar"",""targetCurrency"":""USD"",
                                ""targetCurrencyName"":""US Dollar"",""batch"":{""id"":""B-91XQ40VXECQJM"",""createdAt"":""2017-05-08T18:31:00.682Z"",""updatedAt"":""2017-05-08T18:31:00.767Z"",""sentAt"":null,""completedAt"":null}}}";

            Payment newPayment = PaymentRails.JsonHelpers.PaymentHelper.JsonToPayment(response);
            Assert.AreEqual(payment, newPayment);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "JSON must be provided.")]
        public void testJsonToPaymentInvalidJSON()
        {
            Compliance compliance = new Compliance("pending", null);
            Address address = new Address();
            PaypalAccount paypal = new PaypalAccount("testpaypal@example.com");
            Payout payout = new Payout(1000, false, 1000, false, "paypal", null, null, paypal);
            Recipient recipient = new Recipient("R-91XQ0PJH39U54", "individual", "U345678912", "Johnny@test.com", "mark Test", "mark", "Test", "active", null, "en", null, "https://s3.amazonaws.com/static.api.paymentrails.com/icon_user.svg", compliance, payout, address);
            Payment payment = new Payment(recipient, 65.00, "", 65.00, "USD", 1.000000, 0.00, 0.00, 2.000000, null, "2017-05-08T18:31:00.736Z", "2017-05-08T18:31:00.736Z", 0, "USD", "B-91XQ40VXECQJM", "P-912Q8KVY19D2Y", "pending", compliance);

            String response = @"";
            Payment newPayment = PaymentRails.JsonHelpers.PaymentHelper.JsonToPayment(response);
            Assert.AreEqual(payment, newPayment);
        }

        [TestMethod]
        public void TestJsonToPaymentList()
        {
            Compliance compliance = new Compliance("pending", null);
            Address address = new Address();
            PaypalAccount paypal = new PaypalAccount("testpaypal@example.com");
            Payout payout = new Payout(1000, false, 1000, false, "paypal", null, null, paypal);
            Recipient recipient = new Recipient("R-91XQ0PJH39U54", "individual", "U345678912", "Johnny@test.com", "mark Test", "mark", "Test", "active", null, "en", null, "https://s3.amazonaws.com/static.api.paymentrails.com/icon_user.svg", compliance, payout, address);
            Payment payment = new Payment(recipient, 65.00, "", 65.00, "USD", 1.000000, 0.00, 0.00, 2.000000, null, "2017-05-08T18:31:00.736Z", "2017-05-08T18:31:00.736Z", 0, "USD", "B-91XQ40VXECQJM", "P-912Q8KVY19D2Y", "pending", compliance);

    
            String response = @"{""ok"":true,""payments"":[{""id"":""P-912Q8KVY19D2Y"",""recipient"":{""id"":""R-91XQ0PJH39U54"",""referenceId"":""U345678912"",""email"":""Johnny@test.com"",""name"":""mark Test"",""lastName"":""Test"",""firstName"":""mark"",
                                ""type"":""individual"",""status"":""active"",""language"":""en"",""complianceStatus"":""pending"",""dob"":null,""payoutMethod"":""paypal"",""updatedAt"":""2017-05-08T14:49:12.512Z"",""createdAt"":""2017-05-04T16:17:04.378Z"",
                                ""gravatarUrl"":""https://s3.amazonaws.com/static.api.paymentrails.com/icon_user.svg"",""compliance"":{""status"":""pending"",""checkedAt"":null},""payout"":{""autoswitch"":{""limit"":1000,""active"":false},""holdup"":{""limit"":1000,""active"":false},
                                ""primary"":{""method"":""paypal"",""currency"":{""currency"":{}}},""method"":""paypal"",""accounts"":{""paypal"":{""address"":""testpaypal@example.com""}},""methodDisplay"":""PayPal""},""address"":{""street1"":null,""street2"":null,""city"":null,""postalCode"":null,
                                ""country"":null,""region"":null,""phone"":null}},""status"":""pending"",""sourceAmount"":""65.00"",""exchangeRate"":""1.000000"",""fees"":""0.00"",""recipientFees"":""0.00"",""targetAmount"":""65.00"",""fxRate"":""2.000000"",""memo"":"""",""processedAt"":null,
                                ""createdAt"":""2017-05-08T18:31:00.736Z"",""updatedAt"":""2017-05-08T18:31:00.736Z"",""merchantFees"":""0.00"",""compliance"":{""status"":""pending"",""checkedAt"":null},""sourceCurrency"":""USD"",""sourceCurrencyName"":""US Dollar"",""targetCurrency"":""USD"",
                                ""targetCurrencyName"":""US Dollar"",""batch"":{""id"":""B-91XQ40VXECQJM"",""createdAt"":""2017-05-08T18:31:00.682Z"",""updatedAt"":""2017-05-08T18:31:00.767Z"",""sentAt"":null,""completedAt"":null}}],""meta"":{""page"":1,""pages"":1,""records"":1}}";

            List<Payment> payments = PaymentRails.JsonHelpers.PaymentHelper.JsonToPaymentList(response);
            Assert.AreEqual(payment, payments[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "JSON must be provided.")]
        public void TestJsonToPaymentListInvaidJson()
        {
            Compliance compliance = new Compliance("pending", null);
            Address address = new Address();
            PaypalAccount paypal = new PaypalAccount("testpaypal@example.com");
            Payout payout = new Payout(1000, false, 1000, false, "paypal", null, null, paypal);
            Recipient recipient = new Recipient("R-91XQ0PJH39U54", "individual", "U345678912", "Johnny@test.com", "mark Test", "mark", "Test", "active", null, "en", null, "https://s3.amazonaws.com/static.api.paymentrails.com/icon_user.svg", compliance, payout, address);
            Payment payment = new Payment(recipient, 65.00, "", 65.00, "USD", 1.000000, 0.00, 0.00, 2.000000, null, "2017-05-08T18:31:00.736Z", "2017-05-08T18:31:00.736Z", 0, "USD", "B-91XQ40VXECQJM", "P-912Q8KVY19D2Y", "pending", compliance);


            String response = @"";

            List<Payment> payments = PaymentRails.JsonHelpers.PaymentHelper.JsonToPaymentList(response);
            Assert.AreEqual(payment, payments[0]);
        }
    }
}
