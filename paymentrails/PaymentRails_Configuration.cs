namespace PaymentRails
{
    public class PaymentRails_Configuration
    {
        private string apiKey;
        private string apiSecret;
        private string apiBase;

        public PaymentRails_Configuration()
        {

        }

        public PaymentRails_Configuration(string apiKey, string apiSecret, string apiBase)
        {
            this.apiKey = apiKey;
            this.apiSecret = apiSecret;
            this.apiBase = enviromentToUrl(apiBase);
        }

        public static PaymentRails_Gateway gateway()
        {
            return new PaymentRails_Gateway(new PaymentRails_Configuration());
        }

        public static PaymentRails_Client client (PaymentRails_Configuration config)
        {
            return new PaymentRails_Client(config);
        }

        public string ApiKey
        {
            get
            {
                return apiKey;
            }
            set
            {
                apiKey = value;
            }
        }
        
        public string ApiSecret
        {
            get
            {
                return apiSecret;
            }
            set
            {
                apiSecret = value;
            }
        }

        public string ApiBase
        {
            get
            {
                return apiBase;
            }
            set
            {
                apiBase = enviromentToUrl(value);
            }
        }


        public string enviromentToUrl(string enviroment)
        {
            switch (enviroment)
            {
                case "integration":
                    return "http://api.local.dev:3000";
                case "development":
                    return "http://api.railz.io";
                case "sandbox":
                    return "https://api.paymentrails.com";
                case "production":
                    return "https://api.paymentrails.com";
                default:
                   return "https://api.paymentrails.com";
            }
        }
    }
}
