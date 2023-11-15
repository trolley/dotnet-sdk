using System;

namespace Trolley.Exceptions
{
    public class AuthenticationException : ArgumentException
    {
        /// <summary>

        /// Default constructor

        /// </summary>

        public AuthenticationException() : base()

        {

        }


        public AuthenticationException(string message) : base(message)

        {

        }


        public AuthenticationException(string message, Exception innerException) : base(message, innerException)

        {

        }
    }
}


