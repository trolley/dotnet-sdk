using System;

namespace Trolley.Exceptions
{
    public class ServerErrorException : Exception
    {
        /// <summary>

        /// Default constructor

        /// </summary>

        public ServerErrorException() : base()

        {

        }


        public ServerErrorException(string message) : base(message)

        {

        }


        public ServerErrorException(string message, Exception innerException) : base(message, innerException)

        {

        }
    }
}
