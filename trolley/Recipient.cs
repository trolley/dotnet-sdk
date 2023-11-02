﻿using System.Collections.Generic;
using Trolley.Types;

namespace Trolley
{
    /// <summary>
    /// A Class that facilitates HTTP Requests to the API in regards to Recipients.
    /// </summary>
    internal class Recipient
    {
        /// <summary>
        /// Retrieves a list of recipients from the API
        /// </summary>
        /// <param name="page">The page number (default: 1)</param>
        /// <param name="pageNumber">Number of records in a page (default: 10)</param>
        /// <returns>A list containing all recipient objects</returns>
        public static List<Types.Recipient> search(int page, int pageNumber)
        {
            return Recipient.search("", page, pageNumber);
        }


        /// <summary>
        /// Retrieves either the logs or payments of a recipient object
        /// </summary>
        /// <param name="recipient_id">The recipient id that belongs to a recipient bject </param>
        /// <param name="term">An optional term that can be logs or payments. Using a term will result
        /// in a the logs or payments being returned </param>
        /// <returns>The response</returns>
        public static Types.Recipient find(string recipient_id)
        {
            return Configuration.gateway().recipient.find(recipient_id);
        }
        /// <summary>
        /// Creates a recipient based on the body given to the client
        /// </summary>
        /// <param name="recipient">A recipient object that will be created</param>
        /// <returns>A newly created recipient object</returns>
        public static Types.Recipient create(Types.Recipient recipient)
        {
           return Configuration.gateway().recipient.create(recipient);
        }
        /// <summary>
        /// Updates a recipient based on the recipient id given and the body
        /// given to the client
        /// </summary>
        ///<param name="recipient">A recipient object that will be updated</param>
        /// <returns>The response</returns>
        public static bool update(Types.Recipient recipient)
        {
            return Configuration.gateway().recipient.update(recipient);
        }
        /// <summary>
        /// Deletes a recipient based on the recipient id given 
        /// </summary>
        /// <param name="recipient_id">A recipient id belonging to a recipient object</param>
        /// <returns>The response</returns>
        public static bool delete(string recipient_id)
        {
            return Configuration.gateway().recipient.delete(recipient_id);
        }
        /// <summary>
        /// Deletes a recipient based on a recipient object
        /// </summary>
        /// <param name="recipient">A recipient object that will be deleted</param>
        /// <returns>The response</returns>
        public static bool delete(Types.Recipient recipient)
        {
            return delete(recipient.id);
        }
        /// <summary>
        /// Lists all recipients based on queries
        /// </summary>
        /// <param name="term">Wildcard search of the recipient-id</param>
        /// <param name="page">The page number (default: 1)</param>
        /// <param name="pageSize">Number of records in a page (default: 10)</param>
        /// <returns>A list of recipients</returns>
        public static List<Types.Recipient> search(string term = "", int page = 1, int pageSize = 10)
        {
            return Configuration.gateway().recipient.search(term,page,pageSize);
        }

    }
}
