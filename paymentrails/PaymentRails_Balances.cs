using PaymentRails.Types;
using System;
using System.Collections.Generic;

namespace PaymentRails
{
    /// <summary>
    /// A Class that facilitates HTTP Requests to the API in regards to Balances.
    /// </summary>

    public class PaymentRails_Balances
    {
        /// <summary>
        /// Retrieves all balances from the Payment Rails API for the specified type,
        /// if no type is selected it will return the paymentrails type balances
        /// </summary>
        /// <param name="type">The type of account to fetch the balance from. Can be "paymentrails", "paypal"</param>
        /// <returns>A balance list containing a balance for each of your currencies (USD, CAD, ...)</returns>
        public static List<Balance> get()
        {
            return PaymentRails_Configuration.gateway().balances.find();
        }

    }
}
