using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Trolley.Types;
using System.Collections.Generic;
using System;
using Trolley.Types.Supporting;
using System.Text;
using Trolley.JsonHelpers;

namespace Trolley
{
    public class InvoicePaymentGateway
    {
        Gateway gateway;

        public InvoicePaymentGateway(Gateway gateway)
        {
            this.gateway = gateway;
        }

        public InvoicePaymentGateway()
        {
        }

        /// <summary>
        /// Create a new Invoice Payment.
        /// </summary>
        /// <param name="batchId"></param>
        /// <param name="invoicePaymentParts"></param>
        /// <returns></returns>
        [Obsolete("Please use Create(InvoicePaymentRequest) instead.")]
        public InvoicePayment Create(string batchId = null, params InvoicePaymentPart[] invoicePaymentParts)
        {
            string body = "";

            if (batchId != null)
            {
                var requestBody = new
                {
                    batchId = batchId,
                    ids = invoicePaymentParts
                };

                body = JsonConvert.SerializeObject(requestBody, SerializerHelper.GetSerializerSettings());
            }
            else
            {
                var requestBody = new
                {
                    ids = invoicePaymentParts
                };

                body = JsonConvert.SerializeObject(requestBody, SerializerHelper.GetSerializerSettings());
            }

            string endPoint = "/v1/invoices/payment/create/";

            string response = this.gateway.client.Post(endPoint, body);

            return InvoicePaymentFactory(response);
        }        

        /// <summary>
        /// Create a new Invoice Payment with the optional payment fields.
        /// </summary>
        /// <param name="batchId"></param>
        /// <param name="invoicePaymentParts"></param>
        /// <returns></returns>
        public InvoicePayment Create(InvoicePaymentRequest invoicePaymentRequest)
        {
            string endPoint = "/v1/invoices/payment/create/";

            string response = this.gateway.client.Post(
                endPoint, 
                JsonConvert.SerializeObject(invoicePaymentRequest, SerializerHelper.GetSerializerSettings()));

            return InvoicePaymentFactory(response);
        }

        /// <summary>
        /// Update an Invoice Payment. You should supply the object set with the id values, along with the updated amount values.
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public bool Update(InvoicePaymentPart invoicePaymentPart)
        {
            if(invoicePaymentPart == null)
            {
                throw new MissingFieldException("invoice payment object can not be null.");
            }

            string endPoint = "/v1/invoices/payment/update";
            string response = gateway.client.Post(endPoint, invoicePaymentPart);
            return true;
        }

        /// <summary>
        /// Delete multiple invoices by invoice Ids.
        /// </summary>
        /// <param name="invoiceId">a string[] of invoiceIds</param>
        /// <returns></returns>
        public bool Delete(string paymentId = null, params string[] invoiceLineIds)
        {
            if (paymentId == null && paymentId.Length == 0)
            {
                throw new MissingFieldException("paymentId needs to be set.");
            }

            var deleteBody = new
            {
                paymentId = paymentId,
                invoiceLineIds = invoiceLineIds
            };

            string body = JsonConvert.SerializeObject(deleteBody);
            string endPoint = "/v1/invoices/payment/delete";
            string response = this.gateway.client.Post(endPoint, body);
            return true;
        }

        /// <summary>
        /// Search Invoice Payments using multiple options such as by invoiceIds or paymentIds.
        /// At least of them is required.
        /// Note: This method supports pagination.
        /// </summary>
        /// <param name="invoiceIds"></param>
        /// <param name="paymentIds"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <exception cref="MissingFieldException"></exception>
        public InvoicePayments Search(string[] invoiceIds, string[] paymentIds, int page = 1, int pageSize = 10)
        {
            if (invoiceIds.Length == 0 && paymentIds.Length == 0)
            {
                throw new MissingFieldException("Either invoiceIds or paymentIds need to be set.");
            }

            StringBuilder builder = new StringBuilder();
            builder.Append("{");

            if (invoiceIds != null && invoiceIds.Length >= 0)
            {
                builder.AppendFormat("\n\"invoiceIds\" : {0},", JsonConvert.SerializeObject(invoiceIds, SerializerHelper.GetSerializerSettings()));
            }
            if (paymentIds != null && paymentIds.Length >= 0)
            {
                builder.AppendFormat("\n\"paymentIds\" : {0},", JsonConvert.SerializeObject(paymentIds, SerializerHelper.GetSerializerSettings()));
            }
            

            builder.AppendFormat("\n\"page\" : {0},", page);
            builder.AppendFormat("\n\"pageSize\" : {0}", pageSize);
            builder.Append("\n}");

            string body = builder.ToString(); ;

            string endPoint = "/v1/invoices/payment/search";
            string response = this.gateway.client.Post(endPoint, body);

            return InvoicePaymentListFactory(response);
        }

        /// <summary>
        /// Search Invoice Payments using multiple options such as by invoiceIds or paymentIds.
        /// At least of them is required.
        /// Note: This method supports pagination.
        /// </summary>
        /// <param name="invoiceIds"></param>
        /// <param name="paymentIds"></param>
        /// <exception cref="MissingFieldException"></exception>
        public IEnumerable<InvoicePayment> Search(string[] invoiceIds, string[] paymentIds)
        {
            int page = 1;
            bool shouldPaginate = true;
            while (shouldPaginate)
            {
                InvoicePayments invPayments = Search(invoiceIds, paymentIds,page, 10);
                foreach (InvoicePayment invoicePayment in invPayments.invoicePayments)
                {
                    yield return invoicePayment;
                }

                page++;
                if (page > invPayments.meta.pages)
                {
                    shouldPaginate = false;
                }
            }
        }

        /// <summary>
        /// Construct a single <c>InvoicePayment</c> object.
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public InvoicePayment InvoicePaymentFactory(string response)
        {
            return JsonConvert.DeserializeObject<InvoicePayment>(JObject.Parse(response)["invoicePayment"].ToString());
        }

        /// <summary>
        /// Create a <c>List</c> of <c>InvoicePayment</c> objects along with <c>Meta information</c>.
        /// </summary>
        /// <param name="response">API Response to extract recipient array from</param>
        /// <returns>InvoicePayments object, containing List<InvoicePayment> and Meta</returns>
        private InvoicePayments InvoicePaymentListFactory(string response)
        {
            return new InvoicePayments(JsonConvert.DeserializeObject<List<InvoicePayment>>(JObject.Parse(response)["invoicePayments"].ToString()),
                JsonConvert.DeserializeObject<Meta>(JObject.Parse(response)["meta"].ToString()));
        }
    }
}
