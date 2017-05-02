using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentrails
{
    public class PaymentRails_Payment
    {
        public static String batchId { get; set; }

        /// <summary>
        /// Retrieves the Payment based on the payment id and batch id
        /// </summary>
        /// <param name="payment_id"></param>
        /// <returns>The response</returns>
        public static String get(String payment_id)
        {
            String endPoint = "/v1/batches/" + batchId + "/payments/" + payment_id;
            PaymentRails_Client client = PaymentRails_Client.create();
            String response = client.get(endPoint);
            return response;
        }
        /// <summary>
        /// Creates a payment based on the body and batch id
        /// </summary>
        /// <param name="body"></param>
        /// <returns>The response</returns>
        public static String post(String body)
        {        
            String endPoint = "/v1/batches/"+ batchId + "/payments";
            PaymentRails_Client client = PaymentRails_Client.create();
            String response = client.post(endPoint, body);
            return response;
        }
        /// <summary>
        /// Updates a payment based on the payment id and batch id and body
        /// </summary>
        /// <param name="payment_id"></param>
        /// <param name="body"></param>
        /// <returns>The response</returns>
        public static String patch(String payment_id, String body)
        {
            String endPoint = "/v1/batches/" + batchId + "/payments/" + payment_id;
            PaymentRails_Client client = PaymentRails_Client.create();
            String response = client.patch(endPoint, body);
            return response;
        }
        /// <summary>
        /// Deletes a payment based on the payment id and batch id
        /// </summary>
        /// <param name="payment_id"></param>
        /// <returns>The response</returns>
        public static String delete(String payment_id)
        {
            String endPoint = "/v1/batches/" + batchId + "/payments/" + payment_id;
            PaymentRails_Client client = PaymentRails_Client.create();
            String response = client.delete(endPoint);
            return response;
        }
        /// <summary>
        /// Lists all the payments based on and batch id
        /// </summary>
        /// <param name="term"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static String query(String term = "", int page = 1, int pageSize = 10)
        {
            String endPoint = "/v1/batches/" + batchId + "/payments?" + "&search=" + term + "&page=" + page + "&pageSize=" + pageSize;
            PaymentRails_Client client = PaymentRails_Client.create();
            String response = client.get(endPoint);
            return response;
        }




    }
}
