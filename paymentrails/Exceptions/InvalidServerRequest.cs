using System;

namespace PaymentRails.Exceptions
{
    class InvalidServerRequest : Exception
    {
        /// <summary>

        /// Default constructor

        /// </summary>

        public InvalidServerRequest() : base()

        {

        }


        public InvalidServerRequest(string message) : base(message)

        {

        }


        public InvalidServerRequest(string message, Exception innerException) : base(message, innerException)

        {

        }
    }
}


