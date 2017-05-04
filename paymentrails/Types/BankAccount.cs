using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentrails.Types
{
    public class BankAccount : IPaymentRailsMappable
    {
        private string institution;
        private string branchNum;
        private string accountNum;
        private string currency;
        private string country;
        private string name;

        #region Properties
        public string Institution
        {
            get
            {
                return institution;
            }

            set
            {
                institution = value;
            }
        }

        public string BranchNum
        {
            get
            {
                return branchNum;
            }

            set
            {
                branchNum = value;
            }
        }

        public string AccountNum
        {
            get
            {
                return accountNum;
            }

            set
            {
                accountNum = value;
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

        public string Country
        {
            get
            {
                return country;
            }

            set
            {
                country = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
        #endregion

        public BankAccount(string currencyCode, string institution, string branchNum, string accountNum, string currency, string country, string name)
        {
            this.institution = institution;
            this.branchNum = branchNum;
            this.accountNum = accountNum;
            this.currency = currency;
            this.country = country;
            this.name = name;
        }

        public BankAccount()
        {
            this.institution = null;
            this.branchNum = null;
            this.accountNum = null;
            this.currency = null;
            this.country = null;
            this.name = null;
        }

        public override string ToString()
        {
            return this.ToJson();
        }

        public string ToJson()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("{\n");
            if (this.AccountNum != null)
            {
                builder.AppendFormat("\"accountNum\": \"{0}\",\n", this.AccountNum);
            }
            if (this.BranchNum != null)
            {
                builder.AppendFormat("\"branchNum\": \"{0}\",\n", this.BranchNum);
            }
            if (this.Country != null)
            {
                builder.AppendFormat("\"country\": \"{0}\",\n", this.Country);
            }
            if (this.Currency != null)
            {
                builder.AppendFormat("\"currency\": \"{0}\",\n", this.Currency);
            }
            if (this.Institution != null)
            {
                builder.AppendFormat("\"institution\": \"{0}\",\n", this.Institution);
            }
            if (this.Name != null)
            {
                builder.AppendFormat("\"name\": \"{0}\"\n", this.Name);
            }
            builder.Append("}");
            return builder.ToString();
        }
    }
}
