using Trolley.Types;
using System;
using System.Collections.Generic;

namespace Trolley
{
    /// <summary>
    /// A Class that facilitates HTTP Requests to the API in regards to Balances.
    /// </summary>

    internal class Balances
    {
        /// <summary>
        /// Retrieves all balances from the Trolley API for the specified type,
        /// if no type is selected it will return the paymentrails (trolley) type balances
        /// </summary>
        /// <param name="type">The type of account to fetch the balance from. Can be "paymentrails" for Trolley balance, or "paypal" for PayPal</param>
        /// <returns>A balance list containing a balance for each of your currencies (USD, CAD, ...)</returns>
        public static List<Balance> get()
        {
            return Configuration.gateway().balances.find();
        }

    }
}
