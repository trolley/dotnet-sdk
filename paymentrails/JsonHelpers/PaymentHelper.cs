using Newtonsoft.Json;
using System;
using PaymentRails.Types;
// using System.Web.Script.Serialization;
using System.Collections.Generic;
// using System.Text.Json;

namespace PaymentRails.JsonHelpers
{
    public class PaymentHelper : JsonHelper
    {
        /// <summary>
        /// Method that converts a JSON string to a List of Payment objects
        /// </summary>
        /// <param name="jsonResponse"></param>
        /// <returns>The List of Payment that the JSON object represented</returns>
        public static List<Types.Payment> JsonToPaymentList(string jsonResponse)
        {
            if (jsonResponse == null || jsonResponse == "")
            {
                throw new ArgumentException("JSON must be provided");
            }
            PaymentListJsonHelper helper = JsonConvert.DeserializeObject<PaymentListJsonHelper>(jsonResponse);
            List<Types.Payment> payments = new List<Types.Payment>();

            if (helper.Ok)
            {
                foreach (PaymentJsonHelper p in helper.Payments)
                {
                    payments.Add(PaymentJsonHelperToPayment(p));
                }
            }
            return payments;
        }
        /// <summary>
        /// Method that converts a JSON string to a Paymentobjects
        /// </summary>
        /// <param name="jsonResponse"></param>
        /// <returns>The Payment that the JSON object represented</returns>
        public static Types.Payment JsonToPayment(string jsonResponse)
        {
            if (jsonResponse == null || jsonResponse == "")
            {
                throw new ArgumentException("JSON must be provided");
            }
            PaymentResponseJsonHelper helper = JsonConvert.DeserializeObject<PaymentResponseJsonHelper>(jsonResponse);
            Types.Payment payment = PaymentJsonHelperToPayment(helper.Payment);
            return payment;
        }
    }
}
