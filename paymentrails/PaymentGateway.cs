using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PaymentRails.Types;
using System.Collections.Generic;
using System.Text;

namespace PaymentRails
{
    public class PaymentGateway
    {
        Gateway gateway;

        public PaymentGateway(Gateway gateway)
        {
            this.gateway = gateway;
        }

      

        public Types.Payment find(string payment_id)
        {
            string endPoint = "/v1/payments/" + payment_id;
            string response = this.gateway.client.get(endPoint);
            return paymentFactory(response);
        }

        public Types.Payment create(Types.Payment payment)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/batches/{0}/payments", payment.batchId);
            string endPoint = builder.ToString();

            string response = this.gateway.client.post(endPoint, payment);
            return paymentFactory(response);
        }

        public bool update(Types.Payment payment)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/batches/{0}/payments/{1}", payment.batchId, payment.id);
            string endPoint = builder.ToString();

            Types.Payment cleanPayment = updateablePayment(payment);

            string response = this.gateway.client.patch(endPoint, cleanPayment);
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

        public bool delete(Types.Payment payment)
        {
            return delete(payment.id, payment.batchId);
        }

        public List<Types.Payment> search(int page, int pageNumber)
        {
            return search("", page, pageNumber, "");
        }

        public List<Types.Payment> search(string term = null, int page = 1, int pageSize = 10, string batchId = "")
        {
            PaymentQueryParams queryParams = new PaymentQueryParams { page = page, pageSize = pageSize, term = term };

            return batchId != "" ? search(batchId, queryParams) : search(queryParams);
        }

        public List<Types.Payment> search(string batchId)
        {
            return search(batchId, new PaymentQueryParams()); 
        }

        public List<Types.Payment> search(PaymentQueryParams queryParams)
        {
            string endPoint = "/v1/payments?&" + queryParams.buildQueryString();
            
            string jsonResponse = this.gateway.client.get(endPoint);
            return paymentListFactory(jsonResponse);
        }

        public List<Types.Payment> search(string batchId, PaymentQueryParams queryParams)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/batches/{0}/payments?&{1}", batchId, queryParams.buildQueryString());
            string endPoint = builder.ToString();

            string jsonResponse = this.gateway.client.get(endPoint);
            return paymentListFactory(jsonResponse);
        }

        private Types.Payment paymentFactory(string response)
        {
            var tempData = JObject.Parse(response)["payment"];
            Types.Payment payment = JsonConvert.DeserializeObject<Types.Payment>(tempData.ToString());
            return payment;
        }
        private List<Types.Payment> paymentListFactory(string response)
        {
            var tempData = JObject.Parse(response)["payments"];
            List<Types.Payment> payments = JsonConvert.DeserializeObject<List<Types.Payment>>(tempData.ToString());
            return payments;
        }

        private Types.Payment updateablePayment(Types.Payment payment)
        {
            if (payment.amount > 0)
            {
                payment.sourceAmount = 0;
                payment.targetAmount = 0;
            }
            return payment;
        }
    }
}
