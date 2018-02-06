using System;
using System.Runtime.Serialization;

namespace PaymentRails.Exceptions
{
    class TooManyRequestsException : SystemException
    {
        /// <summary>

        /// Default constructor

        /// </summary>

        public TooManyRequestsException() : base()

        {

        }


        public TooManyRequestsException(string message) : base(message)

        {

        }


        public TooManyRequestsException(string message, Exception innerException) : base(message, innerException)

        {

        }



        protected TooManyRequestsException(SerializationInfo info, StreamingContext context) : base(info, context)

        {

        }
    }
}


