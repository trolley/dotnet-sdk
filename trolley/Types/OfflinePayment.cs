using Trolley.Exceptions;
using Trolley.Converters;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using Trolley.Types.Supporting;
using Trolley.JsonHelpers;

namespace Trolley.Types
{
    /// <summary>
    /// This class represents a Trolley OfflinePayment, it can be used to create new offline payments or update
    /// existing offline payments over the API.
    /// </summary>
    public class OfflinePayment : ITrolleyMappable
    {

        public string id;
        public Recipient recipient;
        public double amount;
        public string currency;
        public string withholdingAmount;
        public string withholdingCurrency;
        public string equivalentWithholdingAmount;
        public string equivalentWithholdingCurrency;
        public string externalId;
        public string memo;
        public List<string> tags;
        public string category;
        public string processedAt;
        public Amount enteredAmount;
        public string updatedAt;
        public string createdAt;
        public string deletedAt;

        public OfflinePayment() { }

        /// <summary>
        /// Offline Payment constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="recipient"></param>
        /// <param name="amount"></param>
        /// <param name="currency"></param>
        /// <param name="withholdingAmount"></param>
        /// <param name="withholdingCurrency"></param>
        /// <param name="equivalentWithholdingAmount"></param>
        /// <param name="equivalentWithholdingCurrency"></param>
        /// <param name="externalId"></param>
        /// <param name="memo"></param>
        /// <param name="tags"></param>
        /// <param name="category"></param>
        /// <param name="processedAt"></param>
        /// <param name="enteredAmount"></param>
        /// <param name="updatedAt"></param>
        /// <param name="createdAt"></param>
        /// <param name="deletedAt"></param>
        [JsonConstructor]
        public OfflinePayment(string id, Recipient recipient, double amount, string currency,
            string withholdingAmount, string withholdingCurrency, string equivalentWithholdingAmount,
            string equivalentWithholdingCurrency, string externalId, string memo, List<string> tags,
            string category, string processedAt, Amount enteredAmount, string updatedAt,
            string createdAt, string deletedAt)
        {
            this.id = id;
            this.recipient = recipient;
            this.amount = amount;
            this.currency = currency;
            this.withholdingAmount = withholdingAmount;
            this.withholdingCurrency = withholdingCurrency;
            this.equivalentWithholdingAmount = equivalentWithholdingAmount;
            this.equivalentWithholdingCurrency = equivalentWithholdingCurrency;
            this.externalId = externalId;
            this.memo = memo;
            this.tags = tags;
            this.category = category;
            this.processedAt = processedAt;
            this.enteredAmount = enteredAmount;
            this.updatedAt = updatedAt;
            this.createdAt = createdAt;
            this.deletedAt = deletedAt;
        }

        public static bool operator ==(OfflinePayment a, OfflinePayment b)
        {
            if (System.Object.ReferenceEquals(a, b))
                return true;
            if ((object)a == null || (object)b == null)
                return false;
            return a.Equals(b);
        }

        public static bool operator !=(OfflinePayment a, OfflinePayment b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Checks whether all the fields in this object are equivalent to the object being compared
        /// </summary>
        /// <param name="obj">the object to compare to</param>
        /// <returns>whether the payment and the other object are equalt</returns>
        public override bool Equals(object obj)
        {
            if (obj != null && obj.GetType() == this.GetType())
            {
                OfflinePayment other = (OfflinePayment)obj;
                if (this.id == other.id && this.recipient == other.recipient
                    && this.amount == other.amount && this.currency == other.currency
                    && this.withholdingAmount == other.withholdingAmount
                    && this.withholdingCurrency == other.withholdingCurrency
                    && this.equivalentWithholdingAmount == other.equivalentWithholdingAmount
                    && this.equivalentWithholdingCurrency == other.equivalentWithholdingCurrency
                    && this.externalId == other.externalId && this.memo == other.memo
                    && this.tags == other.tags && this.category == other.category
                    && this.processedAt == other.processedAt && this.enteredAmount == other.enteredAmount
                    && this.updatedAt == other.updatedAt && this.createdAt == other.createdAt
                    && this.deletedAt == other.deletedAt)

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
        /// For a an offline payment the recipient and amount are mandatory.
        /// source amount or target amount and currency are also required.
        /// </summary>
        /// <returns>weather the object is ready to be sent to the Trolley API</returns>
        public bool IsMappable()
        {
            if (amount <= 0 || (currency == null && currency.Length == 0))
            {
                throw new InvalidFieldException("Offline Payment must have amount and currency set.");
            }

            return true;
        }
    }
}
