using System;

namespace Trolley.Exceptions
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
    }
}


