using System;
using System.Runtime.Serialization;

namespace PaymentRails.Exceptions
{
    public class UnexpectedException : ArgumentException
    {
        /// <summary>

        /// Default constructor

        /// </summary>

        public UnexpectedException() : base()

        {

        }


        public UnexpectedException(string message) : base(message)

        {

        }


        public UnexpectedException(string message, Exception innerException) : base(message, innerException)

        {

        }



        protected UnexpectedException(SerializationInfo info, StreamingContext context) : base(info, context)

        {

        }
    }
}


