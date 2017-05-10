using paymentrails.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentrails.Types
{
    /// <summary>
    /// This class represents a Payment Rails payout method for a recipient, this object can be used for creating
    /// and updating recipient payouts
    /// </summary>
    public class Payout : IPaymentRailsMappable
    {
        private double autoswitchLimit;
        private bool autoswitchActive;
        private double holdupLimit;
        private bool holdupActive;
        private string primaryMethod;
        private string primaryCurrency;
        private BankAccount bank;
        private PaypalAccount paypal;

        #region Properties
        /// <summary>
        /// The amount of money required to default to another currencuy
        /// </summary>
        public double AutoswitchLimit
        {
            get
            {
                return autoswitchLimit;
            }

            set
            {
                autoswitchLimit = value;
            }
        }
        /// <summary>
        /// Whether autoswitching is active
        /// </summary>
        public bool AutoswitchActive
        {
            get
            {
                return autoswitchActive;
            }

            set
            {
                autoswitchActive = value;
            }
        }
        /// <summary>
        /// The amount of money required to hold up a payment
        /// </summary>
        public double HoldupLimit
        {
            get
            {
                return holdupLimit;
            }

            set
            {
                holdupLimit = value;
            }
        }
        /// <summary>
        /// whether payment holdups are active
        /// </summary>
        public bool HoldupActive
        {
            get
            {
                return holdupActive;
            }

            set
            {
                holdupActive = value;
            }
        }
        /// <summary>
        /// The primary payout method name
        /// </summary>
        public string PrimaryMethod
        {
            get
            {
                return primaryMethod;
            }

            set
            {
                
                primaryMethod = value;
            }
        }
        /// <summary>
        /// The primary currency code
        /// </summary>
        public string PrimaryCurrency
        {
            get
            {
                return primaryCurrency;
            }

            set
            {
                primaryCurrency = value;
            }
        }
        /// <summary>
        /// A bank account
        /// </summary>
        public BankAccount Bank
        {
            get
            {
                return bank;
            }

            set
            {
   
                bank = value;
            }
        }
        /// <summary>
        /// a paypal account
        /// </summary>
        public PaypalAccount Paypal
        {
            get
            {
                return paypal;
            }

            set
            {
                paypal = value;
            }
        }
        #endregion

        public Payout()
        {
            this.autoswitchLimit = 0;
            this.autoswitchActive = false;
            this.holdupLimit = 0;
            this.holdupActive = false;
            this.primaryMethod = null;
            this.primaryCurrency = null;
            this.bank = null;
            this.paypal = null;
        }
        /// <summary>
        /// Constructor used to instantiate a recipient payout method
        /// </summary>
        /// <param name="autoswitchLimit"></param>
        /// <param name="autoswitchActive"></param>
        /// <param name="holdupLimit"></param>
        /// <param name="holdupActive"></param>
        /// <param name="primaryMethod"></param>
        /// <param name="primaryCurrency"></param>
        /// <param name="bank"></param>
        /// <param name="paypal"></param>
        public Payout(double autoswitchLimit, bool autoswitchActive, double holdupLimit, bool holdupActive, string primaryMethod, string primaryCurrency, BankAccount bank, PaypalAccount paypal)
        {
            this.AutoswitchLimit = autoswitchLimit;
            this.AutoswitchActive = autoswitchActive;
            this.HoldupLimit = holdupLimit;
            this.HoldupActive = holdupActive;
            this.PrimaryMethod = primaryMethod;
            this.PrimaryCurrency = primaryCurrency;
            this.Bank = bank;
            this.Paypal = paypal;
        }

        public static bool operator ==(Payout a, Payout b)
        {
            if (System.Object.ReferenceEquals(a, b))
                return true;
            if ((object)a == null || (object)b == null)
                return false;
            return a.Equals(b);
        }

        public static bool operator !=(Payout a, Payout b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Checks whether all the fields the current payout are equivalent to the object it is being compared to
        /// </summary>
        /// <param name="obj">The object to compare to</param>
        /// <returns>Whether the two objects are equivalent</returns>
        public override bool Equals(object obj)
        {
            if (obj != null && obj.GetType() == this.GetType())
            {
                Payout other = (Payout)obj;
                if (other.autoswitchLimit == this.autoswitchLimit && other.autoswitchActive == this.autoswitchActive && other.holdupActive == this.holdupActive
                    && other.holdupLimit == this.holdupLimit && other.primaryMethod == this.primaryMethod && other.primaryCurrency == this.primaryCurrency
                    && other.Bank == this.Bank && other.Paypal == this.Paypal)
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

        // @TODO: rewrite this to be more readable
        /// <summary>
        /// Returns a JSON string representation of the object formatted to be compliant with
        /// the Payment Rails API post and patch endpoints
        /// </summary>
        /// <returns>JSON string representation of the object</returns>
        public string ToJson()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("{\n");
            builder.AppendFormat("\"autoswitch\": {{\n \"limit\": {0},\n \"active\": \"{1}\"\n}},\n",
                this.AutoswitchLimit, this.AutoswitchActive);
            builder.AppendFormat("\"holdup\": {{\n \"limit\": {0},\n \"active\": \"{1}\"\n}},\n",
                this.HoldupLimit, this.HoldupActive);
            //if (this.PrimaryCurrency != null)
            //{
            //    builder.AppendFormat("\"currency\": {{\n\t \"code\": \"{0}\"\n}},\n", this.PrimaryCurrency);
            //}
            if (this.PrimaryMethod != null || this.PrimaryCurrency != null)
            {
                //,\n\"currency\": {{\n\t \"code\": \"{1}\"\n}}\n ||add this back into the string when updating currency through recipient works
                builder.AppendFormat("\"primary\": {{\n\"method\": \"{0}\"}},\n", this.PrimaryMethod, this.primaryCurrency);
            }

            builder.Append("\"accounts\": {\n");
            string bankString = "null";
            string paypalString = "null";
            if (this.Bank != null)
            {
                bankString = this.bank.ToJson();
            }
            builder.AppendFormat("\"bank\": {0},\n", bankString);

            if (this.Paypal != null)
            {
                paypalString = this.paypal.ToJson();
            }
            builder.AppendFormat("\"paypal\": {0}\n", paypalString);
            builder.Append("}\n");

            builder.Append("}");

            return builder.ToString();
        }
        /// <summary>
        /// Function that checks if a IPaymentRailsMappable object has all required fields to be sent
        /// this function will throw an exception if any of the fields are not properly set.
        /// In order to have a valid payout a primary method is required
        /// </summary>
        /// <returns>weather the object is ready to be sent to the Payment Rails API</returns>
        public bool IsMappable()
        {
            if (PrimaryMethod == null)
            {
                throw new InvalidFieldException("Payout method must have a primary method");
            }
            return true;
        }
    }
}
