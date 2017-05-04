using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using paymentrails.Types;
using System.Web.Script.Serialization;

namespace paymentrails.JsonHelpers
{
    class PayoutHelper : JsonHelper
    {
        /// <summary>
        /// Function to convert the json results of a query to the PaymentRails payout method API into a 
        /// Payout object for use within c#
        /// </summary>
        /// <param name="jsonResponse">String returned by the API</param>
        /// <returns>Payout object with the values from the API</returns>
        public static Types.Payout JsonToPayout(string jsonResponse)
        {
            PayoutJsonHelper helper = new JavaScriptSerializer().Deserialize<PayoutJsonHelper>(jsonResponse);
            if (helper.Ok)
            {
                return PayoutJsonHelperToPayout(helper);
            }
            return new Types.Payout();
        }
    }
}
