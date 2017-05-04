using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentrails.Types
{
    public class Address
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
    }
}
