using System;
using Newtonsoft.Json;
using Trolley.JsonHelpers;

namespace Trolley.Types.Supporting
{
	public class InvoicePaymentPart: ITrolleyMappable
	{
        public string invoiceId;
        public string invoiceLineId;
        public string paymentId;
        public Amount amount;

        public InvoicePaymentPart()
		{
		}

        public InvoicePaymentPart(string invoiceId, string invoiceLineId, string paymentId,
            Amount amount)
        {
            this.invoiceId = invoiceId;
            this.invoiceLineId = invoiceLineId;
            this.paymentId = paymentId;
            this.amount = amount;
        }

        public bool IsMappable()
        {
            if(invoiceId == null || invoiceLineId == null || paymentId == null)
            {
                throw new MissingFieldException("Null fields in all IDs. At least one of invoiceId, invoiceLineId, or paymentId must be set.");
            }
            if (invoiceId.Length == 0 || invoiceLineId.Length == 0 || paymentId.Length == 0)
            {
                throw new MissingFieldException("All IDs are empty. At least one of invoiceId, invoiceLineId, or paymentId must be set.");
            }
            if (amount == null)
            {
                throw new MissingFieldException("Amount needs to be set.");
            }
            return true;
        }

        public override string ToString()
        {
            return ToJson();
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, SerializerHelper.GetSerializerSettings());
        }
    }
}

