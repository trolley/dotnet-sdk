using System.Collections.Generic;

namespace Trolley.Types.Supporting
{
	public class Recipients
	{
        public List<Recipient> recipients = null;
        public Meta meta = null;

		public Recipients()
		{
		}

		public Recipients(List<Recipient> recipients, Meta meta)
		{
			this.recipients = recipients;
			this.meta = meta;
		}
	}
}

