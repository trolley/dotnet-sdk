using System;

namespace paymentrails.Types
{
    public class Balance
    {
        private Boolean primary;
        private Double amount;
        private String currency;
        private String type;
        private String accountNumber;

        #region Properties
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
