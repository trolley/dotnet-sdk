using System;
using System.Runtime.Serialization;

namespace PaymentRails.Exceptions
{
    public class InvalidStatusCodeException : SystemException
    {
        /// <summary>

        /// Default constructor

        /// </summary>

        public InvalidStatusCodeException() : base()

        {

        }


        public InvalidStatusCodeException(string message) : base(message)

        {

        }


        public InvalidStatusCodeException(string message, Exception innerException) : base(message, innerException)

        {

        }

       

        protected InvalidStatusCodeException(SerializationInfo info, StreamingContext context) : base(info, context)

        {

        }
    }
}
