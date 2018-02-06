using PaymentRails.Types;
using System.Collections.Generic;
using System.Text;

namespace PaymentRails
{
    public class PaymentRails_Payment_Gateway
    {
        PaymentRails_Gateway gateway;
        PaymentRails_Configuration config;

        public PaymentRails_Payment_Gateway(PaymentRails_Gateway gateway)
        {
            this.gateway = gateway;
            this.config = gateway.config;
        }

        public List<Payment> search(int page, int pageNumber)
        {
            return search("", page, pageNumber, "");
        }

        public Payment find(string payment_id)
        {
            string endPoint = "/v1/payments/" + payment_id;
            string response = this.gateway.client.get(endPoint);
            Payment payment = JsonHelpers.PaymentHelper.JsonToPayment(response);
            return payment;
        }

        public Payment create(Payment payment)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/batches/{0}/payments", payment.BatchId);
            string endPoint = builder.ToString();

            string response = this.gateway.client.post(endPoint, payment);
            Payment createdPayment = JsonHelpers.PaymentHelper.JsonToPayment(response);
            return createdPayment;
        }

        public bool update(Payment payment)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/batches/{0}/payments{1}", payment.BatchId, payment.Id);
            string endPoint = builder.ToString();

            string response = this.gateway.client.patch(endPoint, payment);
            return true;
        }

        public bool delete(string paymentId, string batchId)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/batches/{0}/payments/{1}", batchId, paymentId);
            string endPoint = builder.ToString();

            string response = this.gateway.client.delete(endPoint);
            return true;
        }

        public bool delete(Payment payment)
        {
            return delete(payment.Id, payment.BatchId);
        }

        public List<Payment> search(string term = "", int page = 1, int pageSize = 10, string batchId = "")
        {
            StringBuilder builder = new StringBuilder();

            string endPoint;
            if (batchId != "")
            {
                builder.AppendFormat("/v1/batches/{0}/payments?&search={1}&page={2}&pageSize={3}", batchId, term, page, pageSize);
                endPoint = builder.ToString();
            }
            else
            {
                builder.AppendFormat("/v1/payments?&search={0}&page={1}&pageSize={2}", term, page, pageSize);
                endPoint = builder.ToString();
            }

            string jsonResponse = this.gateway.client.get(endPoint);
            List<Payment> payments = JsonHelpers.PaymentHelper.JsonToPaymentList(jsonResponse);
            return payments;
        }
    }
}
