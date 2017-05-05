using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentrails.Types
{
    public class Compliance
    {
        private string status;
        private string active;

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public string Active
        {
            get
            {
                return active;
            }

            set
            {
                active = value;
            }
        }

        public Compliance(string status, string active)
        {
            this.status = status;
            this.active = active;
        }

        public Compliance()
        {

        }

        //public string ToJson()
        //{
        //    StringBuilder builder = new StringBuilder();
        //    builder.Append("{\n");
        //    builder.AppendFormat("\"active\": \"{0}\",\n", this.active);
        //    builder.AppendFormat("\"status\": \"{0}\",\n", this.status);
        //    builder.Append("}");
        //    return builder.ToString();
        //}
    }
}
