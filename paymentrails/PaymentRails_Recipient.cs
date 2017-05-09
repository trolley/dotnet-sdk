using System;
using System.Collections.Generic;
using paymentrails.Types;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentrails
{
    public class PaymentRails_Recipient
    {
        /// <summary>
        /// Retrieves a list of recipients from the API
        /// </summary>
        /// <returns>A list containing all recipient objects</returns>
        public static List<Recipient> get(int page, int pageNumber)
        {
            return PaymentRails_Recipient.query("", page, pageNumber);
        }
        /// <summary>
        /// Retrieves a recipient based on the recipient id given 
        /// </summary>
        /// <param name="recipient_id"></param>
        /// <param name="term"></param>
        /// <returns>The response</returns>
        public static Recipient get(String recipient_id, String term = "")
        {
            String endPoint = "/v1/recipients/" + recipient_id + "/" + term;
            PaymentRails_Client client = PaymentRails_Client.CreateClient();
            String response = client.get(endPoint);
            Recipient recipient = JsonHelpers.RecipientHelper.JsonToRecipient(response);
            return recipient;
        }
        /// <summary>
        /// Creates a recipient based on the body given to the client
        /// </summary>
        /// <param name="body"></param>
        /// <returns>The resonse</returns>
        public static String post(Recipient recipient)
        {
            String endPoint = "/v1/recipients";
            PaymentRails_Client client = PaymentRails_Client.CreateClient();
            String response = client.post(endPoint, recipient);
            return response;
        }
        /// <summary>
        /// Updates a recipient based on the recipient id given and the body
        /// given to the client
        /// </summary>
        /// <param name="recipient_id"></param>
        /// <param name="body"></param>
        /// <returns>The response</returns>
        public static String patch(Recipient recipient)
        {
            String endPoint = "/v1/recipients/" + recipient.Id;
            PaymentRails_Client client = PaymentRails_Client.CreateClient();
            String response = client.patch(endPoint, recipient); // change to take IPaymentRailsMappable
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
            PaymentRails_Client client = PaymentRails_Client.CreateClient();
            String response = client.delete(endPoint);
            return response;
        }
    
        public static String delete(Recipient recipient)
        {
            return delete(recipient.Id);
        }
        /// <summary>
        /// Lists all recipients based on queries
        /// </summary>
        /// <param name="term"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns>The response</returns>
        public static List<Recipient> query(String term = "", int page = 1, int pageSize = 10)
        {
   
            String endPoint = "/v1/recipients/?" + "&search=" + term + "&page=" + page + "&pageSize=" + pageSize;
            

            PaymentRails_Client client = PaymentRails_Client.CreateClient();
            String jsonResponse = client.get(endPoint);
            List<Recipient> recipients = JsonHelpers.RecipientHelper.JsonToRecipientList(jsonResponse);
            return recipients;
        }

    }
}
