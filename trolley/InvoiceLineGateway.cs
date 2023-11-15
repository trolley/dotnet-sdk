using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Trolley.Types;
using System.Collections.Generic;
using System;
using Trolley.Types.Supporting;

namespace Trolley
{
    public class InvoiceLineGateway
    {
        Gateway gateway;

        public InvoiceLineGateway(Gateway gateway)
        {
            this.gateway = gateway;
        }

        /// <summary>
        /// Create new Invoice Lines.
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <param name="invoiceLines"></param>
        /// <returns></returns>
        public Invoice Create(string invoiceId, params InvoiceLine[] invoiceLines)
        {
            string endPoint = "/v1/invoices/create-lines";

            string body = JsonConvert.SerializeObject(new
            {
                invoiceId   = invoiceId,
                lines       = invoiceLines
            }, new JsonSerializerSettings()
            {
                StringEscapeHandling = StringEscapeHandling.EscapeNonAscii,
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
            });

            string response = this.gateway.client.Post(endPoint, body);

            InvoiceGateway invoiceGateway = new InvoiceGateway();

            return invoiceGateway.InvoiceFactory(response);
        }

        /// <summary>
        /// Update Lines in an invoice. The updated InvoiceLine object(s) should have <c>invoiceLIneId</c> field set to identify which invoiceLines need to be updated.
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <param name="invoiceLines"></param>
        /// <returns></returns>
        /// <exception cref="MissingFieldException"></exception>
        public Invoice Update(string invoiceId, params InvoiceLine[] invoiceLines)
        {
            if (invoiceId == null)
            {
                throw new MissingFieldException("invoice id can not be null.");
            }

            string endPoint = "/v1/invoices/update-lines";

            string body = JsonConvert.SerializeObject(new
            {
                invoiceId = invoiceId,
                lines = invoiceLines
            }, new JsonSerializerSettings()
            {
                StringEscapeHandling = StringEscapeHandling.EscapeNonAscii,
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
            });

            string response = gateway.client.Post(endPoint, body);

            InvoiceGateway invoiceGateway = new InvoiceGateway();

            return invoiceGateway.InvoiceFactory(response);
        }

        /// <summary>
        /// Delete multiple Invoice Lines by id.
        /// </summary>
        /// <param name="invoiceId">Id of the invoice that needs to be deleted</param>
        /// <param name="invoiceLineIds">provide one or many IDs of Invoice Lines.</param>
        /// <returns></returns>
        public Invoice Delete(string invoiceId, params string[] invoiceLineIds)
        {
            string body = JsonConvert.SerializeObject(new
            {
                invoiceId = invoiceId,
                invoiceLineIds = invoiceLineIds
            }, new JsonSerializerSettings()
            {
                StringEscapeHandling = StringEscapeHandling.EscapeNonAscii,
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
            });

            string endPoint = "/v1/invoices/delete-lines";
            string response = this.gateway.client.Post(endPoint, body);

            InvoiceGateway invoiceGateway = new InvoiceGateway();

            return invoiceGateway.InvoiceFactory(response);
        }
    }
}
