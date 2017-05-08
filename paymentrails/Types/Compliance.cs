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

        #region Properties
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
        #endregion

        public Compliance(string status, string active)
        {
            this.status = status;
            this.active = active;
        }

        public Compliance()
        {

        }

        public static bool operator ==(Compliance a, Compliance b)
        {
            if (System.Object.ReferenceEquals(a, b))
                return true;
            if ((object)a == null || (object)b == null)
                return false;
            return a.Equals(b);
        }

        public static bool operator !=(Compliance a, Compliance b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj.GetType() == this.GetType())
            {
                Compliance other = (Compliance)obj;
                if (other.status == this.status && other.active == this.active)
                    return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
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
