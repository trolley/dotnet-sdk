using PaymentRails.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentRails.Types
{
    /// <summary>
    /// This class is a representation of a Payment Rails Recipient, it can be used to create or update recipients
    /// over the API
    /// </summary>
    public class RecipientAccount : IPaymentRailsMappable
    {
        private string id;
        private string primary;
        private string currency;
        private string recipientAccountId;
        private string routeType;
        private string recipientFees;
        private string emailAddress;
        private string country;
        private string type;
        private string iban;
        private string accountNum;
        private string accountHolderName;
        private string swiftBic;
        private string branchId;
        private string bankName;
        private string bankId;
        private string bankAddress;
        private string bankCity;
        private string bankRegionCode;
        private string bankPostalCode;

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Primary
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

        public string RecipientAccountId
        {
            get
            {
                return recipientAccountId;
            }

            set
            {
                recipientAccountId = value;
            }
        }

        public string RouteType
        {
            get
            {
                return routeType;
            }

            set
            {
                routeType = value;
            }
        }

        public string RecipientFees
        {
            get
            {
                return recipientFees;
            }

            set
            {
                recipientFees = value;
            }
        }

        public string EmailAddress
        {
            get
            {
                return emailAddress;
            }

            set
            {
                emailAddress = value;
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

        public string AccountHolderName
        {
            get
            {
                return accountHolderName;
            }

            set
            {
                accountHolderName = value;
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

        public string BranchId
        {
            get
            {
                return branchId;
            }

            set
            {
                branchId = value;
            }
        }

        public string BankName
        {
            get
            {
                return bankName;
            }

            set
            {
                bankName = value;
            }
        }

        public string BankId
        {
            get
            {
                return bankId;
            }

            set
            {
                bankId = value;
            }
        }

        public string BankAddress
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

        public string BankCity
        {
            get
            {
                return bankCity;
            }

            set
            {
                bankCity = value;
            }
        }

        public string BankRegionCode
        {
            get
            {
                return bankRegionCode;
            }

            set
            {
                bankRegionCode = value;
            }
        }

        public string BankPostalCode
        {
            get
            {
                return bankPostalCode;
            }

            set
            {
                bankPostalCode = value;
            }
        }

        public RecipientAccount(string id, string primary, string currency, string recipientAccountId, string routeType, string recipientFees, string emailAddress, string country, string type, string iban, string accountNum, string accountHolderName, String swiftBic, string branchId, string bankName, string bankId, string bankAddress, string bankCity, string bankRegionCode, string bankPostalCode)
        {
            this.Id = id;
            this.Primary = primary;
            this.Currency = currency;
            this.RecipientAccountId = recipientAccountId;
            this.RouteType = routeType;
            this.RecipientFees = recipientFees;
            this.EmailAddress = emailAddress;
            this.Country = country;
            this.Type = type;
            this.Iban = iban;
            this.AccountNum = accountNum;
            this.AccountHolderName = accountHolderName;
            this.SwiftBic = swiftBic;
            this.BranchId = branchId;
            this.BankName = bankName;
            this.BankId = bankId;
            this.BankAddress = bankAddress;
            this.BankCity = bankCity;
            this.BankRegionCode = bankRegionCode;
            this.BankPostalCode = bankPostalCode;
        }

        public RecipientAccount()
        {

        }
        public static bool operator ==(RecipientAccount a, RecipientAccount b)
        {
            if (System.Object.ReferenceEquals(a, b))
                return true;
            if ((object)a == null || (object)b == null)
                return false;
            return a.Equals(b);
        }

        public static bool operator !=(RecipientAccount a, RecipientAccount b)
        {
            return !(a == b);
        }
        /// <summary>
        /// Checks whether all fields are equivalent to the object being compared
        /// </summary>
        /// <param name="obj">The object to compare to</param>
        /// <returns>whether the objects are equal</returns>
        public override bool Equals(object obj)
        {
            if (obj != null && obj.GetType() == this.GetType())
            {
                RecipientAccount other = (RecipientAccount)obj;
                if (other.Id == this.Id && other.Primary == this.Primary && other.Currency == this.Currency && other.RecipientAccountId == this.RecipientAccountId
                    && other.RouteType == this.RouteType && other.RecipientFees == this.RecipientFees && other.EmailAddress == this.EmailAddress && other.Country == this.Country
                    && other.Type == this.Type && other.Iban == this.Iban && other.AccountNum == this.AccountNum && other.AccountHolderName == this.AccountHolderName
                    && other.SwiftBic == this.SwiftBic && other.BranchId == this.BranchId && other.BankName == this.BankName && other.BankId == this.BankId && other.BankAddress == this.BankAddress
                    && other.BankCity == this.BankCity && other.BankRegionCode == this.BankRegionCode && other.BankPostalCode == this.BankPostalCode)
                    return true;
            }
            return false;
        }




        /// <summary>
        /// Function that checks if a IPaymentRailsMappable object has all required fields to be sent
        /// this function will throw an exception if any of the fields are not properly set.
        /// 
        /// In order to have a valid bank-transfer recipientAccount the type, country, currency, branchId, bankId accountNumber must be set
        /// In order to have a valid paypal recipientAccount the type and email must be set
        /// </summary>
        /// <returns>weather the object is ready to be sent to the Payment Rails API</returns>
        public bool IsMappable()
        {
            if (Type == null)
            {
                throw new InvalidFieldException("RecipientAccount must have a type");
            }
            if (Type == "bank-transfer")
                if (Country == null)
                {
                    throw new InvalidFieldException("RecipientAccount must have a country if the type is bank-transfer");
                }
            if (Type == "bank-transfer")
                if (Currency == null)
                {
                    throw new InvalidFieldException("RecipientAccount must have a currency if the type is bank-transfer");
                }
            if (Type == "bank-transfer")
                if (BranchId == null)
                {
                    throw new InvalidFieldException("RecipientAccount must have a branchId if the type is bank-transfer");
                }
            if (Type == "bank-transfer")
                if (BankId == null)
                {
                    throw new InvalidFieldException("RecipientAccount must have a bankId if the type is bank-transfer");
                }
            if (Type == "bank-transfer")
                if (AccountNum == null)
                {
                    throw new InvalidFieldException("RecipientAccount must have an AccountNumber if the type is bank-transfer");
                }

            if (Type == "paypal")
                if (EmailAddress == null)
                {
                    throw new InvalidFieldException("RecipientAccount must have an email if the type is paypal");
                }

            return true;
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
            if (Type == "bank-transfer")
            {
                builder.AppendFormat("\"referenceId\": \"{0}\",\n", this.country);
                builder.AppendFormat("\"email\": \"{0}\",\n", this.currency);
                builder.AppendFormat("\"name\": \"{0}\",\n", this.branchId);
                builder.AppendFormat("\"firstName\": \"{0}\",\n", this.bankId);
                builder.AppendFormat("\"lastName\": \"{0}\",\n", this.AccountNum);
            }
            else if(Type == "paypal")
            {
                builder.AppendFormat("\"referenceId\": \"{0}\",\n", this.type);
                builder.AppendFormat("\"email\": \"{0}\",\n", this.emailAddress);
        
            }
                builder.Append("}");
                return builder.ToString();
            

        }
    }
}
