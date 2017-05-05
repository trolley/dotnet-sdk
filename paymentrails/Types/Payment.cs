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
            if( recipient == null || batchId == null)
            {
                // throw an exception saying this is not a valid payment
            }
            this.sourceAmount = sourceAmount;
            this.targetCurrency = targetCurrency;
            this.exchangeRate = exchangeRate;
            this.fees = fees;
            this.recipientFees = recipientFees;
            this.targetAmount = targetAmount;
            this.fxRate = fxRate;
            this.memo = memo;
            this.processedAt = processedAt;
            this.createdAt = createdAt;
            this.updatedAt = updatedAt;
            this.merchantFees = merchantFees;
            this.sourceCurrency = sourceCurrency;
            this.batchId = batchId;
            this.id = id;
            this.status = status;
            this.recipient = recipient;
            this.compliance = compliance;
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
            } else
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
    }
}
