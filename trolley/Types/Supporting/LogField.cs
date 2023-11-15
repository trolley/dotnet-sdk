using System;
using System.Text;

namespace Trolley.Types.Supporting
{
	public class LogField : ITrolleyMappable
	{
		public string name { get; set; }
		public string oldValue { get; set; }
        public string newValue { get; set; }

        public LogField()
        {
        }

        public LogField(string name, string oldValue, string newValue)
        {
            this.name = name;
            this.oldValue = oldValue;
            this.newValue = newValue;
        }

        public static bool operator ==(LogField a, LogField b)
        {
            if (System.Object.ReferenceEquals(a, b))
                return true;
            if ((object)a == null || (object)b == null)
                return false;
            return a.Equals(b);
        }

        public static bool operator !=(LogField a, LogField b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Checks whether all fields in a log field are equivalent to the object being compared
        /// </summary>
        /// <param name="obj">the object to compare to</param>
        /// <returns>Whether the two are equivalent</returns>
        public override bool Equals(object obj)
        {
            if (obj != null && obj.GetType() == this.GetType())
            {
                LogField other = (LogField)obj;

                if (other.name == this.name && other.oldValue == this.oldValue && other.newValue == this.newValue)
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
            builder.AppendFormat("\"name\": \"{0}\",\n", this.name);
            builder.AppendFormat("\"oldValue\": \"{0}\",\n", this.oldValue);
            builder.AppendFormat("\"newValue\": \"{0}\",\n", this.newValue);
            builder.Append("}");

            return builder.ToString();
        }

        /// <summary>
        /// Function that checks if a ITrolleyMappable object has all required fields to be sent
        /// this function will throw an exception if any of the fields are not properly set.
        /// For a valid batch valid payments are required
        /// </summary>
        /// <returns>whether the object is ready to be sent to the Trolley API</returns>
        public bool IsMappable()
        {
            return true;
        }
    }
}

