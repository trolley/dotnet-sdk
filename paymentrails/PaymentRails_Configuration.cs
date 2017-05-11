using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentRails
{
   public class PaymentRails_Configuration
    {
        private static string apiKey;
        private static string apiBase = "http://api.railz.io";

        public static string ApiKey
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

        public static string ApiBase
        {
            get
            {
                return apiBase;
            }
        }

        /// <summary>
        /// Gets the API Base --> change everywhere that this is used to use properties
        /// </summary>
        /// <returns>The APiBase</returns>
        public static String getApiBase()
        {
            return PaymentRails_Configuration.apiBase;
        }
        /// <summary>
        /// Sets the API Base --> change everywhere that this is used to use properties
        /// </summary>
        /// <param name="apiBase"></param>
        public static void setApiBase(String apiBase)
        {
            PaymentRails_Configuration.apiBase = apiBase;
        }
    }
}
