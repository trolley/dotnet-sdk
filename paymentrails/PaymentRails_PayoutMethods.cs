using System;
using paymentrails.Types;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentrails
{
    /// <summary>
    /// A Class that facilitates HTTP Requests to the API in regards to Payout Methods.
    /// </summary>
    public class PaymentRails_PayoutMethods
    {
        /// <summary>
        /// Retrieves the payout method based on the recipient id
        /// </summary>
        /// <param name="recipient_id">A recipient id that will have its payout methods returned</param>
        /// <returns>The A payout object</returns>
        public static Payout get(String recipient_id)
        {
            String endPoint = "/v1/recipients/" + recipient_id + "/payout-methods";
            PaymentRails_Client client = PaymentRails_Client.CreateClient();
            String response = client.get(endPoint);
            Types.Payout payout = JsonHelpers.PayoutHelper.JsonToPayout(response);
            return payout;
        }
        /// <summary>
        /// Creates a payout method based on the recipient id and body
        /// </summary>
        /// <param name="recipient_id">A recipient id that will have a payout method created</param>
        ///<param name="payout">A payout object that will be created</param>
        /// <returns>A newly created payout object</returns>
        public static Payout post(String recipient_id, Payout payout)
        {
            String endPoint = "/v1/recipients/" + recipient_id +"/payout-methods";
            PaymentRails_Client client = PaymentRails_Client.CreateClient();
            String response = client.post(endPoint, payout); // will change this method to use IPaymentRailsMappable
            Payout createdPayout = JsonHelpers.PayoutHelper.JsonToPayout(response);
            return createdPayout;
        }
        /// <summary>
        /// Updates the payout method based on the recipient id and body
        /// </summary>
        /// <param name="recipient_id">A recipient id that will have its payout method updated</param>
        /// <param name="payout">A payout object</param>
        /// <returns>The response</returns>
        public static String patch(String recipient_id, Payout payout)
        {
            String endPoint = "/v1/recipients/" + recipient_id + "/payout-methods";
            PaymentRails_Client client = PaymentRails_Client.CreateClient();
            String response = client.patch(endPoint, payout);
            return response;
        }



    }
}
