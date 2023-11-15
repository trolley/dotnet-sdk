using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trolley.Types.Supporting;

namespace Trolley.Types
{
    /// <summary>
    /// This class represents a Trolley Log object.
    /// </summary>
    public class Log : ITrolleyMappable
    {
        public string via { get; set; }
        public string ipAddress { get; set; }
        public string userId { get; set; }
        public string type { get; set; }
        public List<LogField> fields { get; set; }
        public string createdAt { get; set; }

        /// <summary>
        /// Constructor to instantiate a Log object.
        /// </summary>
        /// <param name="via"></param>
        /// <param name="ipAddress"></param>
        /// <param name="userId"></param>
        /// <param name="type"></param>
        /// <param name="fields"></param>
        /// <param name="createdAt"></param>
        public Log(string via, string ipAddress, string userId, string type, List<LogField> fields, string createdAt)
        {
            this.via = via;
            this.ipAddress = ipAddress;
            this.userId = userId;
            this.type = type;
            this.fields = fields;
            this.createdAt = createdAt;
        }

        public Log() { }

        public static bool operator ==(Log a, Log b)
        {
            if (System.Object.ReferenceEquals(a, b))
                return true;
            if ((object)a == null || (object)b == null)
                return false;
            return a.Equals(b);
        }

        public static bool operator !=(Log a, Log b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Checks whether all fields in a Log object are equivalent to the object being compared
        /// </summary>
        /// <param name="obj">the object to compare to</param>
        /// <returns>Whether the two are equivalent</returns>
        public override bool Equals(object obj)
        {
            if (obj != null && obj.GetType() == this.GetType())
            {
                Log other = (Log)obj;

                if (other.via == this.via && other.ipAddress == this.ipAddress && other.userId == this.userId && other.type == this.type
                    && other.fields == this.fields && other.createdAt == this.createdAt)
                {
                    
                    return true;
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
                builder.AppendFormat("\"via\": \"{0}\",\n", this.via);
                builder.AppendFormat("\"ipAddress\": \"{0}\",\n", this.ipAddress);
                builder.AppendFormat("\"userId\": \"{0}\",\n", this.userId);
                builder.AppendFormat("\"type\": \"{0}\",\n", this.type);

            if (this.fields != null && this.fields.Count > 0)
            {
                builder.Append("\"fields\": [\n");

                foreach (LogField logField in this.fields)
                {
                    builder.AppendFormat("{0}", logField);

                    if (this.fields.Last() != logField)
                    {
                        builder.Append(",");
                    }
                    builder.Append("\n");
                }
                builder.Append("]\n");
            }
                builder.AppendFormat("\"createdAt\": \"{0}\"\n", this.createdAt);
            builder.Append("}");

            return builder.ToString();
        }

        /// <summary>
        /// Function that checks if a ITrolleyMappable object has all required fields to be sent
        /// this function will throw an exception if any of the fields are not properly set.
        /// </summary>
        /// <returns>whether the object is ready to be sent to the Trolley API</returns>
        public bool IsMappable()
        {
            return true;
        }
    }
}
