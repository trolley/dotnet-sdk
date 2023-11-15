using System.Collections.Generic;

namespace Trolley.Types.Supporting
{
	public class InvoicePayments
	{
        public List<InvoicePayment> invoicePayments = null;
        public Meta meta = null;

		public InvoicePayments()
		{
		}

		public InvoicePayments(List<InvoicePayment> invoicePayments, Meta meta)
		{
			this.invoicePayments = invoicePayments;
			this.meta = meta;
		}
	}
}

