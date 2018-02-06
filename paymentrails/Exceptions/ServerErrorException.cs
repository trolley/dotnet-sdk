using System;
using System.Runtime.Serialization;

namespace PaymentRails.Exceptions
{
    public class ServerErrorException : SystemException
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

       

        protected ServerErrorException(SerializationInfo info, StreamingContext context) : base(info, context)

        {

        }
    }
}
