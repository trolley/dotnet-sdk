using System;
using System.IO;
using System.Collections.Generic;

namespace tests
{
    class Config
    {
        public string ACCESS_KEY = "";
        public string SECRET_KEY = "";
        public string BASE_URL = "";
        public string RECIPIENT_ID = "";
        public const string TEST_BALANCE_CURRENCY = "USD";

        public Config()
        {

            string filePath = Path.Combine("../../../", ".env");

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                Dictionary<string, string> apiKeys = new Dictionary<string, string>();

                foreach (string line in lines)
                {
                    string[] parts = line.Split('=');

                    if (parts.Length == 2 && parts[1].Length > 0)
                    {
                        string key = parts[0];
                        string value = parts[1];

                        apiKeys[key] = value;
                    }
                }

                if (apiKeys.ContainsKey("ACCESS_KEY"))
                {
                    this.ACCESS_KEY = apiKeys["ACCESS_KEY"];
                }

                if (apiKeys.ContainsKey("SECRET_KEY"))
                {
                    this.SECRET_KEY = apiKeys["SECRET_KEY"];
                }

                if (apiKeys.ContainsKey("BASE_URL"))
                {
                    this.BASE_URL = apiKeys["BASE_URL"];
                }

                if (apiKeys.ContainsKey("RECIPIENT_ID"))
                {
                    this.RECIPIENT_ID = apiKeys["RECIPIENT_ID"];
                }
            }
            else
            {
                Console.WriteLine("File '.env' not found at: "+filePath);
            }
        }
    }
}