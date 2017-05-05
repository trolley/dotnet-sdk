using System;
using System.Text;
using System.Net.Http;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Web;
namespace paymentrails
{
    //REMOVE THIS ONCE COMPLETED SINCE THIS PROJECT IS NOT A CONSOLE APP IT IS A LIBRARY
    class Program
    {

        private static readonly HttpClient client = new HttpClient();

        static void Main(string[] args)
        {   // railz
            PaymentRails_Configuration.setApiBase("http://api.railz.io");
            PaymentRails_Configuration.apiKey = "pk_test_5E9CB6C692DE5EE62712760B7F7D9FDF";

            // local
            //PaymentRails_Configuration.setApiBase("http://api.local.dev:3000");
            //PaymentRails_Configuration.apiKey = "pk_test_91XPUY8D8GAGA";

            string val = PaymentRails_Payment.get("P-908GY52558A7R");
            var payment = JsonHelpers.PaymentHelper.JsonToPayment(val);

            Console.WriteLine(payment);

            Console.Read();

        }       
    }
}