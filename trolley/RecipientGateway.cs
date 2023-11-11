using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Trolley.Types;
using System.Collections.Generic;
using System;
using Trolley.Types.Supporting;

namespace Trolley
{
    public class RecipientGateway
    {
        Gateway gateway;

        public RecipientGateway(Gateway gateway)
        {
            this.gateway = gateway;
        }

        /// <summary>
        /// Get all recipients. You can provide a search term and pagination information.
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Recipients ListAllRecipients(string searchTerm = null, int page = 1, int pageSize = 10)
        {
            string endPoint = $"/v1/recipients?page={page}&pageSize={pageSize}";
            if(searchTerm != null && searchTerm.Length>0)
            {
                endPoint += $"&search={searchTerm}";
            }
            string response = this.gateway.client.Get(endPoint);
            return new Recipients(RecipientListFactory(response), MetaFactory(response));
        }

        /// <summary>
        /// List all recipients as an Enumerable, to iterate through the whole result set at once. Each page will have 10 items by default.
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public IEnumerable<Recipient> ListAllRecipients(string searchTerm = "")
        {
            int page = 1;
            bool shouldPaginate = true;
            while (shouldPaginate)
            {
                Recipients r = ListAllRecipients(searchTerm, page, 10);
                foreach (Recipient recipient in r.recipients)
                {
                    yield return recipient;
                }

                page++;
                if (page > r.meta.pages)
                {
                    shouldPaginate = false;
                }
            }
        }

        /// <summary>
        /// Get a recipinet by id.
        /// </summary>
        /// <param name="recipientId"> string id of the recipient which needs to be fetched.</param>
        /// <returns><c>Recipient</c></returns>
        public Recipient Get(string recipientId)
        {
            string endPoint = "/v1/recipients/" + recipientId;
            string response = this.gateway.client.Get(endPoint);

            return RecipientFactory(response);
        }

        /// <summary>
        /// Create a new Recipient.
        /// </summary>
        /// <param name="recipient"></param>
        /// <returns></returns>
        public Recipient Create(Recipient recipient)
        {
            string endPoint = "/v1/recipients";
            string response = this.gateway.client.Post(endPoint, recipient);

            return RecipientFactory(response);
        }

        /// <summary>
        /// Update a Recipient by id.
        /// </summary>
        /// <param name="recipient"></param>
        /// <returns></returns>
        public bool Update(string recipientId = null, Recipient recipient = null)
        {
            if(recipientId == null || recipientId.Length == 0)
            {
                throw new MissingFieldException("recipientId can not be null or empty");
            }

            if (recipient == null)
            {
                throw new MissingFieldException("recipient object can not be null or empty");
            }

            string endPoint = "/v1/recipients/" + recipientId;
            gateway.client.Patch(endPoint, recipient);
            return true;
        }

        /// <summary>
        /// Delete one recipient by id.
        /// </summary>
        /// <param name="recipientId"></param>
        /// <returns></returns>
        public bool Delete(string recipientId)
        {
            string endPoint = "/v1/recipients/" + recipientId;
            string response = this.gateway.client.Delete(endPoint);
            return true;
        }

        /// <summary>
        /// Delete multiple recipients by id
        /// </summary>
        /// <param name="recipientIds">An array of string containing recipinet IDs to delete</param>
        /// <returns>True if delete operation succeeded</returns>
        public bool Delete(params string[] recipientIds)
        {
            
            var deleteBody = new Dictionary<string, string[]>
            {
                { "ids", recipientIds }
            };

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                StringEscapeHandling = StringEscapeHandling.EscapeHtml
            };

            string body = JsonConvert.SerializeObject(deleteBody, settings);
            string endPoint = "/v1/recipients/";
            string response = this.gateway.client.Delete(endPoint, body);
            return true;
        }

        /// <summary>
        /// Get all recipients logs. You can provide pagination information.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Logs GetAllLogs(string recipientId = null, int page = 1, int pageSize = 10)
        {
            if (recipientId == null || recipientId.Length == 0)
            {
                throw new MissingFieldException("recipientId can not be null or empty.");
            }
            string endPoint = $"/v1/recipients/{recipientId}/logs?page={page}&pageSize={pageSize}";
            string response = this.gateway.client.Get(endPoint);
            return new Logs(LogsFactory(response), MetaFactory(response));
        }

