using System;

namespace PaymentRails.Exceptions
{
    public class InvalidStatusCodeException : Exception
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
    }
}
