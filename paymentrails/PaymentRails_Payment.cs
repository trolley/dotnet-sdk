using paymentrails.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentrails
{
    public class PaymentRails_Payment
    {

        public static List<Payment> get(int page, int pageNumber)
        {
            return query("",page,pageNumber,"");
        }

        /// <summary>
        /// Retrieves the Payment based on the payment id and batch id
        /// </summary>
        /// <param name="payment_id"></param>
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
        /// <param name="body"></param>
        /// <returns>The response</returns>
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
        /// <param name="payment_id"></param>
        /// <param name="body"></param>
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
        /// <param name="payment_id"></param>
        /// <returns>The response</returns>
        public static String delete(string paymentId, string batchId)
        {
            String endPoint = "/v1/batches/" + batchId + "/payments/" + paymentId;
            PaymentRails_Client client = PaymentRails_Client.CreateClient();
            String response = client.delete(endPoint);
            return response;
        }

        public static string delete(Payment payment)
        {
            return delete(payment.Id, payment.BatchId);
        }
        /// <summary>
        /// Lists all the payments based on and batch id
        /// </summary>
        /// <param name="term"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
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
