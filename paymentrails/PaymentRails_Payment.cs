using PaymentRails.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentRails
{
    /// <summary>
    /// A Class that facilitates HTTP Requests to the API in regards to Payments.
    /// </summary>
    public class PaymentRails_Payment
    {
        /// <summary>
        /// Retrieves a ist of payments based on the page and page number
        /// </summary>
        /// <param name="page">The page number (default: 1)</param>
        /// <param name="pageNumber">Number of records in a page (default: 10)</param>
        /// <returns>A list of all payments</returns>
        public static List<Payment> get(int page, int pageNumber)
        {
            return query("",page,pageNumber,"");
        }

        /// <summary>
        /// Retrieves the Payment based on the payment id and batch id
        /// </summary>
        /// <param name="payment_id">A payment id belonging to a payment object</param>
        /// <returns>The response</returns>
        public static Payment get(String payment_id)
        {
            String endPoint = "/v1/payments/" + payment_id;
            PaymentRails_Client client = PaymentRails_Client.CreateClient();
            String response = client.get(endPoint);
            Payment payment = JsonHelpers.PaymentHelper.JsonToPayment(response);
            return payment;
        }


        /// <summary>
        /// Creates a payment based on the body and batch id
        /// </summary>
        /// <param name="payment">A payment object that will be created</param>
        /// <returns>A newley created payment object</returns>
        public static Payment post(Payment payment)
        {        
            String endPoint = "/v1/batches/"+ payment.BatchId + "/payments";
            PaymentRails_Client client = PaymentRails_Client.CreateClient();
            String response = client.post(endPoint, payment);
            Payment createdPayment = JsonHelpers.PaymentHelper.JsonToPayment(response);
            return createdPayment;
        }
        /// <summary>
        /// Updates a payment based on the payment id and batch id and body
        /// </summary>
        /// <param name="payment">A payment object that will be updated</param>
        /// <returns>The response</returns>
        public static String patch(Payment payment)
        {
            String endPoint = "/v1/batches/" + payment.BatchId + "/payments/" + payment.Id;
            PaymentRails_Client client = PaymentRails_Client.CreateClient();
            String response = client.patch(endPoint, payment);
            return response;
        }
        /// <summary>
        /// Deletes a payment based on the payment id and batch id
        /// </summary>
        /// <param name="paymentId">A payment id that belongs to a payment object</param>
        /// <param name="batchId">A batch id that belongs to a payment object</param>
        /// <returns>The response</returns>
        public static String delete(string paymentId, string batchId)
        {
            String endPoint = "/v1/batches/" + batchId + "/payments/" + paymentId;
            PaymentRails_Client client = PaymentRails_Client.CreateClient();
            String response = client.delete(endPoint);
            return response;
        }
        /// <summary>
        /// Deletes a payment based on a payment object
        /// </summary>
        /// <param name="payment">A payment object that will be deleted</param>
        /// <returns>The response</returns>
        public static string delete(Payment payment)
        {
            return delete(payment.Id, payment.BatchId);
        }
        /// <summary>
        /// Lists all the payments based on and batch id
        /// </summary>
        /// <param name="term">The page number (default: 1)</param>
        /// <param name="page">The page number (default: 1)</param>
        /// <param name="pageSize">Number of records in a page (default: 10)</param>
        /// <param name="batchId">A batch id that will have its payments returned</param>
        /// <returns>A list of payments</returns>
        public static List<Payment> query(String term = "", int page = 1, int pageSize = 10, string batchId = "")
        {
            String endPoint;
            if (batchId != "")
                endPoint = "/v1/batches/" + batchId + "/payments?" + "&search=" + term + "&page=" + page + "&pageSize=" + pageSize;
            else
                endPoint = "/v1/payments?" + "&search=" + term + "&page=" + page + "&pageSize=" + pageSize;
            PaymentRails_Client client = PaymentRails_Client.CreateClient();
            String jsonResponse = client.get(endPoint);
            List<Payment> payments = JsonHelpers.PaymentHelper.JsonToPaymentList(jsonResponse);
            return payments;
        }




    }
}
