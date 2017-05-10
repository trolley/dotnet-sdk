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
            Dictionary<String, Types.Balance> balances = null;
            if (helper.ok)
            {
                balances = helper.balances;
            }
            return balances;
        }
    }
    
}
