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
    }
}
