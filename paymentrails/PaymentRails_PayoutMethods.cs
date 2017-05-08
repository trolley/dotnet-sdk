using System;
using paymentrails.Types;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentrails
{
    public class PaymentRails_PayoutMethods
    {
        /// <summary>
        /// Retrieves the payout method based on the recipient id
        /// </summary>
        /// <param name="recipient_id"></param>
        /// <returns>The response</returns>
        public static Payout get(String recipient_id)
        {
            String endPoint = "/v1/recipients/" + recipient_id + "/payout-methods";
            PaymentRails_Client client = PaymentRails_Client.create();
            String response = client.get(endPoint);
            Types.Payout payout = JsonHelpers.PayoutHelper.JsonToPayout(response);
            return payout;
        }
        /// <summary>
        /// Creates a payout method based on the recipient id and body
        /// </summary>
        /// <param name="recipient_id"></param>
        /// <param name="body"></param>
        /// <returns>The response</returns>
        public static String post(String recipient_id, Payout payout)
        {
            String endPoint = "/v1/recipients/" + recipient_id +"/payout-methods";
            PaymentRails_Client client = PaymentRails_Client.create();
            String response = client.post(endPoint, payout); // will change this method to use IPaymentRailsMappable
            return response;
        }
        /// <summary>
        /// Updates the payout method based on the recipient id and body
        /// </summary>
        /// <param name="recipient_id"></param>
        /// <param name="body"></param>
        /// <returns>The response</returns>
        public static String patch(String recipient_id, Payout payout)
        {
            String endPoint = "/v1/recipients/" + recipient_id + "/payout-methods";
            PaymentRails_Client client = PaymentRails_Client.create();
            String response = client.patch(endPoint, payout);
            return response;
        }



    }
}
