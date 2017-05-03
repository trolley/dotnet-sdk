using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentrails
{
   public class PaymentRails_Configuration
    {
        public static string apiKey
        {
            get;   
            set;
        }

        private static string apiBase = "http://api.railz.io";
        /// <summary>
        /// Gets the API Base
        /// </summary>
        /// <returns>The APiBase</returns>
        public static String getApiBase()
        {
            return PaymentRails_Configuration.apiBase;
        }
        /// <summary>
        /// Sets the API Base
        /// </summary>
        /// <param name="apiBase"></param>
        public static void setApiBase(String apiBase)
        {
            PaymentRails_Configuration.apiBase = apiBase;
        }
    }
}
