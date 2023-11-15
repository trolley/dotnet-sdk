namespace Trolley
{
    public class Gateway
    {
        public Configuration config;
        public Client client;
        public RecipientGateway recipient;
        public RecipientAccountGateway recipientAccount;
        public BalancesGateway balances;
        public BatchGateway batch;
        public PaymentGateway payment;
        public OfflinePaymentGateway offlinePayment;
        public InvoiceGateway invoice;
        public InvoiceLineGateway invoiceLine;
        public InvoicePaymentGateway invoicePayment;

        public string apiKey;
        public string apiSecret;
        public string apiBase;

        public Gateway(Configuration config)
        {
            this.config = config;
            this.client = new Client(config);
            this.recipient = new RecipientGateway(this);
            this.recipientAccount = new RecipientAccountGateway(this);
            this.balances = new BalancesGateway(this);
            this.batch = new BatchGateway(this);
            this.payment = new PaymentGateway(this);
            this.offlinePayment = new OfflinePaymentGateway(this);
            this.invoice = new InvoiceGateway(this);
            this.invoiceLine = new InvoiceLineGateway(this);
            this.invoicePayment = new InvoicePaymentGateway(this);
        }

        public Gateway(string apiKey, string apiSecret, string apiBase = "production"):this(new Configuration(apiKey, apiSecret, apiBase))
        {
        }

    }
}
