using System.Collections.Generic;

namespace Trolley.Types.Supporting
{
	public class Batches
	{
        public List<Batch> batches = null;
        public Meta meta = null;

		public Batches()
		{
		}

		public Batches(List<Batch> batches, Meta meta)
		{
			this.batches = batches;
			this.meta = meta;
		}
	}
}

