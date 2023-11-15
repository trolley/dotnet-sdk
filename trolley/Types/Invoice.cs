using Newtonsoft.Json;
using System.Collections.Generic;
using Trolley.Types.Supporting;

namespace Trolley.Types
{
    /// <summary>
    /// This class is a representation of an Invoice in Trolley.
    /// </summary>
    public class Invoice : ITrolleyMappable
    {
        public string id;
        public string invoiceId;
        public string invoiceNumber;
        public string description;
        public string status;
        public string externalId;
        public string invoiceDate;
        public string dueDate;
        public string createdAt;
        public string updatedAt;
        public Amount totalAmount;
        public Amount paidAmount;
        public Amount dueAmount;
        public List<string> tags;
        public List<InvoiceLine> lines;
        public string recipientId;

        public Invoice(string id, string invoiceId, string invoiceNumber, string description,
            string status, string externalId, string invoiceDate, string dueDate, string createdAt,
            string updatedAt, Amount totalAmount, Amount paidAmount, Amount dueAmount,
            List<string> tags, List<InvoiceLine> lines, string recipientId)
        {
            this.id = id;
            this.invoiceId = invoiceId;
            this.invoiceNumber = invoiceNumber;
            this.description = description;
            this.status = status;
            this.externalId = externalId;
            this.invoiceDate = invoiceDate;
            this.dueDate = dueDate;
            this.createdAt = createdAt;
            this.updatedAt = updatedAt;
            this.totalAmount = totalAmount;
            this.paidAmount = paidAmount;
            this.dueAmount = dueAmount;
            this.tags = tags;
            this.lines = lines;
            this.recipientId = recipientId;
        }

        public Invoice() { }

        public static bool operator ==(Invoice a, Invoice b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if ((object)a == null || (object)b == null)
                return false;
            return a.Equals(b);
        }

        public static bool operator !=(Invoice a, Invoice b)
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
                Invoice other = (Invoice)obj;
                if (this.id == other.id
                    && this.invoiceId == other.invoiceId
                    && this.invoiceNumber == other.invoiceNumber
                    && this.description == other.description
                    && this.status == other.status
                    && this.externalId == other.externalId
                    && this.invoiceDate == other.invoiceDate
                    && this.dueDate == other.dueDate
                    && this.createdAt == other.createdAt
                    && this.updatedAt == other.updatedAt
                    && this.totalAmount == other.totalAmount
                    && this.paidAmount == other.paidAmount
                    && this.dueAmount == other.dueAmount
                    && this.tags == other.tags
                    && this.lines == other.lines
                    && this.recipientId == other.recipientId)
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
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                StringEscapeHandling = StringEscapeHandling.EscapeNonAscii,
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
            };
            return JsonConvert.SerializeObject(this, settings);
        }

        /// <summary>
        /// Function that checks if a ITrolleyMappable object has all required fields to be sent
        /// this function will throw an exception if any of the fields are not properly set.
        /// </summary>
        /// <returns>weather the object is ready to be sent to the Trolley API</returns>
        public bool IsMappable()
        {
           return true; 
        }
    }
}
