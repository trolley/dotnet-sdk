using System;
using System.Collections.Generic;
using paymentrails.Types;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentrails
{
    /// <summary>
    /// A Class that facilitates HTTP Requests to the API in regards to Recipients.
    /// </summary>
    public class PaymentRails_Recipient
    {
        /// <summary>
        /// Retrieves a list of recipients from the API
        /// </summary>
        /// <param name="page">The page number (default: 1)</param>
        /// <param name="pageNumber">Number of records in a page (default: 10)</param>
        /// <returns>A list containing all recipient objects</returns>
        public static List<Recipient> get(int page, int pageNumber)
        {
            return PaymentRails_Recipient.query("", page, pageNumber);
        }
        /// <summary>
        /// Retrieves either the logs or payments of a recipient object
        /// </summary>
        /// <param name="recipient_id">The recipient id that belongs to a recipient bject </param>
        /// <param name="term">An optional term that can be logs or payments. Using a term will result
        /// in a the logs or payments being returned </param>
        /// <returns>The response</returns>
        public static String get(String recipient_id, String term = "")
        {
            String endPoint = "/v1/recipients/" + recipient_id + "/" + term;
            PaymentRails_Client client = PaymentRails_Client.CreateClient();
            String response = client.get(endPoint);
            return response;
        }
        /// <summary>
        /// Creates a recipient based on the body given to the client
        /// </summary>
        /// <param name="recipient">A recipient object that will be created</param>
        /// <returns>A newly created recipient object</returns>
        public static Recipient post(Recipient recipient)
        {
            String endPoint = "/v1/recipients";
            PaymentRails_Client client = PaymentRails_Client.CreateClient();
            String response = client.post(endPoint, recipient);
            Recipient createdRecipient = JsonHelpers.RecipientHelper.JsonToRecipient(response);
            return createdRecipient;
        }
        /// <summary>
        /// Updates a recipient based on the recipient id given and the body
        /// given to the client
        /// </summary>
        ///<param name="recipient">A recipient object that will be updated</param>
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
        /// <param name="recipient_id">A recipient id belonging to a recipient object</param>
        /// <returns>The response</returns>
        public static String delete(String recipient_id)
        {
            String endPoint = "/v1/recipients/" + recipient_id;
            PaymentRails_Client client = PaymentRails_Client.CreateClient();
            String response = client.delete(endPoint);
            return response;
        }
        /// <summary>
        /// Deletes a recipient based on a recipient object
        /// </summary>
        /// <param name="recipient">A recipient object that will be deleted</param>
        /// <returns>The response</returns>
        public static String delete(Recipient recipient)
        {
            return delete(recipient.Id);
        }
        /// <summary>
        /// Lists all recipients based on queries
        /// </summary>
        /// <param name="term">Wildcard search of the recipient-id</param>
        /// <param name="page">The page number (default: 1)</param>
        /// <param name="pageSize">Number of records in a page (default: 10)</param>
        /// <returns>A list of recipients</returns>
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
