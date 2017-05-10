using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentrails.Types
{
    /// <summary>
    /// This class represents a recipient address from the Payment Rails API
    /// </summary>
    public class Address : IPaymentRailsMappable
    {
        private string street1;
        private string street2;
        private string city;
        private string postalCode;
        private string phone;
        private string country;
        private string region;

        #region properties
        /// <summary>
        /// Street address 1
        /// </summary>
        public string Street1
        {
            get
            {
                return street1;
            }

            set
            {
                street1 = value;
            }
        }

        /// <summary>
        /// street address 2
        /// </summary>
        public string Street2
        {
            get
            {
                return street2;
            }

            set
            {
                street2 = value;
            }
        }

        /// <summary>
        /// City name
        /// </summary>
        public string City
        {
            get
            {
                return city;
            }

            set
            {
                city = value;
            }
        }

        /// <summary>
        /// postal code
        /// </summary>
        public string PostalCode
        {
            get
            {
                return postalCode;
            }

            set
            {
                postalCode = value;
            }
        }

        /// <summary>
        /// phone number
        /// </summary>
        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
            }
        }

        /// <summary>
        /// country code (should be a valid ISO 3166-1 alpha-2 code)
        /// </summary>
        public string Country
        {
            get
            {
                return country;
            }

            set
            {
                country = value;
            }
        }

        /// <summary>
        /// region code (should be valid iso_3166-2 code)
        /// </summary>
        public string Region
        {
            get
            {
                return region;
            }

            set
            {
                region = value;
            }
        }
        #endregion properties

        /// <summary>
        /// Default constructor for a recipient's address
        /// </summary>
        /// <param name="street1"></param>
        /// <param name="street2"></param>
        /// <param name="city"></param>
        /// <param name="postalCode"></param>
        /// <param name="phone"></param>
        /// <param name="country"></param>
        /// <param name="region"></param>
        public Address(string street1, string street2, string city, string postalCode, string phone, string country, string region)
        {
            this.street1 = street1;
            this.street2 = street2;
            this.city = city;
            this.postalCode = postalCode;
            this.phone = phone;
            this.country = country;
            this.region = region;
        }

        /// <summary>
        /// no paramater constructor for recipient's address sets all fields to null
        /// </summary>
        public Address()
        {

        }

        /// <summary>
        /// Operator that checks for the equality of all fields within an Address object
        /// </summary>
        /// <param name="a">The first address</param>
        /// <param name="b">The second address</param>
        /// <returns>Weather the addresses are the same</returns>
        public static bool operator ==(Address a, Address b)
        {
            if (System.Object.ReferenceEquals(a, b))
                return true;
            if ((object)a == null || (object)b == null)
                return false;
            return a.Equals(b);
        }

        /// <summary>
        /// Operator that checks for the inequality of all fields within an Address object
        /// </summary>
        /// <param name="a">The first address</param>
        /// <param name="b">The second address</param>
        /// <returns>Weather the addresses are not the same</returns>
        public static bool operator  !=(Address a, Address b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Checks weather all fields in the object being compared are equal to this instances
        /// fields
        /// </summary>
        /// <param name="obj">The object to compare with</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj != null && obj.GetType() == this.GetType())
            {
                Address other = (Address)obj;
                if (other.street1 == this.street1 && other.Street2 == this.Street2 && other.city == this.city && other.postalCode == this.postalCode
                    && other.phone == this.phone && other.country == this.country && other.region == this.region)
                    return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Function that represents this object as a JSON string
        /// </summary>
        /// <returns>The results of calling ToJson</returns>
        public override string ToString()
        {
            return this.ToJson();
        }
        
        public string ToJson()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("{\n");
            builder.AppendFormat("\"street1\": \"{0}\",\n", this.street1);
            builder.AppendFormat("\"street2\": \"{0}\",\n", this.street2);
            builder.AppendFormat("\"city\": \"{0}\",\n", this.city);
            builder.AppendFormat("\"postalCode\": \"{0}\",\n", this.postalCode);
            builder.AppendFormat("\"phone\": \"{0}\",\n", this.phone);
            builder.AppendFormat("\"country\": \"{0}\",\n", this.country);
            builder.AppendFormat("\"region\": \"{0}\"\n", this.region);
            builder.Append("}");
            return builder.ToString();
        }

        public bool IsMappable()
        {
            return true;
        }
    }
}
