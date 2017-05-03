using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentrails.Types
{
    public struct BankAccount
    {
        private string currencyCode;
        private string institution;
        private string branchNum;
        private string accountNum;
        private string currency;
        private string country;

        public string CurrencyCode
        {
            get
            {
                return currencyCode;
            }

            set
            {
                currencyCode = value;
            }
        }

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

        public BankAccount(string currencyCode, string institution, string branchNum, string accountNum, string currency, string country)
        {
            this.currencyCode = currencyCode;
            this.institution = institution;
            this.branchNum = branchNum;
            this.accountNum = accountNum;
            this.currency = currency;
            this.country = country;
        }
    }
}
