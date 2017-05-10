using System;
using System.Text;
using System.Net.Http;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Web;
using paymentrails.Types;

namespace paymentrails
{
    //REMOVE THIS ONCE COMPLETED SINCE THIS PROJECT IS NOT A CONSOLE APP IT IS A LIBRARY
    class Program
    {

        private static readonly HttpClient client = new HttpClient();

        static void Main(string[] args)
        {   // railz
            //PaymentRails_Configuration.ApiBase = "http://api.railz.io";
            //PaymentRails_Configuration.ApiKey = "pk_test_5E9CB6C692DE5EE62712760B7F7D9FDF";

            // local
            PaymentRails_Configuration.setApiBase("http://api.local.dev:3000");
            PaymentRails_Configuration.ApiKey = "pk_test_91XPYV1Y8MXQC";

            //Types.Recipient recipient = PaymentRails_Recipient.get("R-91XPRHAX8G5MW");
            //PaymentRails_Recipient.get("R-91XPRHAX8G5MW");
            //recipient.Payout.PrimaryMethod = "paypal";
            //recipient.Email = "test@test.test";
            //recipient.Payout.AutoswitchActive = true;
            //Console.WriteLine(recipient);
            //PaymentRails_Recipient.patch(recipient);
            //recipient = PaymentRails_Recipient.get("R-91XQ00KM0CPMR");
            //string val = PaymentRails_Payment.get("P-908GY52558A7R");
            //var payment = JsonHelpers.PaymentHelper.JsonToPayment(val);

            //string val = PaymentRails_Batch.get("B-912Q4PAPBN868");
            //Types.Batch batch = JsonHelpers.BatchHelper.JsonToBatch(val);
            String r = PaymentRails_Recipient.get("R-91XQ4QBJ65W1U", "logs");
            Console.WriteLine(r);
            
            //Console.WriteLine(batch);

            

            Console.Read();

        }       
    }
}