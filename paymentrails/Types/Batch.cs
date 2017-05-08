using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentrails.Types
{
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

        public List<Payment> Payments
        {
            get
            {
                return payments;
            }

            set
            {
                payments = value;
            }
        }
        #endregion

        public Batch(string currency, string description, List<Payment> payments, double amount, int totalPayments, string status, string sentAt, string completedAt, string createdAt, string updatedAt, string id)
        {

            this.id = id;
            this.status = status;
            this.amount = amount;
            this.totalPayments = totalPayments;
            this.currency = currency;
            this.description = description;
            this.sentAt = sentAt;
            this.completedAt = completedAt;
            this.createdAt = createdAt;
            this.updatedAt = updatedAt;
            this.payments = payments;
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
    }
}
