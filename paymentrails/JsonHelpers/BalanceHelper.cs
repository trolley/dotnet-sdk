using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace paymentrails.JsonHelpers
{
    public class BalanceHelper : JsonHelper
    {
        public static Dictionary<String, Types.Balance> JsonToBalanceDictionary(String jsonString)
        {
            JsonBalancesHelper helper = new JavaScriptSerializer().Deserialize<JsonBalancesHelper>(jsonString);
            Dictionary<String, Types.Balance> balances = new Dictionary<string, Types.Balance>();
            if (helper.ok)
            {
                if (helper.balances.ContainsKey("USD"))
                {
                    balances.Add("USD", helper.balances["USD"]);
                }
                if (helper.balances.ContainsKey("CAD"))
                {
                    balances.Add("CAD", helper.balances["USD"]);
                }
            }
            return balances;
        }
    }
    
}
