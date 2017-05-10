using paymentrails.Types;
using System.Collections.Generic;

namespace paymentrailsTest
{
    class ValidResponseData
    {
        private static Payout ValidPaymentRecipientPayout = new Payout(1000, false, 1000, false, "paypal", null, null, new PaypalAccount("Ruby_Hickle7379@yahoo.ca"));
        private static Address ValidPaymentRecipientAddress = new Address();
        private static Recipient ValidPaymentRecipient = new Recipient("R-DE0366D6494349B7", "business", "Ruby_Hickle7379@yahoo.ca", "Ruby_Hickle7379@yahoo.ca", "Ruby Hickle7379", "Ruby", "Hickle7379", "active", null, "en", null, "https://s3.amazonaws.com/static.api.paymentrails.com/icon_business.svg", new Compliance("pending", "2016-11-10T09:47:22.839Z"), ValidPaymentRecipientPayout, ValidPaymentRecipientAddress);
        public static readonly Payment VALID_PAYMENT = new Payment(ValidPaymentRecipient, 1, "", 0, "USD", 1, 0, 0, 2, null, "2017-05-02T17:08:11.362Z", "2017-05-02T17:08:11.362Z", 0, "USD", "B-91XPY3G229AQ8", "P-91XPY3G2FNPHJ", "active", new Compliance("pending", null));
        public static readonly Payment VALID_PAYMENT_2 = new Payment(ValidPaymentRecipient, 1, "", 0, "CAD", 1, 0, 0, 2, null, "2017-05-02T17:08:11.362Z", "2017-05-02T17:08:11.362Z", 0, "USD", "B-91XPY3G229AQ8", "P-91YPY3G2FNPHJ", "active", new Compliance("pending", null));
        private static Payment[] payments = { VALID_PAYMENT, VALID_PAYMENT_2 };
        public static readonly List<Payment> VALID_PAYMENTS = new List<Payment>(payments);

        public static readonly Balance VALID_BALANCE = new Balance(true, 1463430.27, "USD", "paymentrails", "0000848");
        public static readonly Balance VALID_BALANCE_PAYPAL = new Balance(false, 0, "CAD", "paypal", null);

        private static Compliance compliance = new Compliance("pending", null);
        private static Address address = new Address(null, null, null, null, null, null, null);
        public static readonly Recipient VALID_RECIPIENT = new Recipient("R-91XQ4VKD39C3P", "individual", "tess@example.com", "tess@example.com", "John Smith", "John", "Smith", "incomplete", null, "en", null, "https://s3.amazonaws.com/static.api.paymentrails.com/icon_user.svg", compliance, null, address);

        public static readonly Payout VALID_PAYOUT = new Payout(1000,false,1000,false,"bank", "USD", null, null);

        private static Recipient batchPaymentRecipient = new Recipient("R-918F1CE0D21BCF34", null, "Wendy_OHara1985154@gmail.com", "Wendy_OHara1985154@gmail.com", "Wendy O'Hara19851", null, null, "active", null, null, null, null, null, null, null);
        private static Payment batchPayment = new Payment(batchPaymentRecipient, 1, "", 0, "USD", 1, 0, 0, 0, null, null, null, 0, "USD", "B-91XPY33G30FN0", "P-91XPY33GF805R", "pending", new Compliance("pending", null));
        private static Payment[] batchPayments = { batchPayment };
        public static readonly Batch VALID_BATCH = new Batch("Weekly Payouts on 2017-4-2", new List<Payment>(batchPayments), "USD", 0, 1, "open", null, null, "2017-05-02T16:53:22.852Z", "2017-05-02T16:53:22.920Z", "B-91XPY33G30FN0");
        private static Batch listBatch = new Batch("Weekly Payouts on 2017-4-2", null, "USD", 0, 1, "open", null, null, "2017-05-02T16:53:22.852Z", "2017-05-02T16:53:22.920Z", "B-91XPY33G30FN0");
        private static Batch[] batches = { listBatch };
        public static readonly List<Batch> VALID_BATCH_LIST = new List<Batch>(batches);
    }
}

