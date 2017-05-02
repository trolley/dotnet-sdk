using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentrails
{
    public class PaymentRails_Balances
    {
        /// <summary>
        /// Retrieves all the balances
        /// Retrieves the paypal balance
        /// Retrieves the paymentrails balance
        /// </summary>
        /// <param name="type"></param>
        /// <returns>The response</returns>
        public static String get(String type = "")
        {
            String endPoint = "/v1/profile/balances/" + type;
            PaymentRails_Client client = PaymentRails_Client.create();
            String response = client.get(endPoint);
            return response;
        }

    }
}
