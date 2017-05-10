using System;
using paymentrails.Types;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentrails.JsonHelpers
{
    class PaymentHelper : JsonHelper
    {
        public static List<Payment> JsonToPaymentList(string jsonResponse)
        {
            if (jsonResponse == null || jsonResponse == "")
            {
                throw new ArgumentException("JSON must be provided");
            }
            PaymentListJsonHelper helper = new JavaScriptSerializer().Deserialize<PaymentListJsonHelper>(jsonResponse);
            List<Payment> payments = new List<Payment>();

            if (helper.Ok)
            {
                foreach (PaymentJsonHelper p in helper.Payments)
                {
                    payments.Add(PaymentJsonHelperToPayment(p));
                }
            }
            return payments;
        }

        public static Payment JsonToPayment(string jsonResponse)
        {
            if (jsonResponse == null || jsonResponse == "")
            {
                throw new ArgumentException("JSON must be provided");
            }
            PaymentResponseJsonHelper helper = new JavaScriptSerializer().Deserialize<PaymentResponseJsonHelper>(jsonResponse);
            Payment payment = PaymentJsonHelperToPayment(helper.Payment);
            return payment;
        }
    }
}
