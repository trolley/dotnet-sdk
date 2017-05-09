using paymentrails.Types;

namespace paymentrailsTest
{
    class ValidResponseData
    {
        private static Payout ValidPaymentRecipientPayout = new Payout(1000, false, 1000, false, "paypal", null, null, new PaypalAccount("Ruby_Hickle7379@yahoo.ca"));
        private static Address ValidPaymentRecipientAddress = new Address();
        private static Recipient ValidPaymentRecipient = new Recipient("R-DE0366D6494349B7", "Ruby_Hickle7379@yahoo.ca", "Ruby_Hickle7379@yahoo.ca", "Ruby Hickle7379", "Ruby", "Hickle7379", "business", "active", null, "en", null, "https://s3.amazonaws.com/static.api.paymentrails.com/icon_business.svg", new Compliance("pending", "2016-11-10T09:47:22.839Z"), ValidPaymentRecipientPayout, ValidPaymentRecipientAddress);
        public static readonly Payment VALID_PAYMENT = new Payment(ValidPaymentRecipient, 0, "", 0, "USD", 1, 0, 0, 2, null, "2017-05-02T17:08:11.362Z", "2017-05-02T17:08:11.362Z", 0, "USD", "B-91XPY3G229AQ8", "P-91XPY3G2FNPHJ", "active", new Compliance("pending", "2016-11-10T09:47:22.839Z"));


    }
}
