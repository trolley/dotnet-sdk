using Newtonsoft.Json;
using System.Collections.Generic;
using Trolley.JsonHelpers;
using Trolley.Types.Supporting;

namespace Trolley.Types
{
    /// <summary>
    /// This class is a representation of an InvoicePayment in Trolley.
    /// </summary>
    public class InvoicePayment : ITrolleyMappable
    {
        public string batchId;
        public string paymentId;
        public List<InvoicePaymentPart> invoicePayments;

        public InvoicePayment(string batchId, string paymentId, List<InvoicePaymentPart> invoicePayments)
        {
            this.batchId = batchId;
            this.paymentId = paymentId;
            this.invoicePayments = invoicePayments;
        }

        public InvoicePayment() { }

        public static bool operator ==(InvoicePayment a, InvoicePayment b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if ((object)a == null || (object)b == null)
                return false;
            return a.Equals(b);
        }

        public static bool operator !=(InvoicePayment a, InvoicePayment b)
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
                InvoicePayment other = (InvoicePayment)obj;
                if (this.batchId == other.batchId
                    && this.paymentId == other.paymentId
                    && this.invoicePayments == other.invoicePayments)
                
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
        /// </summary>
        /// <returns>weather the object is ready to be sent to the Trolley API</returns>
        public bool IsMappable()
        {
           return true; 
        }
    }
}
