using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentrails
{
    public class PaymentRails_Recipient
    {
        public static List<Types.Recipient> get()
        {
            return null;
        }
        /// <summary>
        /// Retrieves a recipient based on the recipient id given 
        /// </summary>
        /// <param name="recipient_id"></param>
        /// <param name="term"></param>
        /// <returns>The response</returns>
        public static String get(String recipient_id, String term = "")
        {
            String endPoint = "/v1/recipients/" + recipient_id + "/" + term;
            PaymentRails_Client client = PaymentRails_Client.create();
            String response = client.get(endPoint);
            Types.Recipient recipient = JsonHelpers.RecipientHelper.JsonToRecipient(response);
            return response;
        }
        /// <summary>
        /// Creates a recipient based on the body given to the client
        /// </summary>
        /// <param name="body"></param>
        /// <returns>The resonse</returns>
        public static String post(String body)
        {
            String endPoint = "/v1/recipients";
            PaymentRails_Client client = PaymentRails_Client.create();
            String response = client.post(endPoint, body);
            return response;
        }
        /// <summary>
        /// Updates a recipient based on the recipient id given and the body
        /// given to the client
        /// </summary>
        /// <param name="recipient_id"></param>
        /// <param name="body"></param>
        /// <returns>The response</returns>
        public static String patch(String recipient_id, String body)
        {
            String endPoint = "/v1/recipients/" + recipient_id;
            PaymentRails_Client client = PaymentRails_Client.create();
            String response = client.patch(endPoint, body);
            return response;
        }
        /// <summary>
        /// Deletes a recipient based on the recipient id given 
        /// </summary>
        /// <param name="recipient_id"></param>
        /// <returns>The response</returns>
        public static String delete(String recipient_id)
        {
            String endPoint = "/v1/recipients/" + recipient_id;
            PaymentRails_Client client = PaymentRails_Client.create();
            String response = client.delete(endPoint);
            return response;
        }
        /// <summary>
        /// Lists all recipients based on queries
        /// </summary>
        /// <param name="term"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns>The response</returns>
        public static String query(String term = "", int page = 1, int pageSize = 10)
        {
            String endPoint = "/v1/recipients/?" + "&search=" + term + "&page=" + page + "&pageSize=" + pageSize;
            PaymentRails_Client client = PaymentRails_Client.create();
            String response = client.get(endPoint);
            return response;
        }

    }
}
