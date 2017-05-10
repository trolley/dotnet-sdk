using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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


        public InvalidServerRequest(String message) : base(message)

        {

        }


        public InvalidServerRequest(String message, Exception innerException) : base(message, innerException)

        {

        }



        protected InvalidServerRequest(SerializationInfo info, StreamingContext context) : base(info, context)

        {

        }
    }
}


