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
        /// Function to convert Payout object into JSON string. 
        /// 
        /// This string can be sent to the post and patch endpoints of the API.
        /// 
        /// Moved to Payout.ToJson()
        /// </summary>
        /// <param name="payout">the payout object to be converted</param>
        /// <param name="withAutoSwitch">weather to include the autoswitch fields in the JSON object</param>
        /// <param name="withHoldup">weather to include the holdup fields in the JSON object</param>
        /// <returns>a JSON string representation of payout</returns>
        public static string PayoutToJson(Payout payout, bool withAutoSwitch = true, bool withHoldup = true)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("{\n");
            if (withAutoSwitch)
                builder.AppendFormat("\"autoSwitch\": {{\n\t \"limit\": {0},\n\t \"active\": {1}\n}}\n",
                    payout.AutoswitchLimit, payout.AutoswitchActive);
            if (withHoldup)
                builder.AppendFormat("\"holdup\": {{\n\t \"limit\": {0},\n\t \"active\": {1}\n}}\n",
                    payout.HoldupLimit, payout.HoldupActive);
            if (payout.PrimaryCurrency != null)
            {
                builder.AppendFormat("\"currency\": {{\n\t \"code\": {0}\n}},\n", payout.PrimaryCurrency);
            }
            if (payout.PrimaryMethod != null)
            {
                builder.AppendFormat("\"primary\": {0},\n", payout.PrimaryMethod);
            }
            if (payout.Paypal != null || payout.Bank != null)
            {
                builder.Append("\n\"accounts\": {\n");
                if (payout.Bank != null)
                {
                    builder.AppendFormat("\"bank\": {0},\n", AccountHelper.BankAccountToJson(payout.Bank));
                }
                if (payout.Paypal != null)
                {
                    builder.AppendFormat("\"paypal\": {0},\n", AccountHelper.PaypalToJson(payout.Paypal));
                }
                builder.Append("}\n");
            }
            builder.Append("}");

            return builder.ToString();
        }

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
