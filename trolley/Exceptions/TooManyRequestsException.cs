using System;

namespace Trolley.Exceptions
{
    class TooManyRequestsException : Exception
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
    }
}


