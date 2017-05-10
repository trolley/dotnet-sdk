using paymentrails.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentrails.Types
{
    public class Payment : IPaymentRailsMappable
    {
        private double sourceAmount;
        private string targetCurrency;
        private double exchangeRate;
        private double fees;
        private double recipientFees;
        private double targetAmount;
        private double fxRate;
        private string memo;
        private string processedAt;
        private string createdAt;
        private string updatedAt;
        private double merchantFees;
        private string sourceCurrency;
        private string batchId;
        private string id;
        private string status;

        private Recipient recipient;
        private Compliance compliance;

        #region properties
        public double SourceAmount
        {
            get
            {
                return sourceAmount;
            }

            set
            {
                sourceAmount = value;
            }
        }

        public string TargetCurrency
        {
            get
            {
                return targetCurrency;
            }

            set
            {

                

                targetCurrency = value;
            }
        }

        public double ExchangeRate
        {
            get
            {
                return exchangeRate;
            }

            set
            {
                exchangeRate = value;
            }
        }

        public double Fees
        {
            get
            {
                return fees;
            }

            set
            {
                fees = value;
            }
        }

        public double RecipientFees
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

        public double TargetAmount
        {
            get
            {
                return targetAmount;
            }

            set
            {
                
                targetAmount = value;
            }
        }

        public double FxRate
        {
            get
            {
                return fxRate;
            }

            set
            {
                fxRate = value;
            }
        }

        public string Memo
        {
            get
            {
                return memo;
            }

            set
            {
                memo = value;
            }
        }

        public string ProcessedAt
        {
            get
            {
                return processedAt;
            }

            set
            {
                processedAt = value;
            }
        }

        public string CreatedAt
        {
            get
            {
                return createdAt;
            }

            set
            {
                createdAt = value;
            }
        }

        public string UpdatedAt
        {
            get
            {
                return updatedAt;
            }

            set
            {
                updatedAt = value;
            }
        }

        public double MerchantFees
        {
            get
            {
                return merchantFees;
            }

            set
            {
                merchantFees = value;
            }
        }

        public string SourceCurrency
        {
            get
            {
                return sourceCurrency;
            }

            set
            {
                sourceCurrency = value;
            }
        }

        public string BatchId
        {
            get
            {
                return batchId;
            }

            set
            {
                batchId = value;
            }
        }

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

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public Recipient Recipient
        {
            get
            {
                return recipient;
            }

            set
            {
                
                recipient = value;
            }
        }

        public Compliance Compliance
        {
            get
            {
                return compliance;
            }

            set
            {
                compliance = value;
            }
        }
        #endregion


        public Payment(Recipient recipient, double sourceAmount, string memo, double targetAmount, string targetCurrency, double exchangeRate,
            double fees, double recipientFees, double fxRate, string processedAt, string createdAt, string updatedAt,
            double merchantFees, string sourceCurrency, string batchId, string id, string status, Compliance compliance)
        {



            this.SourceAmount = sourceAmount;
            this.TargetAmount = targetAmount;
            this.TargetCurrency = targetCurrency;
            this.ExchangeRate = exchangeRate;
            this.Fees = fees;
            this.RecipientFees = recipientFees;
            this.FxRate = fxRate;
            this.Memo = memo;
            this.ProcessedAt = processedAt;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.MerchantFees = merchantFees;
            this.SourceCurrency = sourceCurrency;
            this.BatchId = batchId;
            this.Id = id;
            this.Status = status;
            this.Recipient = recipient;
            this.Compliance = compliance;
        }

        public static bool operator ==(Payment a, Payment b)
        {
            if (System.Object.ReferenceEquals(a, b))
                return true;
            if ((object)a == null || (object)b == null)
                return false;
            return a.Equals(b);
        }

        public static bool operator !=(Payment a, Payment b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj.GetType() == this.GetType())
            {
                Payment other = (Payment)obj;
                if (other.sourceAmount == this.sourceAmount && other.sourceCurrency == this.sourceCurrency && other.targetCurrency == this.targetCurrency
                    && other.exchangeRate == this.exchangeRate && other.fees == this.fees && other.recipientFees == this.recipientFees
                    && other.targetAmount == this.targetAmount && other.fxRate == this.fxRate && other.memo == this.memo && other.processedAt == this.processedAt
                    && other.createdAt == this.createdAt && other.updatedAt == this.updatedAt && other.merchantFees == this.merchantFees && other.batchId == this.batchId
                    && other.recipient == this.recipient && other.compliance == this.compliance)
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

        public string ToJson()
        {
            String currencyString;
            if (this.sourceAmount > 0)
            {
                currencyString = String.Format("\"sourceAmount\": {0},\n", this.sourceAmount);
            }
            else
            {
                currencyString = String.Format("\"targetAmount\": {0},\n\"targetCurrency\": \"{1}\",\n", this.targetAmount, this.TargetCurrency);
            }
            StringBuilder builder = new StringBuilder();
            builder.Append("{\n");
            builder.AppendFormat("\"id\": \"{0}\",\n", this.batchId);
            builder.Append(currencyString);
            builder.Append("\"recipient\": {\n");
            builder.AppendFormat("\"id\": \"{0}\",\n", this.recipient.Id);
            builder.AppendFormat("\"email\": \"{0}\"\n", this.recipient.Email);
            builder.Append("}\n");
            builder.Append("}");
            return builder.ToString();
        }

        public bool IsMappable()
        {
            if (Recipient == null)
            {
                throw new InvalidFieldException("Payment must have a Recipient.");
            }

            if (SourceAmount <= 0)
            {
                if (TargetAmount <= 0)
                {
                    throw new InvalidFieldException("Payment must have a Target Amount if it does not have a Source Amount.");
                }

            }
            if (TargetAmount > 0 && TargetCurrency == null)
            {
                throw new InvalidFieldException("Payment must have a Target Currency ");
            }

            return true;
        }
    }
}
