using System;
using System.Collections.Generic;

namespace Trolley.Types.Supporting
{
	public class Logs
	{
        public List<Log> logs = null;
        public Meta meta = null;

		public Logs()
		{
		}

		public Logs(List<Log> logs, Meta meta)
		{
			this.logs = logs;
			this.meta = meta;
		}
	}
}

