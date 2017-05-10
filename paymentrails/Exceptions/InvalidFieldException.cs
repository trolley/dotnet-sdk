using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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


        public InvalidFieldException(String message) : base(message)

        {

        }


        public InvalidFieldException(String message, Exception innerException) : base(message, innerException)

        {

        }



        protected InvalidFieldException(SerializationInfo info, StreamingContext context) : base(info, context)

        {

        }
    }
}


