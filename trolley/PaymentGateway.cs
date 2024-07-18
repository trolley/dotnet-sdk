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

        public Payment Get(string paymentId)
        {
            string endPoint = "/v1/payments/" + paymentId;
            string response = this.gateway.client.Get(endPoint);
            return PaymentFactory(response);
        }

        public Payment Create(Payment payment)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/batches/{0}/payments", payment.batchId);
            string endPoint = builder.ToString();

            // Remove values unnecessary for Payment creation
            payment.batchId=null;
            Recipient r = new Recipient();
            r.id = payment.recipient.id;
            payment.recipient = r;

            string response = this.gateway.client.Post(endPoint, payment);
            return PaymentFactory(response);
        }

        public bool Update(Payment payment)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/batches/{0}/payments/{1}", payment.batchId, payment.id);
            string endPoint = builder.ToString();

            Payment cleanPayment = UpdateablePayment(payment);

            string response = this.gateway.client.Patch(endPoint, cleanPayment);
            return true;
        }

        public bool Delete(string paymentId, string batchId)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/batches/{0}/payments/{1}", batchId, paymentId);
            string endPoint = builder.ToString();

            string response = this.gateway.client.Delete(endPoint);
            return true;
        }

        public bool Delete(Payment payment)
        {
            return Delete(payment.id, payment.batchId);
        }

        public IEnumerable<Payment> ListAllPayments(string searchTerm = "", string batchId = "")
        {
            int page = 1;
            bool shouldPaginate = true;
            while (shouldPaginate)
            {
                Payments p = Search(searchTerm, page, 10, batchId);
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

        public Payments Search(int page, int pageNumber)
        {
            return Search("", page, pageNumber, "");
        }

        public Payments Search(string term = null, int page = 1, int pageSize = 10, string batchId = "")
        {
            PaymentQueryParams queryParams = new PaymentQueryParams { page = page, pageSize = pageSize, term = term };

            return batchId != "" ? Search(batchId, queryParams) : Search(queryParams);
        }

        public Payments Search(string batchId)
        {
            return Search(batchId, new PaymentQueryParams()); 
        }

        public Payments Search(PaymentQueryParams queryParams)
        {
            string endPoint = "/v1/payments?&" + queryParams.buildQueryString();
            
            string jsonResponse = this.gateway.client.Get(endPoint);
            return PaymentListFactory(jsonResponse);
        }

        public Payments Search(string batchId, PaymentQueryParams queryParams)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/batches/{0}/payments?&{1}", batchId, queryParams.buildQueryString());
            string endPoint = builder.ToString();

            string jsonResponse = this.gateway.client.Get(endPoint);

            return PaymentListFactory(jsonResponse);
        }

        public Payment PaymentFactory(string response)
        {
            var tempData = JObject.Parse(response)["payment"];
            Payment payment = JsonConvert.DeserializeObject<Payment>(tempData.ToString());
            return payment;
        }

        public Payments PaymentListFactory(string response)
        {
            var tempData = JObject.Parse(response)["payments"];
            List<Payment> paymentsFromResponse = JsonConvert.DeserializeObject<List<Payment>>(tempData.ToString(), new JsonSerializerSettings
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

        private Payment UpdateablePayment(Payment payment)
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
