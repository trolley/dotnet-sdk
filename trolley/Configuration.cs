namespace Trolley
{
    public class Configuration
    {
        private string apiKey;
        private string apiSecret;
        private string apiBase;

        public Configuration()
        {

        }

        public Configuration(string apiKey, string apiSecret, string apiBase="production")
        {
            this.apiKey = apiKey;
            this.apiSecret = apiSecret;
            this.apiBase = enviromentToUrl(apiBase);
        }

        public static Gateway gateway()
        {
            return new Gateway(new Configuration());
        }

        public static Client client (Configuration config)
        {
            return new Client(config);
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
                case "development":
                    // TODO: Return base url from env file
                    return "";
                case "production":
                    return "https://api.trolley.com";
                default:
                   return "https://api.trolley.com";
            }
        }
    }
}
