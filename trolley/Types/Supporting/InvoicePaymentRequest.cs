using System;
using Newtonsoft.Json;
using Trolley.JsonHelpers;

namespace Trolley.Types.Supporting
{
	/* 
    Represents an InvoicePayment Request. Accommodates additional payment and batch related fields.
     */
    public class InvoicePaymentRequest: ITrolleyMappable
	{
        /* If provided, this is the batch a new payment will be added to. Otherwise a new batch will be created. Optional. */
        public string batchId;
        /* Marks whether the created payment should cover the fees, default is false. Optional. */
        public bool coverFees;
        /* Any public memo that appears on the created payment. Optional. */
        public string memo;
        /* External ID associated with the external payment. Optional. */
        public string externalId;
        /* Tags (private) associated with the payment. Optional.*/
        public string[] tags;
        /* Contains the details of invoice and invoiceLines that need to be paid with this payment. Required. */
        public InvoicePaymentPart[] ids;

        public InvoicePaymentRequest(InvoicePaymentPart[] ids, string batchId = null, bool coverFees = false, string memo = null, string externalId = null, string[] tags = null)
		{
            this.ids = ids;
            this.batchId = batchId;
            this.coverFees = coverFees;
            this.memo = memo;
            this.externalId = externalId;
            this.tags = tags;
		}

        public InvoicePaymentRequest()
		{
		}

        public bool IsMappable()
        {
            if(ids == null || ids.Length == 0)
            {
                throw new MissingFieldException("No value for ids is provided, which is a required field");
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

