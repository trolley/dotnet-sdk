using System;

namespace PaymentRails.Exceptions
{
    public class DownForMaintenanceException : ArgumentException
    {
        /// <summary>

        /// Default constructor

        /// </summary>

        public DownForMaintenanceException() : base()

        {

        }


        public DownForMaintenanceException(string message) : base(message)

        {

        }


        public DownForMaintenanceException(string message, Exception innerException) : base(message, innerException)

        {

        }
    }
}


