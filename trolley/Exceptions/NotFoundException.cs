﻿using System;

namespace Trolley.Exceptions
{
    public class NotFoundException : ArgumentException
    {
        /// <summary>

        /// Default constructor

        /// </summary>

        public NotFoundException() : base()

        {

        }


        public NotFoundException(string message) : base(message)

        {

        }


        public NotFoundException(string message, Exception innerException) : base(message, innerException)

        {

        }
    }
}


