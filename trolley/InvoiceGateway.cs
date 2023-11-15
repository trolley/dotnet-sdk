using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Trolley.Types;
using System.Collections.Generic;
using System;
using Trolley.Types.Supporting;

namespace Trolley
{
    public class InvoiceGateway
    {
        Gateway gateway;

        public InvoiceGateway(Gateway gateway)
        {
            this.gateway = gateway;
        }

        public InvoiceGateway()
        {
        }

        /// <summary>
        /// Get an invoice by invoice ID.
        /// </summary>
        /// <param name="invoiceId"> string id of the invoice which needs to be fetched.</param>
        /// <returns><c>Invoice</c></returns>
        public Invoice Get(string invoiceId)
        {
            string body = JsonConvert.SerializeObject(new Dictionary<string, string>
            {
                { "invoiceId", invoiceId }
            });

            string endPoint = "/v1/invoices/get";
            string response = this.gateway.client.Post(endPoint, body);

            return InvoiceFactory(response);
        }

        /// <summary>
        /// Create a new Invoice.
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public Invoice Create(Invoice invoice)
        {
            string endPoint = "/v1/invoices/create";
            string response = this.gateway.client.Post(endPoint, invoice);

            return InvoiceFactory(response);
        }

        /// <summary>
        /// Update an Invoice. You should supply the object set with the updated values and set the <c>invoiceId</c> variable of the object as the invoice id of the invoice you want to update.
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public Invoice Update(Invoice invoice)
        {
            if(invoice == null)
            {
                throw new MissingFieldException("invoice object can not be null.");
            }

            string endPoint = "/v1/invoices/update";
            string response = gateway.client.Post(endPoint, invoice);
            return InvoiceFactory(response);
        }

        /// <summary>
        /// Delete multiple invoices by invoice Ids.
        /// </summary>
        /// <param name="invoiceId">a string[] of invoiceIds</param>
        /// <returns></returns>
        public bool Delete(params string[] invoiceId)
        {
            var deleteBody = new Dictionary<string, string[]>
            {
                { "invoiceIds", invoiceId }
            };
            string body = JsonConvert.SerializeObject(deleteBody);
            string endPoint = "/v1/invoices/delete";
            string response = this.gateway.client.Post(endPoint, body);
            return true;
        }

        /// <summary>
        /// Search invoices by multiple options such as by invoiceId, recipientId etc.
        /// Note: This method supports pagination.
        /// Depending on what you want to search by, you'll either provide a {@code List<String>} parameter, or a
        /// String parameter. Details about when to provide which parameter are given in the parameter.
        /// list.
        ///
        /// These options correspond to our documentation.
        /// </summary>
        /// <param name="searchBy">Which paremter you want to search by, use Enum from <c>Types.Supporting.SearchBy</c></param>
        /// <param name="page">page number</param>
        /// <param name="pageSize">items per page</param>
        /// <param name="param">if SearchBy is set to <c>invoiceDate</c>, then invoice date in string format</param>
        /// <param name="parameters">if SearchBy is set to anything other <c>invoiceDate</c>, then relevant parameter in a string[] format</param>
        /// <returns>Invoices</returns>
        /// <exception cref="MissingFieldException"></exception>
        public Invoices Search(SearchBy searchBy, int page, int pageSize, string param, params string[] parameters)
        {
            string endPoint = "/v1/invoices/search";
            string body = "";

            if (searchBy == SearchBy.InvoiceDate)
            {
                var searchBody = new Dictionary<string, string>
                {
                    { "invoiceDate", param }
                };
                body = JsonConvert.SerializeObject(searchBody);
            }
            else
            {
                var searchBody = new Dictionary<string, string[]>
                {
                    { GetParameterKeyFromEnum(searchBy), parameters }
                };
                body = JsonConvert.SerializeObject(searchBody);
            }

            string response = this.gateway.client.Post(endPoint, body);
            return InvoiceListFactory(response);
        }

        /// <summary>
        /// Search invoices by multiple options such as by invoiceId, recipientId etc.
        /// Note: This method auto paginates, starting from first page and going further with 10 items per page.
        /// Depending on what you want to search by, you'll either provide a {@code List<String>} parameter, or a
        /// String parameter. Details about when to provide which parameter are given in the parameter.
        /// list.
        ///
        /// These options correspond to our documentation.
        /// </summary>
        /// <param name="searchBy">Which paremter you want to search by, use Enum from <c>Types.Supporting.SearchBy</c></param>
        /// <param name="param">if SearchBy is set to <c>invoiceDate</c>, then invoice date in string format</param>
        /// <param name="parameters">if SearchBy is set to anything other <c>invoiceDate</c>, then relevant parameter in a string[] format</param>
        /// <returns>Invoices</returns>
        /// <exception cref="MissingFieldException"></exception>
        public IEnumerable<Invoice> Search(SearchBy searchBy, string param, params string[] parameters)
        {
            int page = 1;
            bool shouldPaginate = true;
            while (shouldPaginate)
            {
                Invoices i = Search(searchBy, page, 10, param, parameters);
                foreach (Invoice invoice in i.invoices)
                {
                    yield return invoice;
                }

                page++;
                if (page > i.meta.pages)
                {
                    shouldPaginate = false;
                }
            }
        }

        /// <summary>
        /// Construct a single <c>Invoice</c> object.
        /// </summary>
        /// <param name="response">API Response containing recipient object</param>
        /// <returns><c>Invoice</c></returns>
        public Invoice InvoiceFactory(string response)
        {
            return JsonConvert.DeserializeObject<Invoice>(JObject.Parse(response)["invoice"].ToString());
        }

        /// <summary>
        /// Create a <c>List</c> of <c>Invoice</c> objects.
        /// </summary>
        /// <param name="response">API Response to extract recipient array from</param>
        /// <returns>Invoices object, containing List<Invoice> and Meta</returns>
        private Invoices InvoiceListFactory(string response)
        {
            return new Invoices(JsonConvert.DeserializeObject<List<Invoice>>(JObject.Parse(response)["invoices"].ToString()),
                JsonConvert.DeserializeObject<Meta>(JObject.Parse(response)["meta"].ToString()));
        }

        /// <summary>
        /// Get search parameter name from the Enum selected
        /// </summary>
        /// <param name="searchBy"></param>
        /// <returns></returns>
        /// <exception cref="MissingFieldException"></exception>
        private string GetParameterKeyFromEnum(SearchBy searchBy)
        {
            switch (searchBy)
            {
                case SearchBy.ExternalId:
                    return "externalId";
                case SearchBy.InvoiceId:
                    return "invoiceIds";
                case SearchBy.InvoiceNumber:
                    return "invoiceNumber";
                case SearchBy.RecipientId:
                    return "recipientId";
                case SearchBy.Tags:
                    return "tags";
                default:
                    throw new MissingFieldException("Unusual value for Enum of type SearchBy");
            }

        }
    }
}
