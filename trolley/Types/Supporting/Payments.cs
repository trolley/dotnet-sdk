using System;
using System.Collections.Generic;

namespace Trolley.Types.Supporting
{
	public class Payments
	{
        public List<Payment> payments = null;
        public Meta meta = null;

		public Payments()
		{
		}

		public Payments(List<Payment> payments, Meta meta)
		{
			this.payments = payments;
			this.meta = meta;
		}
	}
}

