using System;

namespace PaymentRails.Types
{
    /// <summary>
    /// This class is a representation of a merchant balance from the Payment Rails API
    /// </summary>
    public class Balance
    {
        private Boolean primary;
        private Double amount;
        private string currency;
        private string type;
        private string accountNumber;

        #region Properties
        /// <summary>
        /// Whether or not this balance is your primary balance
        /// </summary>
        public bool Primary
        {
            get
            {
                return primary;
            }

            set
            {
                primary = value;
            }
        }

        /// <summary>
        /// The amount of money available for this balance
        /// </summary>
        public double Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }

        /// <summary>
        /// The currency type of this balance
        /// </summary>
        public string Currency
        {
            get
            {
                return currency;
            }

            set
            {
                currency = value;
            }
        }

        /// <summary>
        /// The type of balance this is such as a PaymentRails or a Paypal balance
        /// </summary>
        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        /// <summary>
        /// The account number associated with this balance
        /// </summary>
        public string AccountNumber
        {
            get
            {
                return accountNumber;
            }

            set
            {
                accountNumber = value;
            }
        }
        #endregion

        public Balance() { }

        /// <summary>
        /// Default constructor for a merchant balance (You should never have to instantiate your own balance object
        /// as balances are read only)
        /// </summary>
        /// <param name="primary"></param>
        /// <param name="amount"></param>
        /// <param name="currency"></param>
        /// <param name="type"></param>
        /// <param name="accountNumber"></param>
        public Balance(bool primary, double amount, string currency, string type, string accountNumber)
        {
            this.primary = primary;
            this.amount = amount;
            this.currency = currency;
            this.type = type;
            this.accountNumber = accountNumber;
        }
        
        public static bool operator ==(Balance a, Balance b)
        {
            if (System.Object.ReferenceEquals(a, b))
                return true;
            if ((object)a == null || (object)b == null)
                return false;
            return a.Equals(b);
        }

        public static bool operator !=(Balance a, Balance b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Checks weather all the fields in a balance are equivalent to the object being compared
        /// </summary>
        /// <param name="obj">THe object being compared</param>
        /// <returns>Whether the objects are equal</returns>
        public override bool Equals(object obj)
        {
            if(obj == null || obj.GetType() != this.GetType())
                return false;

            Balance other = (Balance)obj;
            if(this.primary == other.primary && this.amount == other.amount 
                && this.currency == other.currency && this.type == other.type && this.accountNumber == other.accountNumber)
                return true;
            return false;
            
        }
    }
}
