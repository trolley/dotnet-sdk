﻿using Newtonsoft.Json;
using System;
using Trolley.JsonHelpers;

namespace Trolley.Types
{
    /// <summary>
    /// This class represents a recipient check account mailing address from the Trolley API
    /// </summary>
    public class MailingAddress : ITrolleyMappable
    {
        public string street1;
        public string street2;
        public string city;
        public string postal;
        public string phone;
        public string country;
        public string region;
        public string name;

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
                return postal;
            }

            set
            {
                postal = value;
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
        /// region code (should be valid ISO 3166-2 code)
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
        /// <param name="postal"></param>
        /// <param name="phone"></param>
        /// <param name="country"></param>
        /// <param name="region"></param>
        public MailingAddress(string name, string street1, string city, string country, string region, string postal = null, string street2 = null, string phone = null)
        {
            this.name = name;
            this.street1 = street1;
            this.street2 = street2;
            this.city = city;
            this.postal = postal;
            this.phone = phone;
            this.country = country;
            this.region = region;
        }

        /// <summary>
        /// no paramater constructor for recipient's address sets all fields to null
        /// </summary>
        public MailingAddress()
        {

        }

        /// <summary>
        /// Operator that checks for the equality of all fields within an MailingAddress object
        /// </summary>
        /// <param name="a">The first address</param>
        /// <param name="b">The second address</param>
        /// <returns>Weather the addresses are the same</returns>
        public static bool operator ==(MailingAddress a, MailingAddress b)
        {
            if (System.Object.ReferenceEquals(a, b))
                return true;
            if ((object)a == null || (object)b == null)
                return false;
            return a.Equals(b);
        }

        /// <summary>
        /// Operator that checks for the inequality of all fields within an MailingAddress object
        /// </summary>
        /// <param name="a">The first address</param>
        /// <param name="b">The second address</param>
        /// <returns>Weather the addresses are not the same</returns>
        public static bool operator !=(MailingAddress a, MailingAddress b)
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
                MailingAddress other = (MailingAddress)obj;
                if (other.street1 == this.street1 && other.street2 == this.street2 && other.city == this.city && other.postal == this.postal
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
            return ToJson();
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, SerializerHelper.GetSerializerSettings());
        }

        public bool IsMappable()
        {
            return true;
        }
    }
}
