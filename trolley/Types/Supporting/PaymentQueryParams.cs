using System;
using System.Text;
using System.Collections.Generic;

namespace Trolley.Types
{
    public class PaymentQueryParams
    {
        public int page; // 1
        public int pageSize; // 10

        public string term;
        public List<string> status;

        public PaymentQueryParams(string term = null, int page = 1, int pageSize = 10, List<string> status = null)
        {
            this.page = page;
            this.term = term;
            this.pageSize = pageSize;
            if (status == null)
            {
                this.status = new List<string>();
            } else
            {
                this.status = status;
            }
        }

        public string buildQueryString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("page={0}&pageSize={1}", this.page, this.pageSize);

            if (this.term != null)
            {
                builder.AppendFormat("&term={0}", this.term);
            }

            if (this.status != null && this.status.Count > 0)
            {
                string joinedStatus = string.Join(",", this.status.ToArray());
                builder.AppendFormat("&status={0}", joinedStatus);
            }

            return builder.ToString();
        }
    }
}
