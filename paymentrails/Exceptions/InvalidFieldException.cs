using System;
using System.Runtime.Serialization;

namespace PaymentRails.Exceptions
{
    public class InvalidFieldException : ArgumentException
    {
        /// <summary>

        /// Default constructor

        /// </summary>

        public InvalidFieldException() : base()

        {

        }


        public InvalidFieldException(string message) : base(message)

        {

        }


        public InvalidFieldException(string message, Exception innerException) : base(message, innerException)

        {

        }
    }
}


