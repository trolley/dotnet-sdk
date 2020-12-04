using System;
using System.Collections.Generic;
// using System.Text.Json;
// using System.Web.Script.Serialization;
using PaymentRails.Types;
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

        public static List<Balance> JsonToBalanceList(string jsonString)
        {
            if (jsonString == null || jsonString == "")
            {
                throw new ArgumentException("JSON must be provided");
            }
            BalanceListJsonHelper helper = JsonSerializer.Deserialize<BalanceListJsonHelper>(jsonString);
            List<Balance> balances = new List<Balance>();
            if (helper.Ok)
            {
                foreach(BalanceJsonHelper b in helper.Balances)
                {
                    balances.Add(BalanceJsonHelperToBalance(b));
                }
            }
            return balances;
        }
    }
    
}
