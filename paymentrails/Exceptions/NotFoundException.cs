using System;
using System.Runtime.Serialization;

namespace PaymentRails.Exceptions
{
    public class NotFoundException : ArgumentException
    {
        /// <summary>

        /// Default constructor

        /// </summary>

        public NotFoundException() : base()

        {

        }


        public NotFoundException(string message) : base(message)

        {

        }


        public NotFoundException(string message, Exception innerException) : base(message, innerException)

        {

        }



        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)

        {

        }
    }
}


