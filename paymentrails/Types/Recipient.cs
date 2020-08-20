// using Newtonsoft.Json;
using PaymentRails.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace PaymentRails.Types
{
    /// <summary>
    /// This class is a representation of a Payment Rails Recipient, it can be used to create or update recipients
    /// over the API
    /// </summary>
    public class Recipient : IPaymentRailsMappable
    {
        public string id;
        public string referenceId;
        public string email;
        public string name;
        public string firstName;
        public string lastName;
        public string type;
        public string status;
        public string timeZone;
        public string language;
        public string dob;
        public string gravatarUrl;

        public Compliance compliance;
        // [JsonProperty("accounts")]
        [JsonPropertyName("accounts")]
        public List<RecipientAccount> recipientAccounts { get; set; }
        public Address address;

        /// <summary>
        /// The constructor to instantiate a recipient object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <param name="referenceId"></param>
        /// <param name="email"></param>
        /// <param name="name"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="status"></param>
        /// <param name="timeZone"></param>
        /// <param name="language"></param>
        /// <param name="dob"></param>
        /// <param name="gravatarUrl"></param>
        /// <param name="compliance"></param>
        /// <param name="payout"></param>
        /// <param name="address"></param>

        public Recipient(string type, string email, string name, string firstName, string lastName, string id = null, string referenceId = null, string status = null, string timeZone = null, string language = null, string dob = null, string gravatarUrl = null, Compliance compliance = null, List<RecipientAccount> recipientAccounts = null, Address address = null)
        {

            this.id = id;
            this.type = type;
            this.referenceId = referenceId;
            this.email = email;
            this.name = name;
            this.firstName = firstName;
            this.lastName = lastName;
            this.status = status;
            this.timeZone = timeZone;
            this.language = language;
            this.dob = dob;
            this.gravatarUrl = gravatarUrl;
            this.compliance = compliance;
            this.recipientAccounts = recipientAccounts;
            this.address = address;
        }

       

        public Recipient()
        {
        }

        public static bool operator ==(Recipient a, Recipient b)
        {
            if (System.Object.ReferenceEquals(a, b))
                return true;
            if ((object)a == null || (object)b == null)
                return false;
            return a.Equals(b);
        }

        public static bool operator !=(Recipient a, Recipient b)
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
                Recipient other = (Recipient)obj;
                if (other.id == this.id && other.referenceId == this.referenceId && other.email == this.email && other.name == this.name
                    && other.firstName == this.firstName && other.lastName == this.lastName && other.type == this.type && other.status == this.status
                    && other.timeZone == this.timeZone && other.language == this.language && other.dob == this.dob && other.gravatarUrl == this.gravatarUrl
                    && other.compliance == this.compliance && other.address == this.address)
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
            //string recipientAccountString = "null";
            string addressString = "null";
            StringBuilder builder = new StringBuilder();
            builder.Append("{\n");
            builder.AppendFormat("\"referenceId\": \"{0}\",\n", this.referenceId);
            builder.AppendFormat("\"email\": \"{0}\",\n", this.email);
            builder.AppendFormat("\"name\": \"{0}\",\n", this.name);
            builder.AppendFormat("\"firstName\": \"{0}\",\n", this.firstName);
            builder.AppendFormat("\"lastName\": \"{0}\",\n", this.lastName);
            builder.AppendFormat("\"type\": \"{0}\",\n", this.type);
            if (status != null && status != "") { builder.AppendFormat("\"status\": \"{0}\",\n", this.status); }
            builder.AppendFormat("\"timeZone\": \"{0}\",\n", this.timeZone);
            builder.AppendFormat("\"language\": \"{0}\",\n", this.language);
            builder.AppendFormat("\"dob\": \"{0}\",\n", this.dob);
            builder.AppendFormat("\"gravatarUrl\": \"{0}\",\n", this.gravatarUrl);
            builder.AppendFormat("\"id\": \"{0}\"\n",this.id);

            if (this.recipientAccounts != null)
            {

                builder.Append(",\"accounts\": [\n");
                foreach (RecipientAccount recipientAccount in this.recipientAccounts)
                {
                    builder.AppendFormat("{0}", recipientAccount);
                    if (this.recipientAccounts.Last().id != recipientAccount.id)
                    {
                        builder.Append(",");
                    }
                    builder.Append("\n");

                }
                builder.Append("]\n");
            }

            if (this.address != null)
            {
                addressString = this.address.ToJson();
                builder.Append(",");
                builder.AppendFormat("\"address\": {0}\n", addressString);
            }

            builder.Append("}");
            return builder.ToString();
        }

        /// <summary>
        /// Function that checks if a IPaymentRailsMappable object has all required fields to be sent
        /// this function will throw an exception if any of the fields are not properly set.
        /// 
        /// In order to have a valid recipient the first name and last name must be set if the 
        /// recipient is an individual OR the name must be set if it is a business. An email is also required
        /// </summary>
        /// <returns>weather the object is ready to be sent to the Payment Rails API</returns>
        public bool IsMappable()
        {
            if (type == null)
            {
                throw new InvalidFieldException("Recipient must have a type");
            }
            if (type == "individual")
                if (lastName == null)
                {
                    throw new InvalidFieldException("Recipient must have a last name if the type is individual");
                }
            if (type == "individual")
                if (firstName == null)
                {
                    throw new InvalidFieldException("Recipient must have a first name if the type is individual");
                }
            
            if (type == "business")
                if (name == null)
                {
                    throw new InvalidFieldException("Recipient must have a name if the type is business");
                }

            if (email == null)
            {
                if (id == null)
                {
                    throw new InvalidFieldException("Recipient must have an email");
                }
                
            }
           return true; 
        }
    }
}