        /// <summary>
        /// List all recipients as an Enumerable, to iterate through the whole result set at once. Each page will have 10 items by default.
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public IEnumerable<Log> GetAllLogs(string recipientId = null)
        {
            if (recipientId == null || recipientId.Length == 0)
            {
                throw new MissingFieldException("recipientId can not be null or empty.");
            }

            int page = 1;
            bool shouldPaginate = true;
            while (shouldPaginate)
            {
                Logs l = GetAllLogs(recipientId, page, 10);
                foreach (Log log in l.logs)
                {
                    yield return log;
                }

                page++;
                if (page > l.meta.pages)
                {
                    shouldPaginate = false;
                }
            }
        }

        /// <summary>
        /// Get all recipient's payments. You can provide pagination information.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Payments GetAllPayments(string recipientId = null, int page = 1, int pageSize = 10)
        {
            if (recipientId == null || recipientId.Length == 0)
            {
                throw new MissingFieldException("recipientId can not be null or empty.");
            }
            string endPoint = $"/v1/recipients/{recipientId}/payments?page={page}&pageSize={pageSize}";
            string response = this.gateway.client.Get(endPoint);
            PaymentGateway paymentGateway = new PaymentGateway(null);
            return paymentGateway.PaymentListFactory(response);
        }

        /// <summary>
        /// List all recipients as an Enumerable, to iterate through the whole result set at once. Each page will have 10 items by default.
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public IEnumerable<Payment> GetAllPayments(string recipientId = null)
        {
            if (recipientId == null || recipientId.Length == 0)
            {
                throw new MissingFieldException("recipientId can not be null or empty.");
            }

            int page = 1;
            bool shouldPaginate = true;
            while (shouldPaginate)
            {
                Payments p = GetAllPayments(recipientId, page, 10);
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

        /// <summary>
        /// Get all offline payments of the recipient, with optional searchTerm and pagination information.
        /// </summary>
        /// <param name="recipientId"></param>
        /// <param name="searchTerm"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// <exception cref="MissingFieldException"></exception>
        public OfflinePayments GetAllOfflinePayments(string recipientId, string searchTerm = null, int page = 1, int pageSize = 10)
        {
            if (recipientId == null || recipientId.Length == 0)
            {
                throw new MissingFieldException("recipientId can not be null or empty.");
            }

            string endPoint = $"/v1/recipients/{recipientId}/offlinePayments?page={page}&pageSize={pageSize}";
            if (searchTerm != null && searchTerm.Length > 0)
            {
                endPoint += $"&search={searchTerm}";
            }
            string response = this.gateway.client.Get(endPoint);
            OfflinePaymentGateway opGateway = new OfflinePaymentGateway(null);
            return opGateway.OfflinePaymentListFactory(response);

        }

        /// <summary>
        /// Get all offline payments of recipient with auto pagination of the result set, 10 items per page.
        /// </summary>
        /// <param name="recipientId"></param>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public IEnumerable<OfflinePayment> GetAllOfflinePayments(string recipientId = null, string searchTerm = null)
        {
            int page = 1;
            bool shouldPaginate = true;
            while (shouldPaginate)
            {
                OfflinePayments op = GetAllOfflinePayments(recipientId, searchTerm, page, 10);
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
        /// Construct a single <c>Recipient</c> object.
        /// </summary>
        /// <param name="response">API Response containing recipient object</param>
        /// <returns><c>Recipient</c></returns>
        private Recipient RecipientFactory(string response)
        {
            return JsonConvert.DeserializeObject<Recipient>(JObject.Parse(response)["recipient"].ToString());
        }

        /// <summary>
        /// Create a <c>List</c> of <c>Recipient</c> objects.
        /// </summary>
        /// <param name="response">API Response to extract recipient array from</param>
        /// <returns>List<Recipient></returns>
        private List<Recipient> RecipientListFactory(string response)
        {
            return JsonConvert.DeserializeObject<List<Recipient>>(JObject.Parse(response)["recipients"].ToString());
        }

        /// <summary>
        /// Create a <c>List<Log></c> object.
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private List<Log> LogsFactory(string response)
        {
            return JsonConvert.DeserializeObject<List<Log>>(JObject.Parse(response)["recipientLogs"].ToString());
        }

        /// <summary>
        /// Creates <c>Meta</c> object from API response
        /// </summary>
        /// <param name="response">API Response to extract Meta information from</param>
        /// <returns>Meta object</returns>
        private Meta MetaFactory(string response)
        {
            return JsonConvert.DeserializeObject<Meta>(JObject.Parse(response)["meta"].ToString());
        }
    }
}
