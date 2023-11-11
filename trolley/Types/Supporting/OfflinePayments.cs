using System;
using System.Collections.Generic;

namespace Trolley.Types.Supporting
{
	public class OfflinePayments
	{
        public List<OfflinePayment> offlinePayments = null;
        public Meta meta = null;

		public OfflinePayments()
		{
		}

		public OfflinePayments(List<OfflinePayment> offlinePayments, Meta meta)
		{
			this.offlinePayments = offlinePayments;
			this.meta = meta;
		}
	}
}

