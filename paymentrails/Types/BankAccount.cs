using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentRails.Types
{
    /// <summary>
    /// This class is a representation of a Payment Rails bank account, the data in this class can
    /// be sent over the API to create new recipient bank accounts or update existing ones if the 
    /// targeted recipient already has a bank account.
    /// </summary>
    public class BankAccount : IPaymentRailsMappable
    {
        private string institution;
        private string branchNum;
        private string currency;
        private string country;
        private string name;
        private string accountNum;
        private string routing;
        private string iban;
        private string swiftBic;
        private string governmentID;

        private Address bankAddress;

        #region Properties
        /// <summary>
        /// The institution number of the bank
        /// </summary>
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

        /// <summary>
        /// The branch number of the bank
        /// </summary>
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

        /// <summary>
        /// The bank's branch number
        /// </summary>
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

        /// <summary>
        /// The bank account's currency
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
        /// The bank's country
        /// </summary>
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

        /// <summary>
        /// The bank's name
        /// </summary>
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

       public string Routing
        {
            get
            {
                return routing;
            }

            set
            {
                routing = value;
            }
        }

        public string Iban
        {
            get
            {
                return iban;
            }

            set
            {
                iban = value;
            }
        }

        public string SwiftBic
        {
            get
            {
                return swiftBic;
            }

            set
            {
                swiftBic = value;
            }
        }

        public string GovernmentID
        {
            get
            {
                return governmentID;
            }

            set
            {
                governmentID = value;
            }
        }

        public Address BankAddress
        {
            get
            {
                return bankAddress;
            }

            set
            {
                bankAddress = value;
            }
        }
        #endregion

        /// <summary>
        /// Constructor used to instantiate a BankAccount
        /// </summary>
        /// <param name="country"></param>
        /// <param name="currencyCode"></param>
        /// <param name="institution"></param>
        /// <param name="branchNum"></param>
        /// <param name="accountNum"></param>
        /// <param name="currency"></param>
        /// <param name="name"></param>
        public BankAccount(string country, string institution, string branchNum, string accountNum, string currency, string name, string routing = null, string iban = null, string swiftBic = null, string governmentID = null, Address bankAddress = null)
        {
            this.institution = institution;
            this.branchNum = branchNum;
            this.AccountNum = accountNum;
            this.currency = currency;
            this.country = country;
            this.name = name;
            this.routing = routing;
            this.iban = iban;
            this.swiftBic = swiftBic;
            this.governmentID = governmentID;
            this.bankAddress = bankAddress;
        }

        public BankAccount()
        {
            this.institution = null;
            this.branchNum = null;
            this.AccountNum = null;
            this.currency = null;
            this.country = null;
            this.name = null;
        }

        public static bool operator ==(BankAccount a, BankAccount b)
        {
            if (System.Object.ReferenceEquals(a, b))
                return true;
            if ((object)a == null || (object)b == null)
                return false;
            return a.Equals(b);
        }

        public static bool operator !=(BankAccount a, BankAccount b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Checks if the current BankAccount's field are the same as the object
        /// </summary>
        /// <param name="obj">the object to compare to</param>
        /// <returns>Whether both objects are equal</returns>
        public override bool Equals(object obj)
        {
            if(obj != null && obj.GetType() == this.GetType())
            {
                BankAccount other = (BankAccount)obj;
                if(other.institution == this.institution && other.branchNum == this.branchNum && other.AccountNum == this.AccountNum 
                    && other.currency == this.currency && other.country == this.country && other.name == this.name && other.Iban == this.Iban 
                    && other.SwiftBic == this.swiftBic && other.Routing == this.Routing && other.BankAddress == this.BankAddress)
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
            if (this.Routing != null)
            {
                builder.AppendFormat("\"routing\": \"{0}\"\n", this.Routing);
            }
            if (this.Iban != null)
            {
                builder.AppendFormat("\"iban\": \"{0}\"\n", this.Iban);
            }
            if (this.SwiftBic != null)
            {
                builder.AppendFormat("\"swiftBic\": \"{0}\"\n", this.SwiftBic);
            }
            if (this.GovernmentID != null)
            {
                builder.AppendFormat("\"governmentId\": \"{0}\"\n", this.GovernmentID);
            }
            if (this.BankAddress != null)
            {
                builder.AppendFormat("\"bankAddress\": \"{0}\"\n", this.BankAddress.Street1);
                builder.AppendFormat("\"bankCity\": \"{0}\"\n", this.BankAddress.City);
                builder.AppendFormat("\"bankAddress\": \"{0}\"\n", this.BankAddress.Region);
                builder.AppendFormat("\"bankAddress\": \"{0}\"\n", this.BankAddress.PostalCode);
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
