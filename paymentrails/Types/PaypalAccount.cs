using System.Text;

namespace PaymentRails.Types
{
    public class PaypalAccount : IPaymentRailsMappable
    {
        private string email;

        #region properties
        /// <summary>
        /// The email of the paypal account
        /// </summary>
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
        /// <summary>
        /// Constructor to instantiate a paypal account
        /// </summary>
        /// <param name="email"></param>
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
        /// <summary>
        /// Checks whether the current paypal account has the same email as the
        /// object it is being compared to
        /// </summary>
        /// <param name="obj">the object to compare to</param>
        /// <returns>whether the two paypal accounts are equivalent</returns>
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
        /// <summary>
        /// Returns a JSON string representation of the object formatted to be compliant with
        /// the Payment Rails API post and patch endpoints
        /// </summary>
        /// <returns>JSON string representation of the object</returns>
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
        /// <summary>
        /// Function that checks if a IPaymentRailsMappable object has all required fields to be sent
        /// this function will throw an exception if any of the fields are not properly set.
        /// </summary>
        /// <returns>weather the object is ready to be sent to the Payment Rails API</returns>
        public bool IsMappable()
        {
            return true;
        }
    }
}
