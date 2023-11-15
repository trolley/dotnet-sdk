using System.Collections.Generic;

namespace Trolley.Types.Supporting
{
	public class Invoices
    {
        public List<Invoice> invoices = null;
        public Meta meta = null;

		public Invoices()
		{
		}

		public Invoices(List<Invoice> invoices, Meta meta)
		{
			this.invoices = invoices;
			this.meta = meta;
		}
	}
}

