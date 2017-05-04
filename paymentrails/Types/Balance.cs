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


        public Balance(bool primary, double amount, string currency, string type, string accountNumber)
        {
            this.primary = primary;
            this.amount = amount;
            this.currency = currency;
            this.type = type;
            this.accountNumber = accountNumber;
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
