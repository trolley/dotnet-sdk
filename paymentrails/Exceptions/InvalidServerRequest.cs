using System;
using System.Runtime.Serialization;

namespace PaymentRails.Exceptions
{
    class InvalidServerRequest : SystemException
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



        protected InvalidServerRequest(SerializationInfo info, StreamingContext context) : base(info, context)

        {

        }
    }
}


