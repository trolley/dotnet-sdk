using Trolley.Exceptions;
using Trolley.Converters;
using Newtonsoft.Json;
using System.Collections.Generic;
using Trolley.JsonHelpers;
using System.ComponentModel;

namespace Trolley.Types
{
    /// <summary>
    /// This class represents a Trolley Payment, it can be used to create new payments or update
    /// existing payments over the API
    /// </summary>
    public class Payment : ITrolleyMappable
    {
        // recommended fields
        public double amount;
        public string currency;
        
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

        public Batch batch;
        public bool isSupplyPayment;
        public double? returnedAmount;
        public string category;
        public RecipientAccount account;
        public List<string> tags;
        public string externalId;
        public string payoutMethod;
        public string methodDisplay;
        public string checkNumber;
        public double? withholdingAmount;
        public string withholdingCurrency;
        public double? equivalentWithholdingAmount;
        public string equivalentWithholdingCurrency;
        public bool coverFees;
        public List<string> errors;
        public string estimatedDeliveryAt;
        public bool forceUsTaxActivity;
        public string initiatedAt;
        public string merchantId;
        public string returnedAt;
        public string returnedNote;
        public List<string> returnedReason;
        public double? routeMinimum;
        public string routeType;
        public string settledAt;
        public double? taxBasisAmount;
        public string taxBasisCurrency;
        
        // Setting default value to true, instead of false set by c#, to make sure a false value is not ignored while serializing to JSON while sending a request.
        [DefaultValue(true)]
        public bool taxReportable;

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
        public Payment(Recipient recipient, double sourceAmount, string sourceCurrency, double targetAmount, string targetCurrency, string id = null, string memo = null, double exchangeRate = 0,
            double fees = 0, double recipientFees = 0, double fxRate = 0, string processedAt = null, string createdAt = null, string updatedAt = null,
            double merchantFees = 0, string batchId = null, string status = null, Compliance compliance = null)

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

        [JsonConstructor]
        public Payment(Recipient recipient, double amount, string currency, double sourceAmount = 0, string sourceCurrency = null, double targetAmount = 0, string targetCurrency = null, string id = null, string memo = null, double exchangeRate = 0,
            double fees = 0, double recipientFees = 0, double fxRate = 0, string processedAt = null, string createdAt = null, string updatedAt = null,
            double merchantFees = 0, string batchId = null, string status = null, Compliance compliance = null) : this(recipient, sourceAmount, sourceCurrency, targetAmount, targetCurrency, id, memo, exchangeRate, fees, recipientFees, fxRate, processedAt, createdAt, updatedAt, merchantFees, batchId, status, compliance)

        {
            this.amount = amount;
            this.currency = currency;
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
        /// the Trolley API post and patch endpoints
        /// </summary>
        /// <returns>JSON string representation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, SerializerHelper.GetSerializerSettings());
        }
        /// <summary>
        /// Function that checks if a ITrolleyMappable object has all required fields to be sent
        /// this function will throw an exception if any of the fields are not properly set.
        /// For a payment the recipient and batch id are mandatory
        /// source amount or target amount and currency are also required
        /// </summary>
        /// <returns>weather the object is ready to be sent to the Trolley API</returns>
        public bool IsMappable()
        {
            if (recipient == null)
            {
                throw new InvalidFieldException("Payment must have a Recipient.");
            }

            if (sourceAmount <= 0 && amount <= 0)
            {
                if (targetAmount <= 0)
                {
                    throw new InvalidFieldException("Payment must have a Target Amount if it does not have a Source Amount or an Amount.");
                }

            }
            if (sourceAmount > 0 && sourceCurrency == null)
            {
                throw new InvalidFieldException("Payment must have a Source Currency ");
            }
            if (targetAmount > 0 && targetCurrency == null)
            {
                throw new InvalidFieldException("Payment must have a Target Currency ");
            }

            return true;
        }
    }
}
