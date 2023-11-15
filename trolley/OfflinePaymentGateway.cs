using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Trolley.Types;
using System.Collections.Generic;
using System.Text;
using Trolley.Types.Supporting;
using System;

namespace Trolley
{
    public class OfflinePaymentGateway
    {
        Gateway gateway;

        public OfflinePaymentGateway(Gateway gateway)
        {
            this.gateway = gateway;
        }

        /// <summary>
        /// Create a new Offline Payment
        /// </summary>
        /// <param name="recipientId"></param>
        /// <param name="offlinePayment"></param>
        /// <returns></returns>
        /// <exception cref="MissingFieldException"></exception>
        public OfflinePayment Create(string recipientId, OfflinePayment offlinePayment)
        {
            if (recipientId == null || recipientId.Length == 0)
            {
                throw new MissingFieldException("recipientId can not null or empty.");
            }

            if (offlinePayment == null)
            {
                throw new MissingFieldException("offlinePayment object can not be null.");
            }

            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/recipients/{0}/offlinePayments/", recipientId);
            string endPoint = builder.ToString();

            string response = this.gateway.client.Post(endPoint, offlinePayment);
            return OfflinePaymentFactory(response);
        }

        /// <summary>
        /// Update a recipient's offline payment with id of the offline payment.
        /// </summary>
        /// <param name="recipientId"></param>
        /// <param name="offlinePaymentId"></param>
        /// <param name="offlinePayment"></param>
        /// <returns></returns>
        /// <exception cref="MissingFieldException"></exception>
        public bool Update(string recipientId, string offlinePaymentId, OfflinePayment offlinePayment)
        {
            if (recipientId == null || recipientId.Length == 0)
            {
                throw new MissingFieldException("recipientId can not null or empty.");
            }

            if (offlinePaymentId == null || offlinePaymentId.Length == 0)
            {
                throw new MissingFieldException("offlinePaymentId can not null or empty.");
            }

            if (offlinePayment == null)
            {
                throw new MissingFieldException("offlinePayment object can not be null.");
            }

            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/recipients/{0}/offlinePayments/{1}", recipientId, offlinePaymentId);
            string endPoint = builder.ToString();

            string response = this.gateway.client.Patch(endPoint, offlinePayment);
            return true;
        }

        /// <summary>
        /// Delete an offline payment.
        /// </summary>
        /// <param name="recipientId"></param>
        /// <param name="offlinePaymentId"></param>
        /// <returns></returns>
        /// <exception cref="MissingFieldException"></exception>
        public bool Delete(string recipientId, string offlinePaymentId)
        {
            if (recipientId == null || recipientId.Length == 0)
            {
                throw new MissingFieldException("recipientId can not be null or empty.");
            }

            if (offlinePaymentId == null || offlinePaymentId.Length == 0)
            {
                throw new MissingFieldException("offlinePaymentId can not be null or empty.");
            }

            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/recipients/{0}/offlinePayments/{1}", recipientId, offlinePaymentId);
            string endPoint = builder.ToString();

            string response = this.gateway.client.Delete(endPoint);
            return true;
        }

        /// <summary>
        /// Get all offline payments with auto pagination of the result set, 10 items per page.
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public IEnumerable<OfflinePayment> ListAllOfflinePayments(string searchTerm = "")
        {
            int page = 1;
            bool shouldPaginate = true;
            while (shouldPaginate)
            {
                OfflinePayments op = ListAllOfflinePayments(searchTerm, page, 10);
                foreach (OfflinePayment offlinePayment in op.offlinePayments)
                {
                    yield return offlinePayment;
                }

                page++;
                if (page > op.meta.pages)
                {
                    shouldPaginate = false;
                }
            }
        }

        /// <summary>
        /// List all offline payments, optionally with search term and pagination option
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public OfflinePayments ListAllOfflinePayments(string searchTerm = "", int page = 1, int pageSize = 10)
        {
            string endPoint = $"/v1/offline-payments?page={page}&pageSize={pageSize}";
            if (searchTerm != null && searchTerm.Length > 0)
            {
                endPoint += $"&search={searchTerm}";
            }
            string response = this.gateway.client.Get(endPoint);
            return OfflinePaymentListFactory(response);
        }

        /// <summary>
        /// Generates an OfflinePayment object from the JSON response received from the API
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public OfflinePayment OfflinePaymentFactory(string response)
        {
            var tempData = JObject.Parse(response)["offlinePayment"];
            OfflinePayment offlinePayment = JsonConvert.DeserializeObject<OfflinePayment>(tempData.ToString());
            return offlinePayment;
        }

        /// <summary>
        /// Generates an OfflinePayments object, with a <c>List<OfflinePayment></c> and <c>Meta</c>, from JSON response received from the API.
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public OfflinePayments OfflinePaymentListFactory(string response)
        {
            var tempData = JObject.Parse(response)["offlinePayments"];
            List<OfflinePayment> opFromResponse = JsonConvert.DeserializeObject<List<OfflinePayment>>(tempData.ToString(), new JsonSerializerSettings
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

            OfflinePayments offlinePayments = new OfflinePayments(opFromResponse, meta);
            return offlinePayments;
        }
    }
}
