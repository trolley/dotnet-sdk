using PaymentRails.Exceptions;
using System;
using System.Text;

namespace PaymentRails.Types
{
    /// <summary>
    /// This class represents a Payment Rails Payment, it can be used to create new payments or update
    /// existing payments over the API
    /// </summary>
    public class Payment : IPaymentRailsMappable
    {
        public double sourceAmount;
        public string targetCurrency;
        public double exchangeRate;
        public double fees;
        public double recipientFees;
        public double targetAmount;
        public double fxRate;
        public string memo;
        public string processedAt;
        public string createdAt;
        public string updatedAt;
        public double merchantFees;
        public string sourceCurrency;
        public string batchId;
        public string id;
        public string status;

        public Recipient recipient;
        public Compliance compliance;

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
        public Payment(Recipient recipient, double sourceAmount, string sourceCurrency, double targetAmount, string targetCurrency,string id = null, string memo = null, double exchangeRate = 0,
            double fees = 0, double recipientFees = 0, double fxRate = 0, string processedAt = null, string createdAt = null, string updatedAt = null,
            double merchantFees = 0, string batchId = null, string status = null, Compliance compliance= null)

        {
            this.sourceAmount = sourceAmount;
            this.targetAmount = targetAmount;
            this.targetCurrency = targetCurrency;
            this.exchangeRate = exchangeRate;
            this.fees = fees;
            this.recipientFees = recipientFees;
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
            string currencyString;
            if (this.sourceAmount > 0)
            {
                currencyString = String.Format("\"sourceAmount\": \"{0}\",\n", this.sourceAmount);
            }
            else
            {
                currencyString = String.Format("\"targetAmount\": \"{0}\",\n\"targetCurrency\": \"{1}\",\n",this.targetAmount, this.targetCurrency);
            }
            StringBuilder builder = new StringBuilder();
            builder.Append("{\n");
            builder.AppendFormat("\"memo\":\"{0}\",\n", this.memo);
            builder.AppendFormat("\"id\": \"{0}\",\n", this.batchId);
            builder.Append(currencyString);
            builder.Append("\"recipient\": {\n");
            builder.AppendFormat("\"id\": \"{0}\",\n", this.recipient.id);
            builder.AppendFormat("\"email\": \"{0}\"\n", this.recipient.email);
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
            if (recipient == null)
            {
                throw new InvalidFieldException("Payment must have a Recipient.");
            }

            if (sourceAmount <= 0)
            {
                if (targetAmount <= 0)
                {
                    throw new InvalidFieldException("Payment must have a Target Amount if it does not have a Source Amount.");
                }

            }
            if (targetAmount > 0 && targetCurrency == null)
            {
                throw new InvalidFieldException("Payment must have a Target Currency ");
            }

            return true;
        }
    }
}
