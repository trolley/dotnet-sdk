using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PaymentRails.JsonHelpers
{
    public class BalanceHelper : JsonHelper
    {
        /// <summary>
        /// Method to convert from JSON string to Balance object
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns>The Balance object representation of the JSON string</returns>

        public static List<Types.Balance> JsonToBalanceList(string jsonString)
        {
            if (jsonString == null || jsonString == "")
            {
                throw new ArgumentException("JSON must be provided");
            }
            BalanceListJsonHelper helper = JsonConvert.DeserializeObject<BalanceListJsonHelper>(jsonString);
            List<Types.Balance> balances = new List<Types.Balance>();
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
