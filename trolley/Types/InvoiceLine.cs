using System.Collections.Generic;
using System;
using Trolley.Types.Supporting;
using Newtonsoft.Json;

namespace Trolley.Types
{
    public class InvoiceLine : ITrolleyMappable
    {
        public string id;
        public string invoiceLineId;
        public string status;
        public string description;
        public Amount unitAmount;
        public string quantity;
        public Amount discountAmount;
        public Amount taxAmount;
        public Amount totalAmount;
        public Amount dueAmount;
        public Amount paidAmount;
        public string externalId;

        public InvoiceLine() { }

        public InvoiceLine(string id, string invoiceLineId, string status, string description,
            Amount unitAmount, string quantity, Amount discountAmount, Amount taxAmount,
            Amount totalAmount, Amount dueAmount, Amount paidAmount, string externalId)
        {
            this.id = id;
            this.invoiceLineId = invoiceLineId;
            this.status = status;
            this.description = description;
            this.unitAmount = unitAmount;
            this.quantity = quantity;
            this.discountAmount = discountAmount;
            this.taxAmount = taxAmount;
            this.totalAmount = totalAmount;
            this.dueAmount = dueAmount;
            this.paidAmount = paidAmount;
            this.externalId = externalId;
        }

        public override bool Equals(object obj)
        {
            return obj is InvoiceLine line &&
                   id == line.id &&
                   invoiceLineId == line.invoiceLineId &&
                   status == line.status &&
                   description == line.description &&
                   EqualityComparer<Amount>.Default.Equals(unitAmount, line.unitAmount) &&
                   quantity == line.quantity &&
                   EqualityComparer<Amount>.Default.Equals(discountAmount, line.discountAmount) &&
                   EqualityComparer<Amount>.Default.Equals(taxAmount, line.taxAmount) &&
                   EqualityComparer<Amount>.Default.Equals(totalAmount, line.totalAmount) &&
                   EqualityComparer<Amount>.Default.Equals(dueAmount, line.dueAmount) &&
                   EqualityComparer<Amount>.Default.Equals(paidAmount, line.paidAmount) &&
                   externalId == line.externalId;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public bool IsMappable()
        {
            return true;
        }

        public override string ToString()
        {
            return ToJson();
        }


        public string ToJson()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                StringEscapeHandling = StringEscapeHandling.EscapeNonAscii,
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
            };
            return JsonConvert.SerializeObject(this, settings);
        }
    }
}
