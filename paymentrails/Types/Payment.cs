using paymentrails.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentrails.Types
{
    /// <summary>
    /// This class represents a Payment Rails Payment, it can be used to create new payments or update
    /// existing payments over the API
    /// </summary>
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
        /// <summary>
        /// The value of the payment in the merchants currency
        /// </summary>
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
        /// <summary>
        /// The currency code of the target payment
        /// </summary>
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
        /// <summary>
        /// The exchange rate
        /// </summary>
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
        /// <summary>
        /// The fees on the payment 
        /// </summary>
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
        /// <summary>
        /// The fees on the payment covered by the recipient
        /// </summary>
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
        /// <summary>
        /// The value of the payment in the recipient's currency
        /// </summary>
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
        /// <summary>
        /// The fx rate
        /// </summary>
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
        /// <summary>
        /// A short message associated with the payment
        /// </summary>
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
        /// <summary>
        /// The time the payment was processed at
        /// </summary>
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
        /// <summary>
        /// The time the payment was created at
        /// </summary>
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
        /// <summary>
        /// The time the payment was updated at
        /// </summary>
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
        /// <summary>
        /// The fees on the payment covered by the merchant
        /// </summary>
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
        /// <summary>
        /// The currency code of the source amount
        /// </summary>
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
        /// <summary>
        /// The id of the batch this payment is a part of
        /// All payments must be part of a batch
        /// </summary>
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
        /// <summary>
        /// The id of the payment
        /// </summary>
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
        /// <summary>
        /// The current status of the payment
        /// </summary>
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
        /// <summary>
        /// The recipient that the payment is for
        /// When creating a payment not all recipient fields are necessary
        /// </summary>
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
        /// <summary>
        /// The current compliance status of the payment
        /// </summary>
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

        /// <summary>
        /// The constructor to instantiate a payment
        /// </summary>
        /// <param name="recipient"></param>
        /// <param name="sourceAmount"></param>
        /// <param name="memo"></param>
        /// <param name="targetAmount"></param>
        /// <param name="targetCurrency"></param>
        /// <param name="exchangeRate"></param>
        /// <param name="fees"></param>
        /// <param name="recipientFees"></param>
        /// <param name="fxRate"></param>
        /// <param name="processedAt"></param>
        /// <param name="createdAt"></param>
        /// <param name="updatedAt"></param>
        /// <param name="merchantFees"></param>
        /// <param name="sourceCurrency"></param>
        /// <param name="batchId"></param>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <param name="compliance"></param>
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

        /// <summary>
        /// Checks whether all the fields in this payment are equivalent to the object being compared
        /// </summary>
        /// <param name="obj">the object to compare to</param>
        /// <returns>whether the payment and the other object are equalt</returns>
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
        /// <summary>
        /// Returns a JSON string representation of the object formatted to be compliant with
        /// the Payment Rails API post and patch endpoints
        /// </summary>
        /// <returns>JSON string representation of the object</returns>
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
            builder.AppendFormat("\"memo\":\"{0}\"", this.memo);
            builder.AppendFormat("\"id\": \"{0}\",\n", this.batchId);
            builder.Append(currencyString);
            builder.Append("\"recipient\": {\n");
            builder.AppendFormat("\"id\": \"{0}\",\n", this.recipient.Id);
            builder.AppendFormat("\"email\": \"{0}\"\n", this.recipient.Email);
            builder.Append("}\n");
            builder.Append("}");
            return builder.ToString();
        }
        /// <summary>
        /// Function that checks if a IPaymentRailsMappable object has all required fields to be sent
        /// this function will throw an exception if any of the fields are not properly set.
        /// For a payment the recipient and batch id are mandatory
        /// source amount or target amount and currency are also required
        /// </summary>
        /// <returns>weather the object is ready to be sent to the Payment Rails API</returns>
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
