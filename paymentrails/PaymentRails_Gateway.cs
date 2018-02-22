namespace PaymentRails
{
    public class PaymentRails_Gateway
    {
        public PaymentRails_Configuration config;
        public PaymentRails_Client client;
        public PaymentRails_Recipient_Gateway recipient;
        public PaymentRails_RecipientAccount_Gateway recipientAccount;
        public PaymentRails_Balances_Gateway balances;
        public PaymentRails_Batch_Gateway batch;
        public PaymentRails_Payment_Gateway payment;

        public string apiKey;
        public string apiSecret;
        public string apiBase;

        public PaymentRails_Gateway(PaymentRails_Configuration config)
        {
            this.config = config;
            this.client = new PaymentRails_Client(config);
            this.recipient = new PaymentRails_Recipient_Gateway(this);
            this.recipientAccount = new PaymentRails_RecipientAccount_Gateway(this);
            this.balances = new PaymentRails_Balances_Gateway(this);
            this.batch = new PaymentRails_Batch_Gateway(this);
            this.payment = new PaymentRails_Payment_Gateway(this);
        }

        public PaymentRails_Gateway(string apiKey, string apiSecret, string apiBase):this(new PaymentRails_Configuration(apiKey, apiSecret, apiBase))
        {
        }

    }
}
