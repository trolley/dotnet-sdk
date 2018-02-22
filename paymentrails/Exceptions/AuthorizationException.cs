using System;
using System.Runtime.Serialization;

namespace PaymentRails.Exceptions
{
    public class AuthorizationException : ArgumentException
    {
        /// <summary>

        /// Default constructor

        /// </summary>

        public AuthorizationException() : base()

        {

        }


        public AuthorizationException(string message) : base(message)

        {

        }


        public AuthorizationException(string message, Exception innerException) : base(message, innerException)

        {

        }



        protected AuthorizationException(SerializationInfo info, StreamingContext context) : base(info, context)

        {

        }
    }
}


