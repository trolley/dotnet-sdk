using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentrails.Types
{
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

        public Address()
        {

        }

        public static bool operator ==(Address a, Address b)
        {
            if (System.Object.ReferenceEquals(a, b))
                return true;
            if ((object)a == null || (object)b == null)
                return false;
            return a.Equals(b);
        }

        public static bool operator  !=(Address a, Address b)
        {
            return !(a == b);
        }

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
            throw new NotImplementedException();
        }
    }
}
