using System;
using System.Collections.Generic;
using System.Text.Json;
// using System.Web.Script.Serialization;

namespace PaymentRails.JsonHelpers
{
    public class BalanceHelper : JsonHelper
    {
        /// <summary>
        /// Method to convert from JSON string to Balance object
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns>The Balance object representation of the JSON string</returns>
        public static Dictionary<String, Types.Balance> JsonToBalanceDictionary(string jsonString)
        {
            if(jsonString == null || jsonString == "")
            {
                throw new ArgumentException("JSON must be provided");
            }
            JsonBalancesHelper helper = JsonSerializer.Deserialize<JsonBalancesHelper>(jsonString);
            Dictionary<String, Types.Balance> balances = null;
            if (helper.ok)
            {
                balances = helper.balances;
            }
            return balances;
        }
    }
    
}
