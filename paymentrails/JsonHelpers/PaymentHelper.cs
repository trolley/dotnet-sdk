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
        public static Payment JsonToPayment(string jsonResponse)
        {
            PaymentResponseJsonHelper helper = new JavaScriptSerializer().Deserialize<PaymentResponseJsonHelper>(jsonResponse);
            Payment payment = PaymentJsonHelperToPayment(helper.Payment);
            return payment;
        }
    }
}
