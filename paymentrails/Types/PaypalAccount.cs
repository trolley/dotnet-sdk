using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentrails.Types
{
    public class PaypalAccount : IPaymentRailsMappable
    {
        private string email;

        #region properties
        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }
        // used to map address field which shold probably be called email
        public string Address
        {
            set
            {
                this.email = value;
            }
        }
        #endregion

        public PaypalAccount(string email)
        {
            this.email = email;
        }

        public PaypalAccount()
        {
            this.email = null;
        }

        public static bool operator ==(PaypalAccount a, PaypalAccount b)
        {
            if (System.Object.ReferenceEquals(a, b))
                return true;
            if ((object)a == null || (object)b == null)
                return false;
            return a.Equals(b);
        }

        public static bool operator !=(PaypalAccount a, PaypalAccount b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj.GetType() == this.GetType())
            {
                PaypalAccount other = (PaypalAccount)obj;
                if (other.email == this.email)
                    return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return this.ToJson();
        }

        public string ToJson()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("{\n");
            if (this.Email != null)
            {
                builder.AppendFormat("\"address\": \"{0}\"\n", this.Email);
            }
            builder.Append("}");
            return builder.ToString();
        }

        public bool IsMappable()
        {
            throw new NotImplementedException();
        }
    }
}
