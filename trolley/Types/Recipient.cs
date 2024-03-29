﻿using Newtonsoft.Json;
using Trolley.Exceptions;
using Trolley.Converters;
using System.Collections.Generic;
using System;
using Trolley.Types.Supporting;
using Trolley.JsonHelpers;

namespace Trolley.Types
{
    /// <summary>
    /// This class is a representation of a Trolley Recipient, it can be used to create or update recipients
    /// over the API
    /// </summary>
    public class Recipient : ITrolleyMappable
    {
        public string id;
        public string referenceId;
        public string email;
        public string name;
        public string firstName;
        public string lastName;
        public string type;
        public string status;
        public string language;
        public string dob;
        public string gravatarUrl;
        public string routeType;
        public string routeMinimum;
        public Compliance compliance;
        public string estimatedFees;
        public Address address;

        [JsonProperty("accounts")]
        public List<RecipientAccount> recipientAccounts { get; set; }

        public string passport;
        public string updatedAt;
        public string createdAt;
        public List<GovernmentId> governmentIds;
        public string ssn;
        public string primaryCurrency;
        public string placeOfBirth;
        public List<string> tags;
        public string merchantId;
        public string payoutMethod;
        public List<string> contactEmails;
        public string taxForm;
        public string taxFormStatus;
        public string taxWithholdingPercentage;

        //public string timeZone;

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
        /// <param name="routeType"></param>
        /// <param name="routeMinimum"></param>
        /// <param name="compliance"></param>
        /// <param name="payout"></param>
        /// <param name="address"></param>

        public Recipient(string type, string email, string name, string firstName, string lastName, string id = null, string referenceId = null, string status = null, string language = null, string dob = null, string gravatarUrl = null, string routeType = null, string routeMinimum = null, Compliance compliance = null, List<RecipientAccount> recipientAccounts = null, Address address = null)
        {

            this.id = id;
            this.type = type;
            this.referenceId = referenceId;
            this.email = email;
            this.name = name;
            this.firstName = firstName;
            this.lastName = lastName;
            this.status = status;
            this.language = language;
            this.dob = dob;
            this.gravatarUrl = gravatarUrl;
            this.routeType = routeType;
            this.routeMinimum = routeMinimum;
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
                if (other.id == this.id 
                && other.referenceId == this.referenceId 
                && other.email == this.email 
                && other.name == this.name
                && other.firstName == this.firstName 
                && other.lastName == this.lastName 
                && other.type == this.type 
                && other.status == this.status
                && other.language == this.language 
                && other.dob == this.dob 
                && other.gravatarUrl == this.gravatarUrl
                && other.routeType == this.routeType
                && other.routeMinimum == this.routeMinimum
                && other.compliance == this.compliance 
                && other.address == this.address)
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
        /// 
        /// In order to have a valid recipient the first name and last name must be set if the 
        /// recipient is an individual OR the name must be set if it is a business. An email is also required
        /// </summary>
        /// <returns>weather the object is ready to be sent to the Trolley API</returns>
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
