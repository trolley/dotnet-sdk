using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentrails.Types
{
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

        public Payout(double autoswitchLimit, bool autoswitchActive, double holdupLimit, bool holdupActive, string primaryMethod, string primaryCurrency, BankAccount bank, PaypalAccount paypal)
        {
            this.autoswitchLimit = autoswitchLimit;
            this.autoswitchActive = autoswitchActive;
            this.holdupLimit = holdupLimit;
            this.holdupActive = holdupActive;
            this.primaryMethod = primaryMethod;
            this.primaryCurrency = primaryCurrency;
            this.bank = bank;
            this.paypal = paypal;
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
    }
}
