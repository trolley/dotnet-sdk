using System;

namespace Trolley.Exceptions
{
    public class InvalidCredentialsException : ArgumentException
    {
        /// <summary>

        /// Default constructor

        /// </summary>

        public InvalidCredentialsException() : base()

        {

        }


        public InvalidCredentialsException(string message) : base(message)

        {

        }


        public InvalidCredentialsException(string message, Exception innerException) : base(message, innerException)

        {

        }
    }
}


