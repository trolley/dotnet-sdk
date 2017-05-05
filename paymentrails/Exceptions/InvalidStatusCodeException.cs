using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace paymentrails.Exceptions
{
    public class InvalidStatusCodeException : SystemException
    {
        /// <summary>

        /// Default constructor

        /// </summary>

        public InvalidStatusCodeException() : base()

        {

        }


        public InvalidStatusCodeException(String message) : base(message)

        {

        }


        public InvalidStatusCodeException(String message, Exception innerException) : base(message, innerException)

        {

        }

       

        protected InvalidStatusCodeException(SerializationInfo info, StreamingContext context) : base(info, context)

        {

        }
    }
}
