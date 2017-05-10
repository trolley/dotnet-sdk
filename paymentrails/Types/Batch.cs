using paymentrails.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentrails.Types
{
    /// <summary>
    /// This class represents a Payment Rails batch object, it can be used to create new
    /// batches or update existing ones
    /// </summary>
    public class Batch : IPaymentRailsMappable
    {
        private string id;
        private string status;
        private double amount;
        private int totalPayments;
        private string currency;
        private string description;
        private string sentAt;
        private string completedAt;
        private string createdAt;
        private string updatedAt;

        private List<Payment> payments;

        #region Properties
        /// <summary>
        /// The batch id
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
        /// The current status of the batch
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
        /// The total value of the batch
        /// </summary>
        public double Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }
        /// <summary>
        /// The number of payments in the batch
        /// </summary>
        public int TotalPayments
        {
            get
            {
                return totalPayments;
            }

            set
            {
                totalPayments = value;
            }
        }
        /// <summary>
        /// The currency code of the batch
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
        /// A short description of what the batch is for
        /// </summary>
        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }
        /// <summary>
        /// when the batch was sent
        /// </summary>
        public string SentAt
        {
            get
            {
                return sentAt;
            }

            set
            {
                sentAt = value;
            }
        }
        /// <summary>
        /// when the batch was completed
        /// </summary>
        public string CompletedAt
        {
            get
            {
                return completedAt;
            }

            set
            {
                completedAt = value;
            }
        }
        /// <summary>
        /// when the batch was created
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
        /// when the batch was last updated
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
        /// The list of payments included in the batch
        /// If you retrieve a list of batches from the API this field will not be set.
        /// </summary>
        public List<Payment> Payments
        {
            get
            {
                return payments;
            }

            set
            {
                if(value == null)
                {
                    value = new List<Payment>();
                }
                payments = value;
            }
        }
        #endregion
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
        public Batch(string description, List<Payment> payments, string currency, double amount, int totalPayments, string status, string sentAt, string completedAt, string createdAt, string updatedAt, string id)
        {

            this.Id = id;
            this.Payments = payments;
            this.Status = status;
            this.Amount = amount;
            this.TotalPayments = totalPayments;
            this.Currency = currency;
            this.Description = description;
            this.SentAt = sentAt;
            this.CompletedAt = completedAt;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            
        }

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
                    if (other.Payments != null)
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
        /// the Payment Rails API post and patch endpoints
        /// </summary>
        /// <returns>JSON string representation of the object</returns>
        public string ToJson()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("{\n");
            builder.AppendFormat("\"sourceCurrency\": \"{0}\",\n", this.currency);
            builder.AppendFormat("\"description\": \"{0}\",\n", this.description);
            builder.Append("\"payments\": [\n");
            foreach(Payment payment in this.payments)
            {
                builder.AppendFormat("{0}", payment);
                if(this.payments.Last().Id != payment.Id)
                {
                    builder.Append(",");
                }
                builder.Append("\n");
            }
            builder.Append("]\n");
            builder.Append("}");

            return builder.ToString();
        }
        /// <summary>
        /// Function that checks if a IPaymentRailsMappable object has all required fields to be sent
        /// this function will throw an exception if any of the fields are not properly set.
        /// For a valid batch valid payments are required
        /// </summary>
        /// <returns>weather the object is ready to be sent to the Payment Rails API</returns>
        public bool IsMappable()
        {
            foreach (Payment p in Payments)
            {
                if (p.SourceCurrency == null)
                {
                    if (p.TargetCurrency == null)
                    {
                        if (Currency == null)
                        {
                            throw new InvalidFieldException("Batch must have a Currency if not all payment have currency's");
                        }
                    }
                }
            }
            return true;
        }
    }
}
