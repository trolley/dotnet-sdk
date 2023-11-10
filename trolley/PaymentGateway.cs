using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Trolley.Types;
using System.Collections.Generic;
using System.Text;
using Trolley.Types.Supporting;

namespace Trolley
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
            string response = this.gateway.client.Get(endPoint);
            return paymentFactory(response);
        }

        public Types.Payment create(Types.Payment payment)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/batches/{0}/payments", payment.batchId);
            string endPoint = builder.ToString();

            string response = this.gateway.client.Post(endPoint, payment);
            return paymentFactory(response);
        }

        public bool update(Types.Payment payment)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/batches/{0}/payments/{1}", payment.batchId, payment.id);
            string endPoint = builder.ToString();

            Types.Payment cleanPayment = updateablePayment(payment);

            string response = this.gateway.client.Patch(endPoint, cleanPayment);
            return true;
        }

        public bool delete(string paymentId, string batchId)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/batches/{0}/payments/{1}", batchId, paymentId);
            string endPoint = builder.ToString();

            string response = this.gateway.client.Delete(endPoint);
            return true;
        }

        public bool delete(Types.Payment payment)
        {
            return delete(payment.id, payment.batchId);
        }

        public IEnumerable<Payment> listAllPayments(string searchTerm = "", string batchId = "")
        {
            int page = 1;
            bool shouldPaginate = true;
            while (shouldPaginate)
            {
                Payments p = search(searchTerm, page, 10, batchId);
                foreach (Payment payment in p.payments)
                {
                    yield return payment;
                }

                page++;
                if (page > p.meta.pages)
                {
                    shouldPaginate = false;
                }
            }
        }

        public Payments search(int page, int pageNumber)
        {
            return search("", page, pageNumber, "");
        }

        public Payments search(string term = null, int page = 1, int pageSize = 10, string batchId = "")
        {
            PaymentQueryParams queryParams = new PaymentQueryParams { page = page, pageSize = pageSize, term = term };

            return batchId != "" ? search(batchId, queryParams) : search(queryParams);
        }

        public Payments search(string batchId)
        {
            return search(batchId, new PaymentQueryParams()); 
        }

        public Payments search(PaymentQueryParams queryParams)
        {
            string endPoint = "/v1/payments?&" + queryParams.buildQueryString();
            
            string jsonResponse = this.gateway.client.Get(endPoint);
            return paymentListFactory(jsonResponse);
        }

        public Payments search(string batchId, PaymentQueryParams queryParams)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/batches/{0}/payments?&{1}", batchId, queryParams.buildQueryString());
            string endPoint = builder.ToString();

            string jsonResponse = this.gateway.client.Get(endPoint);

            return paymentListFactory(jsonResponse);
        }

        public Types.Payment paymentFactory(string response)
        {
            var tempData = JObject.Parse(response)["payment"];
            Types.Payment payment = JsonConvert.DeserializeObject<Types.Payment>(tempData.ToString());
            return payment;
        }

        public Payments paymentListFactory(string response)
        {
            var tempData = JObject.Parse(response)["payments"];
            List<Types.Payment> paymentsFromResponse = JsonConvert.DeserializeObject<List<Types.Payment>>(tempData.ToString(), new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            });

            var tempMeta = JObject.Parse(response)["meta"];
            Meta meta = JsonConvert.DeserializeObject<Meta>(tempMeta.ToString(), new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            });

            Payments payments = new Payments(paymentsFromResponse, meta);
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
