using System;
using System.Runtime.Serialization;

namespace PaymentRails.Exceptions
{
    public class MalformedUrlException : ArgumentException
    {
        /// <summary>

        /// Default constructor

        /// </summary>

        public MalformedUrlException() : base()

        {

        }


        public MalformedUrlException(string message) : base(message)

        {

        }


        public MalformedUrlException(string message, Exception innerException) : base(message, innerException)

        {

        }



        protected MalformedUrlException(SerializationInfo info, StreamingContext context) : base(info, context)

        {

        }
    }
}


