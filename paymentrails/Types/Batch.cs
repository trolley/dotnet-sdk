using PaymentRails.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaymentRails.Types
{
    /// <summary>
    /// This class represents a Trolley batch object, it can be used to create new
    /// batches or update existing ones
    /// </summary>
    public class Batch : IPaymentRailsMappable
    {
        public string id;
        public string status;
        public double amount;
        public int totalPayments;
        public string currency;
        public string description;
        public string sentAt;
        public string completedAt;
        public string createdAt;
        public string updatedAt;

        public List<Payment> payments;

    
        /// <summary>
        /// Constructor to instantiate a batch
        /// </summary>
        /// <param name="description"></param>
        /// <param name="payments"></param>
        /// <param name="currency"></param>
        /// <param name="amount"></param>
        /// <param name="totalPayments"></param>
        /// <param name="status"></param>
        /// <param name="sentAt"></param>
        /// <param name="completedAt"></param>
        /// <param name="createdAt"></param>
        /// <param name="updatedAt"></param>
        /// <param name="id"></param>

        public Batch(string description, List<Payment> payments, string currency, double amount, int totalPayments=0, string status=null, string sentAt = null, string completedAt = null, string createdAt = null, string updatedAt = null, string id = null)
        {
            this.id = id;
            this.payments = payments;
            this.status = status;
            this.amount = amount;
            this.totalPayments = totalPayments;
            this.currency = currency;
            this.description = description;
            this.sentAt = sentAt;
            this.completedAt = completedAt;
            this.createdAt = createdAt;
            this.updatedAt = updatedAt;

        }
        public Batch() { }
        public static bool operator ==(Batch a, Batch b)
        {
            if (System.Object.ReferenceEquals(a, b))
                return true;
            if ((object)a == null || (object)b == null)
                return false;
            return a.Equals(b);
        }

        public static bool operator !=(Batch a, Batch b)
        {
            return !(a == b);
        }
        /// <summary>
        /// Checks whether all fields in a batch are equivalent to the object being compared
        /// </summary>
        /// <param name="obj">the object to compare to</param>
        /// <returns>Whether the two are equivalent</returns>
        public override bool Equals(object obj)
        {
            if (obj != null && obj.GetType() == this.GetType())
            {
                Batch other = (Batch)obj;
                // check non list fields
                if (other.id == this.id && other.status == this.status && other.amount == this.amount && other.totalPayments == this.totalPayments
                    && other.currency == this.currency && other.description == this.description && other.sentAt == this.sentAt && other.completedAt == this.completedAt
                    && other.createdAt == this.createdAt && other.updatedAt == this.updatedAt)
                {
                    // use sequence equals to check if the payments list matches
                    if (other.payments != null)
                    {
                        if (this.payments != null && other.payments.SequenceEqual(this.payments))
                            return true;
                    }
                    else
                    {
                        if (this.payments == null)
                            return true;
                    }
                }

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
            StringBuilder builder = new StringBuilder();
            builder.Append("{\n");
            if (this.currency != "" && this.currency != null) { builder.AppendFormat("\"sourceCurrency\": \"{0}\",\n", this.currency); }
            builder.AppendFormat("\"description\": \"{0}\"\n", this.description);

            if (this.payments != null)
            {
                builder.Append(",\"payments\": [\n");
                foreach (Payment payment in this.payments)
                {
                    builder.AppendFormat("{0}", payment);
                    if (this.payments.Last() != payment)
                    {
                        builder.Append(",");
                    }
                    builder.Append("\n");
                }
                builder.Append("]\n");
            }

            builder.Append("}");

            return builder.ToString();
        }
        /// <summary>
        /// Function that checks if a IPaymentRailsMappable object has all required fields to be sent
        /// this function will throw an exception if any of the fields are not properly set.
        /// For a valid batch valid payments are required
        /// </summary>
        /// <returns>whether the object is ready to be sent to the Trolley API</returns>
        public bool IsMappable()
        {
            if (payments != null)
            {
                foreach (Payment p in payments)
                {
                    if (p.sourceCurrency == null)
                    {
                        if (p.targetCurrency == null)
                        {
                            if (currency == null)
                            {
                                throw new InvalidFieldException("Batch must have a Currency if not all payment have currency's");
                            }
                        }
                    }
                }
            }
            return true;
        }
    }
}
