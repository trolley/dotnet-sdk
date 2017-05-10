using PaymentRails.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentRails.Types
{
    /// <summary>
    /// This class is a representation of a Payment Rails Recipient, it can be used to create or update recipients
    /// over the API
    /// </summary>
    public class Recipient : IPaymentRailsMappable
    {
        private string id;
        private string referenceId;
        private string email;
        private string name;
        private string firstName;
        private string lastName;
        private string type;
        private string status;
        private string timeZone;
        private string language;
        private string dob;
        private string gravatarUrl;

        private Compliance compliance;
        private Payout payout;
        private Address address;

        #region Properties
        /// <summary>
        /// The recipient's id
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
        /// The recipient's reference id
        /// </summary>
        public string ReferenceId
        {
            get
            {
                return referenceId;
            }

            set
            {
                referenceId = value;
            }
        }
        /// <summary>
        /// the recipient's email
        /// </summary>
        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                
                email = value;
            }
        }
        /// <summary>
        /// The recipients full name if he is an individual or the buisiness name
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
              
                name = value;
            }
        }
        /// <summary>
        /// The recipient's full name
        /// </summary>
        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                
                firstName = value;
            }
        }
        /// <summary>
        /// The recipient's last name
        /// </summary>
        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                
                lastName = value;
            }
        }
        /// <summary>
        /// The type of recipient (individual or business)
        /// </summary>
        public string Type
        {
            get
            {
                return type;
            }

            set
            {
             
                type = value;
            }
        }
        /// <summary>
        /// The recipient's status
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
        /// The recipient's TimeZone
        /// </summary>
        public string TimeZone
        {
            get
            {
                return timeZone;
            }

            set
            {
                timeZone = value;
            }
        }
        /// <summary>
        /// The recipient's language
        /// </summary>
        public string Language
        {
            get
            {
                return language;
            }

            set
            {
                language = value;
            }
        }
        /// <summary>
        /// The recipient's Date of Birth
        /// </summary>
        public string Dob
        {
            get
            {
                return dob;
            }

            set
            {
                dob = value;
            }
        }
        /// <summary>
        /// The recipient's gravatar URL
        /// </summary>
        public string GravatarUrl
        {
            get
            {
                return gravatarUrl;
            }

            set
            {
                gravatarUrl = value;
            }
        }
        /// <summary>
        /// The recipient's current compliance status
        /// </summary>
        public Compliance Compliance
        {
            get
            {
                return compliance;
            }

            set
            {
                compliance = value;
            }
        }
        /// <summary>
        /// The recipient's payout method
        /// </summary>
        public Payout Payout
        {
            get
            {
                return payout;
            }

            set
            {
                payout = value;
            }
        }
        /// <summary>
        /// The recipient's address
        /// </summary>
        public Address Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }
        #endregion
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
        public Recipient(string id, string type, string referenceId, string email, string name, string firstName, string lastName, string status, string timeZone, string language, string dob, string gravatarUrl, Compliance compliance, Payout payout, Address address)
        {
            
            this.Id = id;
            this.Type = type;
            this.ReferenceId = referenceId;
            this.Email = email;
            this.Name = name;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Status = status;
            this.TimeZone = timeZone;
            this.Language = language;
            this.Dob = dob;
            this.GravatarUrl = gravatarUrl;
            this.Compliance = compliance;
            this.Payout = payout;
            this.Address = address;
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
                    && other.compliance == this.compliance && other.payout == this.payout && other.address == this.address)
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
            string payoutString = "null";
            string addressString = "null";
            StringBuilder builder = new StringBuilder();
            builder.Append("{\n");
            builder.AppendFormat("\"referenceId\": \"{0}\",\n", this.referenceId);
            builder.AppendFormat("\"email\": \"{0}\",\n", this.email);
            builder.AppendFormat("\"name\": \"{0}\",\n", this.name);
            builder.AppendFormat("\"firstName\": \"{0}\",\n", this.firstName);
            builder.AppendFormat("\"lastName\": \"{0}\",\n", this.lastName);
            builder.AppendFormat("\"type\": \"{0}\",\n", this.type);
            builder.AppendFormat("\"status\": \"{0}\",\n", this.status);
            builder.AppendFormat("\"timeZone\": \"{0}\",\n", this.timeZone);
            builder.AppendFormat("\"language\": \"{0}\",\n", this.language);
            builder.AppendFormat("\"dob\": \"{0}\",\n", this.dob);
            builder.AppendFormat("\"gravatarUrl\": \"{0}\",\n", this.gravatarUrl);
            if (this.payout != null)
            {
                payoutString = this.payout.ToJson();
            }
            builder.AppendFormat("\"payout\": {0},\n", payoutString);
            if (this.address != null)
            {
                addressString = this.address.ToJson();
            }
            builder.AppendFormat("\"address\": {0}\n", addressString);
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
            if (Type == null)
            {
                throw new InvalidFieldException("Recipient must have a type");
            }
            if (Type == "individual")
                if (LastName == null)
                {
                    throw new InvalidFieldException("Recipient must have a last name if the type is individual");
                }
            if (Type == "individual")
                if (FirstName == null)
                {
                    throw new InvalidFieldException("Recipient must have a first name if the type is individual");
                }
            
            if (Type == "business")
                if (Name == null)
                {
                    throw new InvalidFieldException("Recipient must have a name if the type is business");
                }

            if (Email == null)
            {
                if (Id == null)
                {
                    throw new InvalidFieldException("Recipient must have an email");
                }
                
            }
           return true; 
        }
    }
}
